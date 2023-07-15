using Newme.Payment.Application.Commands.ChangePaymentStatus;
using Newme.Payment.Application.InputModels;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Application.Utils
{
    public static class PaymentType
    {
        public static IReadOnlyDictionary<EPaymentType, Type> ChangePaymentStatusCommand => new Dictionary<EPaymentType, Type>()
        {
            { EPaymentType.Pix, typeof(ChangePaymentStatusCommand<Pix>) },
            { EPaymentType.DebitCard, typeof(ChangePaymentStatusCommand<DebitCard>) },
            { EPaymentType.CreditCard, typeof(ChangePaymentStatusCommand<CreditCard>) },
        };
    }
}