using FluentValidation.Results;
using MediatR;

namespace Newme.Payment.Application.Commands.RegisterPixPayment
{
    public class RegisterPixPaymentCommand : RegisterPaymentCommand, IRequest<ValidationResult>
    {
        public RegisterPixPaymentCommand(
            Guid payerId, 
            Guid purchaseId, 
            double amountToBePaid,
            string copyPaste,
            DateTime dueDate) : base(payerId, purchaseId, amountToBePaid)
        {
            CopyPaste = copyPaste;
            DueDate = dueDate;
        }

        public string CopyPaste { get; private set; }
        public DateTime DueDate { get; private set; }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new RegisterPixPaymentCommandValidation().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
