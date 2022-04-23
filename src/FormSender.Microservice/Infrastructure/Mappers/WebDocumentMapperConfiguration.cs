using FormSender.Microservice.Entities;
using FormSender.Microservice.Entities.Enums;
using FormSender.Microservice.Infrastructure.Mappers.Base;
using FormSender.Microservice.ViewModels;
using System;

namespace FormSender.Microservice.Infrastructure.Mappers
{
    public class WebDocumentMapperConfiguration : MapperConfigurationBase
    {
        public WebDocumentMapperConfiguration()
        {
            CreateMap<WebDocument, WebDocumentViewModel>()
                .ForMember(doc => doc.StringType, opt => opt.MapFrom(doc => doc.Type.ToString()))
                .ReverseMap();
            CreateMap<CreateWebDocumentViewModel, WebDocument>()
                .ForMember(x => x.Url, src => src.MapFrom(y => y.Url))
                .ForMember(x => x.Type, src => src.MapFrom(y => Convert(y.TypeStringify)))
                .ForMember(x => x.Content, src => src.Ignore())
                .ForMember(x => x.Extension, src => src.Ignore())
                .ForMember(x => x.Id, src => src.Ignore())
                .ForMember(x => x.Size, src => src.Ignore());
        }

        private SourceType Convert(string sourceTypeStringify)
        {
            if (Enum.TryParse<SourceType>(sourceTypeStringify, ignoreCase: true, out var sourceType))
                return sourceType;
            return SourceType.Unknown;
        }
    }
}
