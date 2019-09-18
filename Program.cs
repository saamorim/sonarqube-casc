using System;
using CommandLine;

namespace sonarqube_casc
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<CmdOptions>(args)
                .WithParsed<CmdOptions>(o => {
                    if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example!");
                       }
                });
        }
    }
}
