using FormSender.Microservice.Entities;
using FormSender.Microservice.Infrastructure.Mappers.Base;
using FormSender.Microservice.ViewModels;

namespace FormSender.Microservice.Infrastructure.Mappers
{
    public class ContentMapperConfiguration : MapperConfigurationBase
    {
        public ContentMapperConfiguration()
        {
            CreateMap<Content, ContentViewModel>().ReverseMap();
        }
    }
}
