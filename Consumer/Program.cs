using Config.services;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Consumer
{
    class Program
    {
        public static void Main()
        {
            TopicConfig config = new TopicConfig();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var message = "Hello World topic exchange";

              
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: config.exchangeName,
                                     routingKey: config.routingKey,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
