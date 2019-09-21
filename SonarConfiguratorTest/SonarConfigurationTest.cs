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

            Assert.Single(conf.Admin.Acl.Groups);
            Assert.Equal(5, conf.Admin.Acl.Groups[0].Permissions.Length);

        }


        [Fact]
        public void WhenParsingTwoGroupThenTwoGroupAreReturned()
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
            - name: group2
              description: group2 description
            ");

            Assert.Equal(2, conf.Admin.Acl.Groups.Length);
        }



        [Fact]
        public void WhenParsingAGroupContentIsOk()
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

            var group = conf.Admin.Acl.Groups[0];
            Assert.Equal("group1", group.Name);
            Assert.Equal("group description", group.Description);
            Assert.Equal(CascGroupPermission.admin, group.Permissions[0]);
        }

        private CascConfiguration ParseCascFromString(string yamlContent) {
            ConfigurationReader reader = new ConfigurationReader();

            var conf = reader.LoadFromString(yamlContent);

            return conf;
        }
    }
}
