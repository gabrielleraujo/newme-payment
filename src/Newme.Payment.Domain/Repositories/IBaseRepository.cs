using System.Linq.Expressions;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Domain.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T value);
        Task UpdateAsync<TValueUpdate>(Guid id, TValueUpdate newValue, Expression<Func<T, TValueUpdate>> expression);
    }
}
