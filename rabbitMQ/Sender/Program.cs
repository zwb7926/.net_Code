using System;
using System.Collections;
using RabbitMQ.Client;
using RabbitMQ.Client.Content;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            //服务器所在的主机ip  
            var uri = new Uri("amqp://172.18.108.118:55672/");
            string exchange = "routing";//路由  
            string exchangeType = "direct";//交换模式  
            string routingKey = "rk";//路由关键字  
            bool persistMode = true;//是否对消息队列持久化保存  

     
            var ConnectionFactory = new ConnectionFactory
            {
                UserName = "guest",
                Password = "guest",
                HostName = "localhost",
                Port = AmqpTcpEndpoint.UseDefaultPort,
                VirtualHost = "gay",
                RequestedHeartbeat = 0,
                Protocol = Protocols.DefaultProtocol,
                AutomaticRecoveryEnabled = true
            };

            using (IConnection conn = ConnectionFactory.CreateConnection())//创建一个连接到具体总结点的连接  
            {
                using (IModel ch = conn.CreateModel())//创建并返回一个新连接到具体节点的通道
                {
                    if (!string.IsNullOrEmpty(exchangeType))
                    {
                        ch.ExchangeDeclare(exchange, exchangeType);//声明一个路由
                        ch.QueueDeclare("queue1", true, false, false, null);//声明一个队列  
                        ch.QueueBind("queue1", exchange, routingKey);//将一个队列和一个路由绑定起来。并制定路由关键字
                    }
                    IMapMessageBuilder messageBuilder = new MapMessageBuilder(ch);//构造消息实体对象并发布到消息队列上  
                    var target = (IDictionary)messageBuilder.Headers;
                    target["header"] = "hello world";
                    var targerBody = (IDictionary)messageBuilder.Body;
                    targerBody["body"] = "hello world";//这个才是具体的发送内容  
                    if (persistMode)
                    {
                        //设定传输模式
                        ((IBasicProperties)messageBuilder.GetContentHeader()).DeliveryMode = 2;
                    }
                    //写入  
                    ch.BasicPublish(exchange, routingKey, (IBasicProperties)messageBuilder.GetContentHeader(), messageBuilder.GetContentBody());
                    Console.WriteLine("写入成功");
                }
            }
        }
    }
}
