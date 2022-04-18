using DictinaryPower.DAL.Interfaces.Entitiyes.Base;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DictinaryPower.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class ,IEntity, new()
    {
        IQueryable<T> Items { get; }

        T Get(int id);
        T Add(T entity);
        T Update(T entity);
        void Remove(int id);

        Task<T> GetAsync(int id, CancellationToken cancel = default);
        Task<T> AddAsync(T entity, CancellationToken cancel = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancel = default);
        void RemoveAsync(int id, CancellationToken cancel = default);
    }
}
