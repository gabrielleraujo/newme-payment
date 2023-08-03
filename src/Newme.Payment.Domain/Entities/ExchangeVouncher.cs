namespace Newme.Payment.Domain.Entities
{
    public class ExchangeVouncher: Entity
    {
        public ExchangeVouncher(
            Guid id,
            Guid payerId,
            double balance) : base(id)
        {
            Balance = balance;
            PayerId = payerId;
            ExpiryDate = DateTime.Now.AddMonths(6);
        }

        public Guid PayerId { get; private set; }
        public double Balance { get; private set; }
        public DateTime ExpiryDate { get; private set; }
    }
}