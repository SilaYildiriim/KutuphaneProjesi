using KutuphaneProjesi.Domain.Enums;

namespace KutuphaneProjesi.Domain.Entities
{
    public class Book : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? AuthorName { get; set; }
        public string? Publisher { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status? Status { get; set; }
    }
}
