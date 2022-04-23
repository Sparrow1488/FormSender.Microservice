using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FormSender.Microservice.ViewModels
{
    public class CreateContentViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IEnumerable<CreateWebDocumentViewModel> Documents { get; set; }
    }
}
