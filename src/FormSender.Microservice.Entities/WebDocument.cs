using FormSender.Microservice.Entities.Abstractions;
using FormSender.Microservice.Entities.Enums;
using System;

namespace FormSender.Microservice.Entities
{
    public class WebDocument : Identity
    {
        public string Url { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public SourceType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public Content Content { get; set; }
    }
}
