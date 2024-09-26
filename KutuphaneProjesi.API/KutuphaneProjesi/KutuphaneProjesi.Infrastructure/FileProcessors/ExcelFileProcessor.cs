using KutuphaneProjesi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;

namespace KutuphaneProjesi.Infrastructure.FileProcessors
{
    public class ExcelFileProcessor : IFileProcessor
    {
        public async Task<Book> ProcessFileAsync(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var stream = file.OpenReadStream();
            using var package = new ExcelPackage(stream);
            var worksheet = package.Workbook.Worksheets.First();

            var book = new Book
            {
                AuthorName = worksheet.Cells[1, 1].Text.Trim(),
                Name = worksheet.Cells[1, 2].Text.Trim(),
                Publisher = worksheet.Cells[1, 3].Text.Trim(),
                Price = double.TryParse(worksheet.Cells[1, 4].Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double price) ? price : 0.0
            };

            if (string.IsNullOrWhiteSpace(book.AuthorName))
                book.AuthorName = "No author name available";
            if (string.IsNullOrWhiteSpace(book.Name))
                book.Name = "No book name available";
            if (string.IsNullOrWhiteSpace(book.Publisher))
                book.Publisher = "No publisher available";

            return book;
        }
    }

}
