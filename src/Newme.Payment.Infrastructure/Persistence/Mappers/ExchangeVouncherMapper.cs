using MongoDB.Bson.Serialization;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Infrastructure.Persistence.Mappers
{
    public static class ExchangeVouncherMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(ExchangeVouncher)))
            {
                BsonClassMap.RegisterClassMap<ExchangeVouncher>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.PayerId).SetElementName("payer_id");
                    classMap.MapMember(p => p.Balance).SetElementName("balance");
                    classMap.MapMember(p => p.ExpiryDate).SetElementName("expiry_date");
                });
            }
        }
    }
}