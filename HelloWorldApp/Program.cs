using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using HelloWorldApp.Writers;

namespace HelloWorldApp
{
    class Program
    {

        static void Main(string[] args)
        {
           
            var httpClient = new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider()
                .GetService<IHttpClientFactory>()
                .CreateClient();
            var writer = new consoleWriter();
            string strHelloWorldMessage;
            try
            {
                strHelloWorldMessage = GetMessage(httpClient).GetAwaiter().GetResult();
            }
            catch
            {
                strHelloWorldMessage = "We are sorry, your request cannot be processed currently. Please contact Customer Support for further assistance";
            }
            writer.sendMessageToWriter(strHelloWorldMessage);
            
        }
        static async Task<string> GetMessage(HttpClient client)
        {


            var strMessage = "";
                client.BaseAddress = new Uri("https://localhost:44319/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("helloworld");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    strMessage = await response.Content.ReadAsAsync<string>();
                }
                else
                {
                    strMessage = "We are sorry, your request cannot be processed currently. Please contact Customer Support for further assistance";
                }
                return strMessage;
        }
        }
}
