using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Messaging;

namespace Newme.Payment.Infrastructure.Persistence
{
    public class Collection : ICollection
    {
        IReadOnlyDictionary<Type, string> ICollection.Get => new Dictionary<Type, string>() {
            { typeof(CreditCard), "credit_card" },
            { typeof(DebitCard), "debit_card" },
            { typeof(Pix), "pix" },
            { typeof(ExchangeVouncher), "exchange_vounchers" },
            { typeof(EPaymentStatus), "status" },
        };
    }
}