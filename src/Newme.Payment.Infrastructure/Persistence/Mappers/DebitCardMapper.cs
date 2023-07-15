using MongoDB.Bson.Serialization;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Infrastructure.Persistence.Mappers
{
    public static class DebitCardMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(DebitCard)))
            {
                BsonClassMap.RegisterClassMap<DebitCard>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}