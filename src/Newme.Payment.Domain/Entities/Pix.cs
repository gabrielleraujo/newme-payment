namespace Newme.Payment.Domain.Entities
{
    public class Pix : PaymentBase
    {
        public Pix(
            Guid id, 
            string copyPaste, 
            DateTime dueDate,
            Guid payerId,
            Guid purchaseId, 
            double amountToBePaid)
            : base(id, payerId, purchaseId, amountToBePaid)
        {
            CopyPaste = copyPaste;
            DueDate = dueDate;
        }

        public string CopyPaste { get; private set; }
        public DateTime DueDate { get; private set; }

        public override double CalculateDiscount() => AmountToBePaid - (AmountToBePaid * 0.05);
    }
}