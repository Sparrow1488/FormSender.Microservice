using FormSender.Microservice.Entities.Enums;
using System;

namespace FormSender.Microservice.ViewModels
{
    public class WebDocumentViewModel
    {
        public string Url { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public SourceType Type { get; set; } // TODO: сделать стрингом
        public DateTime CreatedAt { get; set; }
    }
}
