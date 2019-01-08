using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace DirectProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var routingKey = "directOne";
                var message = "message from direct exchange";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "DirectExchange",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
