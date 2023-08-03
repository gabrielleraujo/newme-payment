namespace Newme.Payment.Domain.Messaging
{
    public interface ICollection
    {
        IReadOnlyDictionary<Type, string> Get { get; }
    }
}