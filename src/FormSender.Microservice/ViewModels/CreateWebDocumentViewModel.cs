using FormSender.Microservice.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FormSender.Microservice.ViewModels
{
    public class CreateWebDocumentViewModel
    {
        [Url(ErrorMessage = "Web document URL not valid")]
        public string Url { get; set; }
        [SourceType(ErrorMessage = "Web document source type not valid")]
        public string TypeStringify { get; set; }
    }

    public class SourceTypeAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (Enum.TryParse<SourceType>(value.ToString(), ignoreCase: true, out var _))
                return true;
            return false;
        }
    }
}
