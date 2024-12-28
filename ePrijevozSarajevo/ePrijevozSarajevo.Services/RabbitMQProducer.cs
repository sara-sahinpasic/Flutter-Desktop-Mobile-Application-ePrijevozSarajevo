using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ePrijevozSarajevo.Services
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
            };
            factory.ClientProvidedName = "Rabbit Test Producer";

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            string routingKey = "email_queue";

            channel.QueueDeclare(
                queue: routingKey,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            string emailModelJson = JsonConvert.SerializeObject(message);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(emailModelJson);
            channel.BasicPublish(
                string.Empty,
                routingKey,
                null,
                messageBodyBytes
            );
        }
    }
}
