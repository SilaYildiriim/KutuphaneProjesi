using AutoMapper;
using KutuphaneProjesi.Application.Models.Book;
using KutuphaneProjesi.Domain.Entities;
using KutuphaneProjesi.Domain.Enums;
using KutuphaneProjesi.Domain.Repositories;
using KutuphaneProjesi.Infrastructure.FileProcessors;
using Microsoft.AspNetCore.Http;

namespace KutuphaneProjesi.Application.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _bookRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepo bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public async Task<Book> AddBookAsync(AddBookDto model)
        {
            var fileExtension = Path.GetExtension(model.File.FileName);
            var fileProcessor = FileProcessorFactory.CreateFileProcessor(fileExtension);

            var book = await fileProcessor.ProcessFileAsync(model.File);

            book.Image = await ImageToByteArray(model.Image);
            book.CreatedDate = DateTime.Now;
            book.Status = Status.Active;

            await _bookRepo.AddAsync(book);
            return book;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var book = await _bookRepo.GetDefaultAsync(x => x.Id == id);

            if (book == null)
                return false;

            await _bookRepo.DeleteAsync(book);
            return true;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepo.GetAllAsync();
        }

        public async Task<Book> UpdateBookAsync(UpdateBookDto model, Guid id)
        {
            var book = await _bookRepo.GetDefaultAsync(x => x.Id == id);
            var backupImage = book.Image;

            if (book == null)
                return null;

            _mapper.Map(model, book);

            if (model.Image != null)
                book.Image = await ImageToByteArray(model.Image);
            else
                book.Image = backupImage;

            book.Status = Status.Modified;
            book.UpdatedDate = DateTime.Now;

            await _bookRepo.UpdateAsync(book);
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooksByTermAsync(string term)
        {
            var books = await _bookRepo.GetDefaultsAsync(x => x.Name.StartsWith(term));
            return books;
        }

        private async Task<string> ImageToByteArray(IFormFile image)
        {
            using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);

            if (memoryStream.Length < 2097152)
            {
                var ImageToByteArray = memoryStream.ToArray();
                var x = Convert.ToBase64String(ImageToByteArray);
                return x;
            }
            else
                return null;
        }
    }
}
