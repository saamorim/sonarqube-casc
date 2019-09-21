using System;
using Xunit;
using SonarConfiguratorAsCode;
using YamlDotNet.Core;

namespace SonarConfigurationTest
{
    public class SonarConfigurationTest
    {
        [Fact]
        public void WhenParsingYamlItReturnValidLoglevel()
        {
            string yamlContent = @"
admin:
    system:
        loglevel: TRACE
            ";

            ConfigurationReader reader = new ConfigurationReader();
            var conf = reader.LoadFromString(yamlContent);

            Assert.Equal(CascLogLevel.TRACE, conf.Admin.System.Loglevel);
        }

        [Fact]
        public void WhenPassingInvalidLogLevelExceptionIsReturned()
        {
            string yamlContent = @"
admin:
    system:
        loglevel: SOMETHING
            ";

            ConfigurationReader reader = new ConfigurationReader();
            CascConfiguration conf;
            YamlException ex = Assert.Throws<YamlException>(() => conf = reader.LoadFromString(yamlContent));
            Assert.Matches("Exception during deserialization", ex.Message);
            Assert.Equal(4, ex.Start.Line);
        }
    }
}
