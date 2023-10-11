using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebApi_BusinessService.Model;

namespace WebApi_BusinessService.Services
{
    public class IntegrationService
    {
        private HttpClient httpClient;
        private IConfiguration config =null;
        public IntegrationService(IConfiguration config = null) {
            httpClient = new HttpClient();
            this.config = config;
        }
        public IntegrationService() { }
        
        public async  Task RegisterInAuth(RegisterViewModel model)
        {
            try
            {
                string authUrl = config.GetSection("AUTH_URL").Value;
                string integrationUrl = $"{authUrl}/api/Auth/register";
                HttpResponseMessage response = await  httpClient.PostAsJsonAsync(integrationUrl, model);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("error occured");
                }

            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
