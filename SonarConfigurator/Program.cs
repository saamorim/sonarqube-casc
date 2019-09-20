using CommandLine;

namespace SonarConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationReader reader = new ConfigurationReader();

            Parser.Default
                .ParseArguments<CmdOptions>(args)
                .WithParsed<CmdOptions>(o =>
                {
                    SonarConfigurator p = new SonarConfigurator(reader);
                    p.ApplyConfiguration(o);
                });
        }
    }
}
