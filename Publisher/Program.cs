using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Publisher
{
    class Program
    {
        public static void Main(string[] args)
        {
            var queueName = "";
            var bindingKey = "";

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var receivingFromQueue = "TopicQueue";
                //  channel.ExchangeDeclare(exchange: "logs", type: "fanout");

                // var queueName = channel.QueueDeclare().QueueName;
                //channel.QueueBind(queue: receivingFromQueue,
                //                  exchange: "logs",
                //                  routingKey: "");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] {0}", message);


                };
                channel.BasicConsume(queue: receivingFromQueue,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
