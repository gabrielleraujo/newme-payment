namespace Newme.Payment.Domain.Entities
{
    public class DebitCard : Card
    {
        public DebitCard(Guid id,
            string number, 
            string agency,
            Guid payerId,
            Guid purchaseId, 
            double amountToBePaid) : base(id, number, agency, payerId, purchaseId, amountToBePaid)
        { }

        public override double CalculateDiscount() => AmountToBePaid - (AmountToBePaid * 0.1);
    }
}