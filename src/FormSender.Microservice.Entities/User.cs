using FormSender.Microservice.Entities.Abstractions;

namespace FormSender.Microservice.Entities
{
    public class User : Identity
    {
        public string Login { get; set; }
    }
}
