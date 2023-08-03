namespace Newme.Payment.Domain.Entities
{
    public class CreditCard : Card
    {
        public CreditCard(
            Guid id,
            string number, 
            string code, 
            DateTime expiration,
            int numberInstallments, 
            int numberInstallmentsPaid, 
            double installmentValue, 
            double totalInterest,
            Guid payerId,
            Guid purchaseId, 
            double amountToBePaid) : base(id, number, code, expiration, payerId, purchaseId, amountToBePaid)
        {
            NumberInstallments = numberInstallments;
            NumberInstallmentsPaid = numberInstallmentsPaid;
            InstallmentValue = installmentValue;
            TotalInterest = totalInterest;
        }

        public int NumberInstallments { get; private set; }
        public int NumberInstallmentsPaid { get; private set; }
        public double InstallmentValue { get; private set; }
        public double TotalInterest { get; private set; }

        public override double CalculateDiscount() => AmountToBePaid;
    }
}