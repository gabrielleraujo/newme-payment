using MongoDB.Bson.Serialization;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Infrastructure.Persistence.Mappers
{
    public static class CardMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Card)))
            {
                BsonClassMap.RegisterClassMap<Card>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.Number).SetElementName("number");
                    classMap.MapMember(p => p.Code).SetElementName("code");
                    classMap.MapMember(p => p.Expiration).SetElementName("expiration");
                });
            }
        }
    }
}