using RabbitMQ.Client;
using ServisUser.Interface;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace ServisUser.Repository
{
    public class RabbitRepository : IRabbitMQRepository
    {
        private readonly IConfiguration _config;

        public RabbitRepository(IConfiguration config)
        {
            _config = config;
        }

        public void SendMessage(object enity)
        {
            var message = JsonSerializer.Serialize(enity);

            SendMessage(message);
        }

        public void SendMessage(string message)
        {

            string hostName = _config.GetSection("Host:Name").Value;
            string queue = _config.GetSection("Host:Queue").Value;

            var factory = new ConnectionFactory()
            {
                HostName = hostName
            };

            using (var connection = factory.CreateConnection())
            {
                using (var send = connection.CreateModel())
                {
                    send.QueueDeclare(queue: queue,
                           durable: false,
                           exclusive: false,
                           autoDelete: false,
                           arguments: null);

                    var body = Encoding.UTF8.GetBytes(message);

                    send.BasicPublish(exchange: "",
                                   routingKey: queue,
                                   basicProperties: null,
                                   body: body);
                }
            }
        }
    }
}
