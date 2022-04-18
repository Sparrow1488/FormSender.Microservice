using FormSender.Microservice.Entities.Enums;

namespace FormSender.Microservice.ViewModels
{
    public class WebDocumentViewModel
    {
        public string Url { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public SourceType Type { get; set; }
        public string StringType { get; set; }
    }
}
