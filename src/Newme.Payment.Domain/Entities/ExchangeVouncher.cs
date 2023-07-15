namespace Newme.Payment.Domain.Entities
{
    public class ExchangeVouncher: Entity
    {
        public ExchangeVouncher(
            Guid id,
            Guid payerId,
            double balance,
            DateTime expiryDate) : base(id)
        {
            Balance = balance;
            ExpiryDate = expiryDate;
            PayerId = payerId;
        }

        public Guid PayerId { get; private set; }
        public double Balance { get; private set; }
        public DateTime ExpiryDate { get; private set; }
    }
}