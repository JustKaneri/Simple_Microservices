using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using ServisOrder.Servises;
using System.Text;

namespace ServisOrder.BackgroundServis
{
    public class ProductRabbitServis : BackgroundService
    {
        private readonly IConnection _connect;
        private readonly IModel _model;
        private readonly string _queue;
        private readonly CreatorSingeltonServis _repository;
        private static EventingBasicConsumer consumer;

        public ProductRabbitServis(IConfiguration configuration, CreatorSingeltonServis repository)
        {
            _queue = configuration.GetSection("Product:Queue").Value.ToString();
            var factory = new ConnectionFactory()
            {
                HostName = configuration.GetSection("Product:Host").Value
            };

            _connect = factory.CreateConnection();
            _model = _connect.CreateModel();

            _model.QueueDeclare(queue: _queue, durable: false, exclusive: false, autoDelete: false, arguments: null);


            _repository = repository;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            consumer = new EventingBasicConsumer(_model);

            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

                _repository.CreateProductCashe(int.Parse(content));
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
