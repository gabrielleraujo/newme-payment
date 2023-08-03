using System.Linq.Expressions;
using MongoDB.Driver;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Messaging;
using Newme.Payment.Domain.Repositories;

namespace Newme.Payment.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly IMongoCollection<T> _collection;
        public BaseRepository(IMongoDatabase database, ICollection collection)
        {
            _collection = database.GetCollection<T>(collection.Get[typeof(T)]);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _collection.Find(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task AddAsync(T value) 
        {
            await _collection.InsertOneAsync(value);
        }

        public async Task UpdateAsync<TValueUpdate>(
            Guid id, TValueUpdate newValue, Expression<Func<T, TValueUpdate>> expression) 
        {
            var filter = Builders<T>.Filter
                .Eq(entity => entity.Id, id);
                
            var update = Builders<T>.Update
                .Set<TValueUpdate>(expression, newValue)
                .Set(x => x.UpdateDate, DateTime.Now);

            var result = await _collection.UpdateManyAsync(filter, update);
            if (result.MatchedCount == 0) throw new Exception("Error on update.");
        }
    }
}
