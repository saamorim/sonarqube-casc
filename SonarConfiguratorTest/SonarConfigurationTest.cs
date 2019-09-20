using System;
using Xunit;
using SonarConfiguration;
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
            Assert.Equal("(Line: 4, Col: 19, Idx: 41) - (Line: 4, Col: 28, Idx: 50): Exception during deserialization", ex.Message);
        }
    }
}
