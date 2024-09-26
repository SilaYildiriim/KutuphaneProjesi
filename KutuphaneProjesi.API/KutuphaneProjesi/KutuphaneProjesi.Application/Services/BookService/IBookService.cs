using KutuphaneProjesi.Application.Models.Book;
using KutuphaneProjesi.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace KutuphaneProjesi.Application.Services.BookService
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<IEnumerable<Book>> GetBooksByTermAsync(string term);
        Task<Book> AddBookAsync(AddBookDto model);
        Task<Book> UpdateBookAsync(UpdateBookDto model, Guid id);
        Task<bool> DeleteBookAsync(Guid id);
    }
}
