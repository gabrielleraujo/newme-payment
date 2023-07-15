using FluentValidation.Results;
using MediatR;
using Newme.Payment.Application.Subscribers.Events;

namespace Newme.Payment.Application.Commands.RegisterVouncherForPayer
{
    public class RegisterVouncherForPayerCommand : Command, IRequest<ValidationResult>
    {
        public RegisterVouncherForPayerCommand(
            PurchaseRefundAsExchangeVoucherReceivedEvent @event)
        {
            Id = Guid.NewGuid();
            Event = @event;
        }

        public Guid Id { get; private set; }
        public PurchaseRefundAsExchangeVoucherReceivedEvent Event { get; private set; }
    }
}
