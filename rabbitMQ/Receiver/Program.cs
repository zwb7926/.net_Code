using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Receiver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cf = new ConnectionFactory
            {
                
                UserName = "guest",
                Password = "guest",
                HostName = "localhost",
                Port = AmqpTcpEndpoint.UseDefaultPort,
                VirtualHost = "gay",
                RequestedHeartbeat = 0,
                Protocol=Protocols.DefaultProtocol,
                AutomaticRecoveryEnabled = true
            };

            using (IConnection conn = cf.CreateConnection())//创建链接
            {
                using (IModel channel = conn.CreateModel())//开启通道
                {
                    //普通使用方式BasicGet  
                    //noAck = true，不需要回复，接收到消息后，queue上的消息就会清除  
                    //noAck = false，需要回复，接收到消息后，queue上的消息不会被清除，  
                    //直到调用channel.basicAck(deliveryTag, false);   
                    //queue上的消息才会被清除 而且，在当前连接断开以前，其它客户端将不能收到此queue上的消息  

                    BasicGetResult res = channel.BasicGet("q", false /*noAck*/);
                    if (res != null)
                    {
                        Console.WriteLine(UTF8Encoding.UTF8.GetString(res.Body));
                        channel.BasicAck(res.DeliveryTag, false);
                    }
                    else
                    {
                        Console.WriteLine("无内容!!");
                    }

                }
            }
            Console.ReadLine();
        }
    }
}
    

