using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneProjesi.Application.Validations
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;

            if (file != null && file.Length != 0)
            {
                List<string> validExtentions = new List<string>() { ".xlsx", ".txt", ".pdf" };

                string extention = Path.GetExtension(file.FileName);
                if (!validExtentions.Contains(extention))
                    return new ValidationResult($"Unsupported file format. Allowed formats are: ({string.Join(',', validExtentions)})");

                long size = file.Length;
                if (size > (5 * 1024 * 1024))
                    return new ValidationResult("Maximum size can be 5 mb");

                return ValidationResult.Success;
            }
            else
                return new ValidationResult("No file uploaded");
        }
    }
}
