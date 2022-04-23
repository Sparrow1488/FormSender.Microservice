using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FormSender.Microservice.ViewModels
{
    public class CreateWebDocumentViewModel
    {
        [Url(ErrorMessage = "Web document URL not required!")]
        public string Url { get; set; }
        public string TypeStringify { get; set; }
    }
}
