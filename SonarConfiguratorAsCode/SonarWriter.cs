using System;
using RestSharp;

namespace SonarConfiguratorAsCode
{
    public class SonarWriter
    {
        private readonly SonarApi sonarApi;

        public SonarWriter(SonarApi sonarApi)
        {
            this.sonarApi = sonarApi;
        }

        public void SetLoglevel(CascLogLevel logLevel)
        {

            sonarApi.SetLoglevel(logLevel);
        }
    }
}