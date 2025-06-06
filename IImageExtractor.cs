namespace PdfApiGaisler.Services
{
    public interface IImageExtractor
    {
        byte[] ExtractImagesFromPage(iText.Kernel.Pdf.PdfPage page);
    }
}
