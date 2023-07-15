namespace Newme.Payment.Domain.Entities
{
    public abstract class Card : PaymentBase
    {
        public Card(
            Guid id, 
            string number, 
            string agency,
            Guid payerId,
            Guid purchaseId, 
            double amountToBePaid) : base(id, payerId, purchaseId, amountToBePaid)
        {
            Number = number;
            Agency = agency;
        }

        public string Number { get; private set; }
        public string Agency { get; private set; }
    }
}