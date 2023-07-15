namespace Newme.Payment.Infrastructure.Messaging
{
    public interface IMessageBusServer
    {
        void Publish(object data, string routingKey);
    }
}