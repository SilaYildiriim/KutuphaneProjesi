using KutuphaneProjesi.Domain.Entities;
using KutuphaneProjesi.Domain.Repositories;
using KutuphaneProjesi.Infrastructure.Context;

namespace KutuphaneProjesi.Infrastructure.Repositories
{
    public class UserRoleRepo : BaseRepo<UserRole>, IUserRoleRepo
    {
        public UserRoleRepo(AppDbContext context) : base(context)
        {
        }
    }
}
