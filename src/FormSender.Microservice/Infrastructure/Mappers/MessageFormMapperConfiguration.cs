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
            CreateMap<CreateMessageFormViewModel, MessageForm>()
                .ForMember(x => x.Content, src => src.MapFrom(y => new Content()
                {
                    Title = y.Title,
                    Text = y.Text
                }))
                .ForMember(x => x.CreatedAt, src => src.Ignore())
                .ForMember(x => x.UpdatedAt, src => src.Ignore())
                .ForMember(x => x.Id, src => src.Ignore());
        }
    }
}
