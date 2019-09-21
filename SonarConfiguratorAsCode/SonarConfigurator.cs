using System;

namespace SonarConfiguratorAsCode
{
    public class SonarConfigurator
    {
        private readonly ConfigurationReader reader;
        private readonly ConfiguratorApplier applier;

        public SonarConfigurator(ConfigurationReader reader, ConfiguratorApplier applier)
        {
            this.reader = reader;
            this.applier = applier;
        }

        internal void ApplyConfiguration(string configLocation)
        {
            var config = reader.LoadFromFile(configLocation);

            Console.Write($"Log level is {config.Admin.System.Loglevel}");

            applier.SetLoglevel(config.Admin.System.Loglevel);
        }

    }
}