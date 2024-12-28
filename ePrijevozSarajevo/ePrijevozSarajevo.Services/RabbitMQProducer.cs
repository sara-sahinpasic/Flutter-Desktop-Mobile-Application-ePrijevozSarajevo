using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ePrijevozSarajevo.Services
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST")
                ??"localhost"
                ,
                Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT")
                ??"5672"
                ),
                UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME")
                ??"guest"
                ,
                Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD")
                ??"guest"
                ,
                ClientProvidedName = "Rabbit Test Producer"
            };
            
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
