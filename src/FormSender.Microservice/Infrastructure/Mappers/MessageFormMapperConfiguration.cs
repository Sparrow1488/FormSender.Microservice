using FormSender.Microservice.Entities;
using FormSender.Microservice.Infrastructure.Mappers.Base;
using FormSender.Microservice.ViewModels;

namespace FormSender.Microservice.Infrastructure.Mappers
{
    public class MessageFormMapperConfiguration : MapperConfigurationBase
    {
        public MessageFormMapperConfiguration()
        {
            CreateMap<MessageForm, MessageFormViewModel>().ReverseMap();
            CreateMap<Content, MessageForm>()
                .ForMember(x => x.Content, src => src.MapFrom(y => y))
                .ForMember(x => x.CreatedAt, src => src.Ignore())
                .ForMember(x => x.UpdatedAt, src => src.Ignore())
                .ForMember(x => x.Id, src => src.Ignore());
        }
    }
}
