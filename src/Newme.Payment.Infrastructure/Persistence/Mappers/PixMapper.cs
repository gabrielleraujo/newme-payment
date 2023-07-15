using MongoDB.Bson.Serialization;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Infrastructure.Persistence.Mappers
{
    public static class PixMapper
    {
        public  static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Pix)))
            {
                BsonClassMap.RegisterClassMap<Pix>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.CopyPaste).SetElementName("copy_paste");
                    classMap.MapMember(p => p.DueDate).SetElementName("due_date");
                });
            }
        }
    }
}