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
            var types = typeof(Program).Assembly.GetTypes();
            var mapperInterfaceType = typeof(IAutoMapper);
            var automappers = types.Where(type => type.GetInterfaces().Contains(mapperInterfaceType) && !type.IsAbstract);
            return automappers.ToArray();
        }
    }
}
