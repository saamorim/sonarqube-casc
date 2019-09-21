using System;
using CommandLine;

namespace SonarConfiguratorAsCode
{
    class CmdOptions
    {
        [Option('f', "file", Required = true, HelpText = "Configuration as code location")]
        public string CasCLocation { get; set; }

        [Option('h', "host", Required = true, HelpText = "Host where Sonarqube is running")]
        public string SonarqubeHost { get; set; }

        [Option('t', "token", Required = true, HelpText = "Token access to Sonarqube", SetName = "token")]
        public string SonarqubeToken { get; set; }

        [Option('u', "username", Required = true, HelpText = "Username access to Sonarqube", SetName = "userpass")]
        public string SonarqubeUsername { get; set; }

        [Option('p', "password", Required = true, HelpText = "Password access to Sonarqube", SetName = "userpass")]
        public string SonarqubePassword { get; set; }

        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
    }
}
