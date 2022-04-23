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
            CreateMap<CreateContentViewModel, Content>()
                .ForMember(x => x.Documents, src => src.MapFrom(y => y.Documents))
                .ForMember(x => x.Title, src => src.MapFrom(y => y.Title))
                .ForMember(x => x.Text, src => src.MapFrom(y => y.Text))
                .ForMember(x => x.MessageForm, src => src.Ignore())
                .ForMember(x => x.Id, src => src.Ignore());
        }
    }
}
