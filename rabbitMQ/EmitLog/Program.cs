using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace EmitLog
{
    /// <summary>
    /// Send
    /// </summary>
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
                using (var channel = connection.CreateModel()) //创建一个通道
                {
                    channel.ExchangeDeclare("publish", "fanout", true);//定义一个交换机，且采用广播类型,并设为持久化
                    string queueName = channel.QueueDeclare("EmailLog", true, false, false, null);//创建一个队列,第2个参数为true表示为持久队列,这里将结果隐式转换成string
                    var properties = channel.CreateBasicProperties();
                    //properties.SetPersistent(true);这个方法提示过时，不建议使用
                    properties.DeliveryMode = 2;//1表示不持久,2.表示持久化
                    string message = "";
                    while (message != "exit")
                    {
                        Console.Write("Please enter the message to be sent:");
                        message = Console.ReadLine();
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish("publish", "EmailLog", properties, body); //发送消息,这里指定了交换机名称,且routeKey会被忽略
                        Console.WriteLine("set message: {0}", message);
                    }
                }
            }
        }
    }
}
