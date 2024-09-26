using KutuphaneProjesi.Domain.Entities;
using KutuphaneProjesi.Domain.Repositories;
using KutuphaneProjesi.Infrastructure.Context;

namespace KutuphaneProjesi.Infrastructure.Repositories
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }
    }
}
