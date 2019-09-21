using System;
using Xunit;
using SonarConfiguratorAsCode;
using YamlDotNet.Core;

namespace SonarConfigurationTest
{
    public class SonarConfigurationTest
    {
        [Fact]
        public void WhenParsingValidLoglevelThenIsReadsCorrectly()
        {
            var conf = ParseCascFromString(@"
admin:
    system:
        loglevel: TRACE
            ");

            Assert.Equal(CascLogLevel.TRACE, conf.Admin.System.Loglevel);
        }

        [Fact]
        public void WhenParsingInvalidLogLevelThenExceptionIsReturned()
        {
            YamlException ex = Assert.Throws<YamlException>(() => {
                var conf = ParseCascFromString(@"
admin:
    system:
        loglevel: SOMETHING
            ");
            });
            Assert.Matches("Exception during deserialization", ex.Message);
            Assert.Equal(4, ex.Start.Line);
        }


        [Fact]
        public void WhenParsingOneGroupThenOneGroupIsRead()
        {
            var conf = ParseCascFromString(@"
admin:
    acl:
        groups:
            - name: group1
              description: group description
              permissions:
                - admin
                - profileadmin
                - gateadmin
                - scan
                - provisioning
            ");

            Assert.Equal(1, conf.Admin.Acl.Groups.Length);
        }

        private CascConfiguration ParseCascFromString(string yamlContent) {
            ConfigurationReader reader = new ConfigurationReader();

            var conf = reader.LoadFromString(yamlContent);

            return conf;
        }
    }
}
