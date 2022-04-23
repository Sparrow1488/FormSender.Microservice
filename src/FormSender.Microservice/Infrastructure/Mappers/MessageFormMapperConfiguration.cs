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

            //CreateMap<CreateMessageFormViewModel, MessageForm>()
            //    .ForMember(form => form.Content,
            //        opt => opt.MapFrom(c => new Content()
            //        {
            //            Text = c.Text,
            //            Title = c.Title
            //        }));
        }
    }
}
