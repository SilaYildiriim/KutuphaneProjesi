using Microsoft.AspNetCore.Http;

namespace KutuphaneProjesi.Application.Models.Book
{
    public class SendBackBookDto
    {
        public string Name { get; set; }
        public string? AuthorName { get; set; }
        public string? Publisher { get; set; }
        public double? Price { get; set; }
        public IFormFile Image { get; set; }
    }
}
