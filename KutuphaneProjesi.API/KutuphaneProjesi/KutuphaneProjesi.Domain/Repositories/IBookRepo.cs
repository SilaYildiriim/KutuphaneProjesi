using KutuphaneProjesi.Domain.Entities;
using System.Linq.Expressions;

namespace KutuphaneProjesi.Domain.Repositories
{
    public interface IBookRepo : IBaseRepo<Book>
    {
        Task AddAsync(Book books);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> GetDefaultsAsync(Expression<Func<Book, bool>> expression);
    }
}
