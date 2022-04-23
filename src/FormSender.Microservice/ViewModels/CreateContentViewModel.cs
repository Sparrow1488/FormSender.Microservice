using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FormSender.Microservice.ViewModels
{
    public class CreateContentViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public IEnumerable<CreateWebDocumentViewModel> Documents { get; set; }
    }
}
