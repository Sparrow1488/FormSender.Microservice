using FormSender.Microservice.Entities;
using FormSender.Microservice.Infrastructure.Mappers.Base;
using FormSender.Microservice.ViewModels;

namespace FormSender.Microservice.Infrastructure.Mappers
{
    public class WebDocumentMapperConfiguration : MapperConfigurationBase
    {
        public WebDocumentMapperConfiguration()
        {
            CreateMap<WebDocument, WebDocumentViewModel>().ReverseMap();
        }
    }
}
