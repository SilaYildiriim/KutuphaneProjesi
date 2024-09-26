using KutuphaneProjesi.Domain.Entities;
using KutuphaneProjesi.Domain.Repositories;
using KutuphaneProjesi.Infrastructure.Context;

namespace KutuphaneProjesi.Infrastructure.Repositories
{
    public class RoleRepo : BaseRepo<Role>, IRoleRepo
    {
        public RoleRepo(AppDbContext context) : base(context)
        {
        }
    }
}
