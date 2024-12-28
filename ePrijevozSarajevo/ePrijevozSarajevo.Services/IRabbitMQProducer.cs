namespace ePrijevozSarajevo.Services
{
    public interface IRabbitMQProducer
    {
        public void SendMessage<T>(T message);
    }
}
