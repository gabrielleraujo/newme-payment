using FluentValidation.Results;
using MediatR;

namespace Newme.Payment.Application.Commands.RegisterDebitCardPayment
{
    public class RegisterDebitCardPaymentCommand : RegisterCardPaymentCommand, IRequest<ValidationResult>
    {
        public RegisterDebitCardPaymentCommand(
            Guid payerId, 
            Guid purchaseId, 
            double amountToBePaid,
            string number,
            string agency) : base(payerId, purchaseId, amountToBePaid, number, agency)
        {
        }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new RegisterCreditPaymentCommandValidation().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
