using KutuphaneProjesi.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace KutuphaneProjesi.Domain.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status? Status { get; set; }
    }
}
