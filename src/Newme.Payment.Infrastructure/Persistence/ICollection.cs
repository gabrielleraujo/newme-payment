namespace Newme.Payment.Infrastructure.Persistence
{
    public interface ICollection
    {
        IReadOnlyDictionary<Type, string> Get { get; }
    }
}