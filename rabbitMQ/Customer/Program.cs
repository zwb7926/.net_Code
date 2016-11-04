using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            using (IConnection conn = factory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    //在MQ上定义一个持久化队列，如果名称相同不会重复创建
                    channel.QueueDeclare("MyFirstQueue", true, false, false, null);

                    //输入1，那如果接收一个消息，但是没有应答，则客户端不会收到下一个消息
                    //第一个参数是可接收消息的大小的
                    //第二个参数是处理消息最大的数量
                    //第三个参数则设置了是不是针对整个Connection的
                    channel.BasicQos(0, 1, false);

                    Console.WriteLine("Listening...");

                    //在队列上定义一个消费者
                    var consumer = new QueueingBasicConsumer(channel);

                    //消费队列，并设置应答模式为程序主动应答
                    //为了确保消息一定被消费者处理，rabbitMQ提供了消息确认功能，就是在消费者处理完任务之后，就给服务器一个回馈，服务器就会将该消息删除，如果消费者超时不回馈，那么服务器将就将该消息重新发送给其他消费者
                    channel.BasicConsume("MyFirstQueue", false, consumer);

                    while (true)
                    {
                        //阻塞函数，获取队列中的消息
                        BasicDeliverEventArgs ea = consumer.Queue.Dequeue();
                        byte[] bytes = ea.Body;
                        string str = Encoding.UTF8.GetString(bytes);
                        Console.WriteLine("HandleMsg:" + str);
                        //回复确认
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
