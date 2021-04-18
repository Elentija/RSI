using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceContract.Models;

namespace WcfServiceContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SpaceX : ISpaceX
    {
        double suma = 0;

        public async Task<string> GetCompanyInfo()
        {
            string info = "";
            try
            {
                var request = WebRequest.CreateHttp("https://api.spacexdata.com/v3");
                request.Method = WebRequestMethods.Http.Get;
                request.ContentType = "aplication/json; charset=utf-8";
                await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
                    .ContinueWith(task =>
                    {
                        string responseData = "";
                        var response = (HttpWebResponse)task.Result;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            responseData = responseReader.ReadToEnd();
                        };

                        Console.WriteLine("Wywołano metode pobrania informacji o firmie SpaceX");
                        responseData.Remove(0);
                        responseData.Remove(responseData.Length - 1);
                       foreach (var line in responseData.Split(','))
                        {
                            info += line;
                            info += "\n";
                        }
                        return info;
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return info;
        }

        public async Task<object> GetLaunches()
        {
            string answer = "";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://www.7timer.info/bin/astro.php?lon=52.13&lat=21.42&ac=0&unit=metric&output=json&tzshift=0"),
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Product>(body);
                Console.WriteLine(body);
                return body;
            }
        }


        public double Pomnoz(double n1, double n2)
        {
            var result = n1 * n2;
            Console.WriteLine($"Wywołano metode mnożenia dwóch liczb: {n1} * {n2} = {result}");
            return result;
        }

        public double Sumuj(double n1)
        {
            Console.WriteLine($"Wywołano metode sumowania globalnego: {suma} + {n1} = {suma += n1}");
            return suma;
        }
    }
}
