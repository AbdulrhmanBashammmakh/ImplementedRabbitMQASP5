namespace UserService.MQ
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}