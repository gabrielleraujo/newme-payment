using Newme.Payment.Domain.Entities;
using FluentValidation.Results;
using MediatR;

namespace Newme.Payment.Application.Commands.ChangePaymentStatus
{
    public class ChangePaymentStatusCommand<T> : Command, IRequest<ValidationResult> where T : PaymentBase
    {
        public ChangePaymentStatusCommand(
            Guid id,
            EPaymentStatus status)
        {
            Id = id;
            Status = status;
        }

        public Guid Id { get; private set; }
        public EPaymentStatus Status { get; private set; }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new ChangePaymentStatusCommand().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
