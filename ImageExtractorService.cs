using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using PdfApiGaisler.Services;

namespace YourProjectNamespace.Services
{
    public class ImageExtractorService : IImageExtractor
    {
        public byte[] ExtractImagesFromPage(PdfPage page)
        {
            var listener = new ImageRenderListener();
            var processor = new PdfCanvasProcessor(listener);
            processor.ProcessPageContent(page);
            return listener.GetImageBytes();
        }

        private class ImageRenderListener : IEventListener
        {
            private byte[] _imageBytes;

            public void EventOccurred(IEventData data, EventType type)
            {
                if (type == EventType.RENDER_IMAGE && data is ImageRenderInfo renderInfo)
                {
                    var imageObject = renderInfo.GetImage();
                    _imageBytes = imageObject.GetImageBytes();
                }
            }

            public ICollection<EventType> GetSupportedEvents()
            {
                return new HashSet<EventType> { EventType.RENDER_IMAGE };
            }

            public byte[] GetImageBytes()
            {
                return _imageBytes;
            }
        }
    }
}

