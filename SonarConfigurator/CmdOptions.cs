using System;
using CommandLine;

namespace SonarConfiguration
{
    class CmdOptions
    {
        [Option('f', "file", Required = true, HelpText = "Configuration as code location")]
        public string CasCLocation { get; set; }

        [Option('h', "host", Required = true, HelpText = "Host where Sonarqube is running")]
        public string SonarqubeHost { get; set; }

        [Option('t', "token", Required = true, HelpText = "Token access to Sonarqube")]
        public string SonarqubeToken { get; set; }

        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
    }
}
