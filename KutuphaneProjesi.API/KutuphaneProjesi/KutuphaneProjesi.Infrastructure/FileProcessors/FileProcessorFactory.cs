
namespace KutuphaneProjesi.Infrastructure.FileProcessors
{
    public class FileProcessorFactory
    {
        public static IFileProcessor CreateFileProcessor(string fileExtension)
        {
            return fileExtension.ToLower() switch
            {
                ".xlsx" => new ExcelFileProcessor(),
                ".txt" => new TextFileProcessor(),
                ".pdf" => new PdfFileProcessor(),
                _ => throw new NotSupportedException("File format not supported")
            };
        }
    }

}
