using MongoDB.Bson.Serialization;
using Newme.Payment.Infrastructure.Persistence.Models;

namespace Newme.Payment.Infrastructure.Persistence.Mappers
{
    public static class StatusMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(PaymentStatus)))
            {
                BsonClassMap.RegisterClassMap<PaymentStatus>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.MapIdField(p => p.Id);
                    classMap.MapMember(p => p.Status).SetElementName("status");
                    classMap.MapMember(p => p.Description).SetElementName("description");
                });
            }
        }
    }
}