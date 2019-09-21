using System;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;

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

            var client = new RestClient(o.SonarqubeHost);
            client.Authenticator = GetAuthenticator(o);

            var request = new RestRequest("api/system/ping");

            var response = client.Post(request);
            var content = response.Content; // raw content as string

            Console.Write(content);
        }

        private static HttpBasicAuthenticator GetAuthenticator(CmdOptions o)
        {
            if (!String.IsNullOrEmpty(o.SonarqubeToken))
                return new HttpBasicAuthenticator(o.SonarqubeToken, String.Empty);
            
            return new HttpBasicAuthenticator(o.SonarqubeUsername, o.SonarqubePassword);
        }
    }
}