using FormSender.Microservice.Entities.Abstractions;
using System;

namespace FormSender.Microservice.Entities
{
    public class MessageForm : Identity, IAuditable
    {
        public Content Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
