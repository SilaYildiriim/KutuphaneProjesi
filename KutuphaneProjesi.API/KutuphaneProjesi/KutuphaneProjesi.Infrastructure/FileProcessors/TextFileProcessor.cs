using KutuphaneProjesi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Text.RegularExpressions;

namespace KutuphaneProjesi.Infrastructure.FileProcessors
{
    public class TextFileProcessor : IFileProcessor
    {
        public async Task<Book> ProcessFileAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);
            var line = await reader.ReadLineAsync();

            if (line == null)
                return null;

            line = line.Trim();

            List<string> fields;

            if (line.Contains(","))
            {
                fields = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(f => f.Trim()).ToList();
            }
            else
            {
                fields = Regex.Split(line, @"[\s{2,}]+")
                              .Where(f => !string.IsNullOrWhiteSpace(f)).ToList();
            }

            if (fields.Count >= 4)
            {
                return new Book
                {
                    AuthorName = (fields[0] ?? "No author name available"),
                    Name = (fields[1] ?? "No author name available"),
                    Publisher = (fields[2] ?? "No author name available"),
                    Price = double.Parse(fields[3], CultureInfo.InvariantCulture)
                };
            }
            return null;
        }
    }

}
