using System;
using RestSharp;

namespace SonarConfiguratorAsCode
{
    public class ConfiguratorApplier {
        private readonly RestClient client;

        public ConfiguratorApplier(RestClient client) {
            this.client = client;
        }

        public void SetLoglevel(CascLogLevel logLevel) {

            var request = new RestRequest("api/system/change_log_level");
            request.AddQueryParameter("level", logLevel.ToString());
            
            var response = client.Post(request);
            if(!response.IsSuccessful)
                throw new Exception("Post failed");
        }
    }
}