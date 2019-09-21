using System;
using CommandLine;
using RestSharp;
using RestSharp.Authenticators;

namespace SonarConfiguratorAsCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<CmdOptions>(args)
                .WithParsed<CmdOptions>(o =>
                {
                    var configurator = CreateConfigurator(o);
                    configurator.ApplyConfiguration(o.CasCLocation);
                });
        }

        private static SonarConfigurator CreateConfigurator(CmdOptions o)
        {

            var client = new RestClient(o.SonarqubeHost);
            client.Authenticator = GetAuthenticator(o);

            SonarApi sonarApi = new SonarApi(client);
            SonarWriter sonarWriter = new SonarWriter(sonarApi);
            ConfigurationReader configReader = new ConfigurationReader();

            SonarConfigurator configurator = new SonarConfigurator(configReader, sonarWriter);

            return configurator;
        }

        private static HttpBasicAuthenticator GetAuthenticator(CmdOptions o)
        {
            if (!String.IsNullOrEmpty(o.SonarqubeToken))
                return new HttpBasicAuthenticator(o.SonarqubeToken, String.Empty);

            return new HttpBasicAuthenticator(o.SonarqubeUsername, o.SonarqubePassword);
        }
    }
}
