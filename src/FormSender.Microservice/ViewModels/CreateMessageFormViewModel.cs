using System.Collections.Generic;

namespace FormSender.Microservice.ViewModels
{
    public class CreateMessageFormViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IEnumerable<CreateWebDocumentViewModel> Documents { get; set; }
    }
}
