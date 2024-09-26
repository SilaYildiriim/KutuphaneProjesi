using KutuphaneProjesi.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace KutuphaneProjesi.Infrastructure.FileProcessors
{
    public interface IFileProcessor
    {
        Task<Book> ProcessFileAsync(IFormFile file);
    }

}
