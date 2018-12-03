using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword.Utils
{
    public class CredentialsBackEnd
    {
        public string login;
        public string senha;
    }

    public class HttpRest
    {
        private string result;

        public async Task<string> MakePostRequest(string login, string senha)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Statics.BaseUriBackEnd);
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var request = new HttpRequestMessage(HttpMethod.Post, "api/authenticate"))
                {
                    var json = JsonConvert.SerializeObject(new CredentialsBackEnd { login = login, senha = senha });

                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    await client.SendAsync(request)
                    .ContinueWith(responseTask =>
                    {
                        Console.WriteLine("Response: {0}", responseTask.Result);
                        result = responseTask.Result.Content.ReadAsStringAsync().Result;
                    });


                    return result;
                }
            }
        }
    }
}
