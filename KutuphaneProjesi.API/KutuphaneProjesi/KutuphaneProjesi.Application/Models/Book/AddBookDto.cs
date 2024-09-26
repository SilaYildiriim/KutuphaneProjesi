using KutuphaneProjesi.Application.Validations;
using Microsoft.AspNetCore.Http;

namespace KutuphaneProjesi.Application.Models.Book
{
    public class AddBookDto
    {
        [FileExtension]
        public IFormFile File { get; set; }

        [ImageExtension]
        public IFormFile Image { get; set; }
    }
}
