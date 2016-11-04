using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RPCServer
{
    class Program
    {
        private static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "rpc_queue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                channel.BasicQos(0, 1, false);
                var consumer = new QueueingBasicConsumer(channel);
                channel.BasicConsume(queue: "rpc_queue",
                    noAck: false,
                    consumer: consumer);
                Console.WriteLine(" [x] Awaiting RPC requests");

                while (true)
                {
                    string response = null;
                    BasicDeliverEventArgs ea = consumer.Queue.Dequeue();

                    var body = ea.Body;
                    var props = ea.BasicProperties;
                    var replyProps = channel.CreateBasicProperties();
                    replyProps.CorrelationId = props.CorrelationId;

                    try
                    {
                        var message = Encoding.UTF8.GetString(body);
                        int n = int.Parse(message);
                        Console.WriteLine(" [.] Fib({0})", message);
                        response = Fib(n).ToString();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" [.] " + e.Message);
                        response = "";
                    }
                    finally
                    {
                        var responseBytes = Encoding.UTF8.GetBytes(response);
                        channel.BasicPublish(exchange: "",routingKey: props.ReplyTo,basicProperties: replyProps,body: responseBytes);
                        channel.BasicAck(deliveryTag: ea.DeliveryTag,multiple: false);
                    }
                }
            }
        }
        /// <summary>
        /// Assumes only valid positive integer input.
        /// Don't expect this one to work for big numbers,
        /// and it's probably the slowest recursive implementation possible.
        /// </summary>
        private static int Fib(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            //return Fib(n - 1) + Fib(n - 2);
            return n - 2;
        }
    }
}
