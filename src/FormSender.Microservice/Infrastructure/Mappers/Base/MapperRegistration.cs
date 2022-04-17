using AutoMapper;
using System;
using System.Linq;

namespace FormSender.Microservice.Infrastructure.Mappers.Base
{
    public static class MapperRegistration
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(config =>
            {
                foreach (var profile in GetProfiles().Select(p => (Profile)Activator.CreateInstance(p)))
                {
                    config.AddProfile(profile);
                }
            });
            return configuration;
        }

        private static Type[] GetProfiles()
        {
            var automappers = typeof(Startup).Assembly
                                             .GetTypes()
                                             .Where(type => type.IsAssignableFrom(typeof(IAutoMapper)) &&
                                                            !type.IsAbstract);
            return automappers.ToArray();
        }
    }
}
