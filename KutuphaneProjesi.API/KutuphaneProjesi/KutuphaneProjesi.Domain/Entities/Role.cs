using KutuphaneProjesi.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace KutuphaneProjesi.Domain.Entities
{
    public class Role : IdentityRole<Guid>, IBaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status? Status { get; set; }
    }
}
