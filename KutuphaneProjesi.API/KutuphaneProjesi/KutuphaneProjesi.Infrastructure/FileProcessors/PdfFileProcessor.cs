using KutuphaneProjesi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace KutuphaneProjesi.Infrastructure.FileProcessors
{
    public class PdfFileProcessor : IFileProcessor
    {
        public async Task<Book> ProcessFileAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            using var pdfReader = new PdfReader(stream);
            using var pdfDocument = new PdfDocument(pdfReader);
            var page = pdfDocument.GetPage(1);
            var text = PdfTextExtractor.GetTextFromPage(page);

            // Metni satırlara ayır
            var lines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(line => line.Trim())
                            .ToArray();

            // Kelime ayırma işlemi
            var fields = lines.SelectMany(line =>
                line.Contains(",")
                    ? line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(f => f.Trim())
                    : Regex.Split(line, @"[\s{2,}]+")
                        .Where(f => !string.IsNullOrWhiteSpace(f))
            ).ToList();

            var book = new Book
            {
                AuthorName = fields.ElementAtOrDefault(0) ?? "No author name available",
                Name = fields.ElementAtOrDefault(1) ?? "No book name available",
                Publisher = fields.ElementAtOrDefault(2) ?? "No publisher available",
                Price = fields.Count > 3 && double.TryParse(fields[3], NumberStyles.Any, CultureInfo.InvariantCulture, out double price) ? price : 0.0
            };

            return book;
        }
    }
}
