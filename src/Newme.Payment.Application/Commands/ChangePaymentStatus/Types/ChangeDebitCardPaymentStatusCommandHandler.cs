using Microsoft.Extensions.Logging;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Repositories;

namespace Newme.Payment.Application.Commands.ChangePaymentStatus.Types
{
    public class ChangeDebitCardPaymentStatusCommandHandler : ChangePaymentStatusCommandHandler<DebitCard>
    {
        public ChangeDebitCardPaymentStatusCommandHandler(ILogger<ChangePaymentStatusCommandHandler<DebitCard>> logger, IBaseRepository<DebitCard> repository) : base(logger, repository)
        {
        }
    }
}