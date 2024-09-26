using KutuphaneProjesi.Infrastructure.Context;
using KutuphaneProjesi.Domain.Entities;
using KutuphaneProjesi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KutuphaneProjesi.Infrastructure.Repositories
{
    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        private readonly AppDbContext _context;

        public BookRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddRangeAsync(book);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Entry<Book>(book).State = EntityState.Deleted;
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetDefaultsAsync(Expression<Func<Book, bool>> expression)
        {
            return await _context.Books.Where(expression).ToListAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Entry<Book>(book).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
