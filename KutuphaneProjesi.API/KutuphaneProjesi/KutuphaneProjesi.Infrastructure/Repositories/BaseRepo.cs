using KutuphaneProjesi.Domain.Entities;
using KutuphaneProjesi.Domain.Repositories;
using KutuphaneProjesi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KutuphaneProjesi.Infrastructure.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }
    }
}
