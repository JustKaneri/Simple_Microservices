using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ServisOrder.Interface;
using ServisOrder.Model;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;

namespace ServisOrder.BackgroundServis
{
    public class UserRabbitServis : BackgroundService
    {
        private readonly IConnection _connect;
        private readonly IModel _model;
        private readonly string _queue;
        private readonly ICasheRepository<UserCashe> _repository;

        public UserRabbitServis(IConfiguration configuration, ICasheRepository<UserCashe> repository)
        {
            _queue = configuration.GetSection("User:Queue").Value.ToString();
            var factory = new ConnectionFactory()
            {
                HostName = configuration.GetSection("User:Host").Value
            };

            _connect = factory.CreateConnection();
            _model = _connect.CreateModel();

            _model.QueueDeclare(queue: _queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new  EventingBasicConsumer(_model);

            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

                _repository.CreateEnity(int.Parse(content));
                Console.WriteLine(content);
                _model.BasicAck(ea.DeliveryTag, false);
            };

            _model.BasicConsume(_queue, false, consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _model.Close();
            _connect.Close();
            base.Dispose();
        }
    }
}
