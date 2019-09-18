using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SonarConfiguration
{
    public class SonarConfigurator
    {
        public SonarConfigurator()
        {
        }

        public CascConfiguration LoadConfig(string yamlContent)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            var config = deserializer.Deserialize<CascConfiguration>(yamlContent);
            return config;
        }

        internal void ApplyConfiguration(CmdOptions o)
        {
            using (StreamReader str = new StreamReader(o.CasCLocation))
            {
                string yamlContent = str.ReadToEnd();
                var config = LoadConfig(yamlContent);
                Console.Write($"Log level is {config.Admin.System.Loglevel}");
            }
        }
    }
}