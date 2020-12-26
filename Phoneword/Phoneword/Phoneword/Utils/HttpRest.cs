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

        public async Task<string> AuthenticateCarsApi(string login, string senha)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Statics.BaseUriCars);
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var request = new HttpRequestMessage(HttpMethod.Post, "api/authenticate"))
                {
                    var jsonContent = JsonConvert.SerializeObject(new CredentialsBackEnd { login = login, senha = senha });

                    request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    await client.SendAsync(request)
                    .ContinueWith(responseTask =>
                    {
                        string jsonMenssage = responseTask.Result.Content.ReadAsStringAsync().Result;
                        System.Diagnostics.Debug.WriteLine("====== Response: " + jsonMenssage, "WS-DEGUB");
                        result = jsonMenssage;
                    });


                    return result;
                }
            }
        }

        public async Task<string> GetRequest(string baseUri, string resourceUri)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var request = new HttpRequestMessage(HttpMethod.Get, resourceUri))
                {
                    HttpResponseMessage response = await client.GetAsync(baseUri + resourceUri);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonMenssage = response.Content.ReadAsStringAsync().Result;
                        System.Diagnostics.Debug.WriteLine("====== Response: " + jsonMenssage, "WS-DEGUB");
                        result = jsonMenssage;
                    }
                    else
                    {
                        return "Sem sucesso a sua requisição: ";
                    }

                    //.ContinueWith(responseTask =>
                    //{
                    //    string jsonMenssage = responseTask.Result.Content.ReadAsStringAsync().Result;
                    //    System.Diagnostics.Debug.WriteLine("====== Response: " + jsonMenssage, "WS-DEGUB");
                    //    result = jsonMenssage;
                    //});

                    return result;
                }
            }
        }

        public async Task<string> PutRequest(string uri, string body)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders
                          .Accept
                          .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var request = new HttpRequestMessage(HttpMethod.Put, uri))
                    {

                        request.Content = new StringContent(body, Encoding.UTF8, "application/json");

                        await client.SendAsync(request)
                        .ContinueWith(responseTask =>
                        {
                            string jsonMenssage = responseTask.Result.Content.ReadAsStringAsync().Result;
                            System.Diagnostics.Debug.WriteLine("====== Response: " + jsonMenssage, "WS-DEGUB");
                            result = jsonMenssage;
                        });


                        return "OK";
                    }
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }
    }
}

