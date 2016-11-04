using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ReceiveLogsDirect
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();//创建连接工厂并初始连接
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";

            using (var connection = factory.CreateConnection())//创建一个连接
            {
                using (var channel = connection.CreateModel())//创建一个通道
                {
                    channel.ExchangeDeclare("publish-topic", "topic", true);//定义一个交换机，且采用广播类型，并持久化该交换机
                    string queueName = channel.QueueDeclare("hello-mq", true, false, false, null);//创建一个队列,第2个参数为true表示为持久队列
                    channel.QueueBind(queueName, "publish-topic", "*.test");//将队列绑定到路由上，实现消息订阅
                    channel.BasicQos(0, 1, false);//在一个工作者还在处理消息，并且没有响应消息之前，不要给他分发新的消息。相反，将这条新的消息发送给下一个不那么忙碌的工作者。

                    var consumer = new QueueingBasicConsumer(channel);//创建一个消费者
                    channel.BasicConsume(queueName, false, consumer);//开启消息者与通道、队列关联

                    Console.WriteLine(" waiting for message.");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();//接收消息并出列

                        var body = ea.Body;//消息主体
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Received {0}", message);
                        channel.BasicAck(ea.DeliveryTag, false);//应答
                        if (message == "exit")
                        {
                            Console.WriteLine("exit!");
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }
}
