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

            var client = new RestClient("http://localhost:9000/");
            client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator("8afaf679aae766b241bbfb10fc58e550b7c6a886", "");
            
            var request = new RestRequest("api/system/ping");

            var response = client.Post(request);
            var content = response.Content; // raw content as string

            Console.Write(content);
        }
    }
}