namespace Newme.Payment.Domain.Entities
{
    public abstract class Card : PaymentBase
    {
        public Card(
            Guid id, 
            string number, 
            string code,
            DateTime expiration,
            Guid payerId,
            Guid purchaseId, 
            double amountToBePaid) : base(id, payerId, purchaseId, amountToBePaid)
        {
            Number = number;
            Code = code;
            Expiration = expiration;
        }

        public string Number { get; private set; }
        public string Code { get; private set; }
        public DateTime Expiration { get; private set; }
    }
}