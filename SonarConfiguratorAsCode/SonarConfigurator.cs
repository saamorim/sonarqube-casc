using System;

namespace SonarConfiguratorAsCode
{
    public class SonarConfigurator
    {
        private readonly ConfigurationReader reader;
        private readonly SonarWriter writer;

        public SonarConfigurator(ConfigurationReader reader, SonarWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        internal void ApplyConfiguration(string configLocation)
        {
            var config = reader.LoadFromFile(configLocation);

            Console.Write($"Log level is {config.Admin.System.Loglevel}");

            writer.SetLoglevel(config.Admin.System.Loglevel);
        }

    }
}