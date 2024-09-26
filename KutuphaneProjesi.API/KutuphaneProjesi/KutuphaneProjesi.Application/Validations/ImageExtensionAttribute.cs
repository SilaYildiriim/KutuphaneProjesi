using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneProjesi.Application.Validations
{
    public class ImageExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile image = value as IFormFile;

            if (image != null && image.Length != 0)
            {
                List<string> validExtentions = new List<string>() { ".jpg", ".jpeg", ".png" };

                string extention = Path.GetExtension(image.FileName);
                if (!validExtentions.Contains(extention))
                    return new ValidationResult($"Unsupported image format. Allowed formats are: ({string.Join(',', validExtentions)})");

                long size = image.Length;
                if (size > (2 * 1024 * 1024))
                    return new ValidationResult("Maximum size can be 2 mb");

                return ValidationResult.Success;
            }
            else
                return new ValidationResult("No image uploaded");
        }
    }
}
