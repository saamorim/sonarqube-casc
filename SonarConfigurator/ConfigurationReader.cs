using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SonarConfiguration {
    public class ConfigurationReader {

        public CascConfiguration LoadFromFile(string filename) {
            using (StreamReader str = new StreamReader(filename))
            {
                string yamlContent = str.ReadToEnd();
                return LoadFromString(yamlContent);
            }

        }
        public CascConfiguration LoadFromString(string yamlContent)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            var config = deserializer.Deserialize<CascConfiguration>(yamlContent);
            return config;
        }

    }
}