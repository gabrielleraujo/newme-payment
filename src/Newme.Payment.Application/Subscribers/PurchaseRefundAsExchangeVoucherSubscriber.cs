using System.Text;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Newme.Payment.Domain.Messaging;
using Newme.Payment.Application.Subscribers.Events;
using Newme.Payment.Application.Commands.RegisterVouncherForPayer;

namespace Newme.Payment.Application.Subscribers.PurchaseRefundAsExchangeVoucher
{
    public class PurchaseRefundAsExchangeVoucherSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "payment-service/purchase-refund-as-exchange-voucher";
        private const string RoutingKeySubscribe = "purchase-refund-as-exchange-voucher";
        private readonly IServiceProvider _serviceProvider;
        private const string TrackingsExchange = "payment-service";
 
        public PurchaseRefundAsExchangeVoucherSubscriber(IServiceProvider serviceProvider)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
 
            _connection = connectionFactory.CreateConnection("purchase-refund-as-exchange-voucher-consumer");
 
            _channel = _connection.CreateModel();
 
            _channel.QueueDeclare(
                queue: Queue,
                durable: true,
                exclusive: false,
                autoDelete: false);
 
            _channel.QueueBind(Queue, TrackingsExchange, RoutingKeySubscribe);
 
            _serviceProvider = serviceProvider;
        }
 
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
 
            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var @event = JsonConvert.DeserializeObject<PurchaseRefundAsExchangeVoucherReceivedEvent>(contentString);
 
                Console.WriteLine($"Message payment resolved purchase order event is received with purchase id: {@event!.PurchaseId}");
 
                Complete(@event).Wait();
 
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
 
            _channel.BasicConsume(Queue, false, consumer);
 
            return Task.CompletedTask;
        }
 
        public async Task Complete(PurchaseRefundAsExchangeVoucherReceivedEvent @event)
        {
            using var scope = _serviceProvider.CreateScope();

            var messageBus = scope.ServiceProvider.GetRequiredService<IMessageBusServer>();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var command = new RegisterVouncherForPayerCommand(@event);
            var response = await mediator.Send(command);
        }
    }
}
