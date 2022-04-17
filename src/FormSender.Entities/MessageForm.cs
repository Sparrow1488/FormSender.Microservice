using FormSender.Microservice.Entities.Abstractions;
using System;

namespace FormSender.Microservice.Entities
{
    public class MessageForm : Identity
    {
        public Content Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
