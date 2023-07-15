using MongoDB.Bson.Serialization;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Infrastructure.Persistence.Mappers
{
    public static class PaymentMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(PaymentBase)))
            {
                BsonClassMap.RegisterClassMap<PaymentBase>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.PayerId).SetElementName("payer_id");
                    classMap.MapMember(p => p.PurchaseId).SetElementName("purchase_id");
                    classMap.MapMember(p => p.Status).SetElementName("status");
                    classMap.MapMember(p => p.AmountToBePaid).SetElementName("amount_to_be_paid");
                });
            }
        }
    }
}