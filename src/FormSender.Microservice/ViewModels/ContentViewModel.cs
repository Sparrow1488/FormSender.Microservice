using System.Collections.Generic;

namespace FormSender.Microservice.ViewModels
{
    public class ContentViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IEnumerable<WebDocumentViewModel> Documents { get; set; }
    }
}
