using FormSender.Microservice.Entities.Abstractions;
using System;

namespace FormSender.Microservice.Entities
{
    public class MessageForm : Identity, IAuditable
    {
        public MessageForm() { }
        public MessageForm(
            Guid id = default,
            Content content = default,
            DateTime createdAt = default,
            DateTime updatedAt = default)
        {
            Id = id;
            Content = content;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Content Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid Id { get; }
    }
}
