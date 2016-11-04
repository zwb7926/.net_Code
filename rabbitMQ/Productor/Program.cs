using System;
using System.Text;
using RabbitMQ.Client;

namespace Productor
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
                using (IModel channel = conn.CreateModel())//开启一个通道
                {
                    //在MQ上定义一个持久化队列，如果名称相同不会重复创建
                    //channel.queueDeclare：第一个参数：队列名字，
                    //第二个参数：队列是否可持久化即重启后该队列是否依然存在，
                    //第三个参数：该队列是否时独占的即连接上来时它占用整个网络连接，
                    //第四个参数：是否自动销毁即当这个队列不再被使用的时候即没有消费者对接上来时自动删除，
                    //第五个参数：其他参数如TTL（队列存活时间）等。
                    channel.QueueDeclare("MyFirstQueue", true, false, false, null);

                    string message = "";
                    

                    
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;//设置消息持久化

                    while (message != "exit")
                    {
                        Console.Write("Please enter the message to be sent:");
                        message = Console.ReadLine();
                        byte[] bytes = Encoding.UTF8.GetBytes(message);
                        //发送消息
                        //第一个参数：路由名称
                        //第二个参数：队列名称
                        //第三个参数：
                        channel.BasicPublish("", "MyFirstQueue", properties, bytes);

                    }
                }
            }
        }
    }
}
