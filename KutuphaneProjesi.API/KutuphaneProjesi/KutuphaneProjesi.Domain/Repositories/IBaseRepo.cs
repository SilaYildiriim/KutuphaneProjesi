using KutuphaneProjesi.Domain.Entities;
using System.Linq.Expressions;

namespace KutuphaneProjesi.Domain.Repositories
{
    public interface IBaseRepo<T> where T : IBaseEntity 
    {
        Task<T> GetDefaultAsync(Expression<Func<T, bool>> expression);
    }
}
