using FormSender.Microservice.Infrastructure.Mappers.Base;
using NUnit.Framework;

namespace FormSender.Microservice.Tests
{
    public class MapperRegistrationTests
    {
        [Test]
        public void IsAssertConfigurationValid_NoExceptions()
        {
            var mapperConfiguration = MapperRegistration.GetMapperConfiguration();
            mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}