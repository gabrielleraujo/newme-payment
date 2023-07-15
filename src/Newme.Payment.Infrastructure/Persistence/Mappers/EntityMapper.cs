using MongoDB.Bson.Serialization;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Infrastructure.Persistence.Mappers
{
    public static class EntityMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Entity)))
            {
                BsonClassMap.RegisterClassMap<Entity>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapIdField(p => p.Id);
                    classMap.MapMember(p => p.CreateDate).SetElementName("create_date");
                    classMap.MapMember(p => p.UpdateDate).SetElementName("update_date");
                });
            }
        }
    }
}