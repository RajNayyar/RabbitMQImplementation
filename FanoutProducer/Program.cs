using Config.services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace FanoutProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                FanoutConfig fanoutConfig = new FanoutConfig();

                var message = "It is a FanOut Message";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: fanoutConfig.exchangeName,
                                     routingKey: fanoutConfig.routingKey,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
