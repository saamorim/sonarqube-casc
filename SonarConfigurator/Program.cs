using CommandLine;

namespace SonarConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<CmdOptions>(args)
                .WithParsed<CmdOptions>(o => {
                    SonarConfigurator p = new SonarConfigurator();
                    p.ApplyConfiguration(o);
                });
        }
    }
}
