using Microsoft.Extensions.Logging;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Repositories;
using Newme.Payment.Domain.Messaging;

namespace Newme.Payment.Application.Commands.ChangePaymentStatus.Types
{
    public class ChangeCreditCardPaymentStatusCommandHandler : ChangePaymentStatusCommandHandler<CreditCard>
    {
        public ChangeCreditCardPaymentStatusCommandHandler(
            ILogger<ChangePaymentStatusCommandHandler<CreditCard>> logger, 
            IBaseRepository<CreditCard> repository,
            IMessageBusServer messageBus) : base(logger, repository, messageBus)
        {
        }
    }
}