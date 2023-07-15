using Microsoft.Extensions.Logging;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Repositories;

namespace Newme.Payment.Application.Commands.ChangePaymentStatus.Types
{
    public class ChangePixPaymentStatusCommandHandler : ChangePaymentStatusCommandHandler<Pix>
    {
        public ChangePixPaymentStatusCommandHandler(ILogger<ChangePaymentStatusCommandHandler<Pix>> logger, IBaseRepository<Pix> repository) : base(logger, repository)
        {
        }
    }
}