using System;
using System.ComponentModel.DataAnnotations;

namespace FormSender.Microservice.Entities.Abstractions
{
    public abstract class Identity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
