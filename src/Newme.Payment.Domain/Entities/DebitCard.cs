namespace Newme.Payment.Domain.Entities
{
    public class DebitCard : Card
    {
        public DebitCard(Guid id,
            string number, 
            string code, 
            DateTime expiration,
            Guid payerId,
            Guid purchaseId, 
            double amountToBePaid) : base(id, number, code, expiration, payerId, purchaseId, amountToBePaid)
        { }

        public override double CalculateDiscount() => AmountToBePaid - (AmountToBePaid * 0.1);
    }
}