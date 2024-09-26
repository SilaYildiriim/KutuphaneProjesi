using KutuphaneProjesi.Domain.Enums;

namespace KutuphaneProjesi.Domain.Entities
{
    public interface IBaseEntity 
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status? Status { get; set; }
    }
}
