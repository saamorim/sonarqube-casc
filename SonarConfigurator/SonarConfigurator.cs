using System;
using System.IO;

namespace SonarConfiguration
{
    public class SonarConfigurator
    {
        private ConfigurationReader reader;

        public SonarConfigurator(ConfigurationReader reader)
        {
            this.reader = reader;
        }

        internal void ApplyConfiguration(CmdOptions o)
        {
            var config = reader.LoadFromFile(o.CasCLocation);
            Console.Write($"Log level is {config.Admin.System.Loglevel}");
        }
    }
}