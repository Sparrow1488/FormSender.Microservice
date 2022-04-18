using System;

namespace FormSender.Microservice.Entities.Abstractions
{
    public interface IAuditable
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
