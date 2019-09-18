using System;
using Xunit;
using SonarConfiguration;

namespace SonarConfigurationTest
{
    public class SonarConfigurationTest
    {
        [Fact]
        public void IsTraceValid()
        {
            string yamlContent = @"
admin:
    system:
        loglevel: TRACE
            ";

            SonarConfigurator configurator = new SonarConfigurator();
            var conf = configurator.LoadConfig(yamlContent);

            Assert.Equal(CascLogLevel.TRACE, conf.Admin.System.Loglevel);
        }
    }
}
