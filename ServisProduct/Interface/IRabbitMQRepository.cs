namespace ServisProduct.Interface
{
    public interface IRabbitMQRepository
    {
        public void SendMessage(object enity);

        public void SendMessage(string message);
    }
}
