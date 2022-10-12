using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service
{
    public static class HttpClientIntegracaoHelper
    {
        public static async Task<T> PostAsync<T>(string body, string endpoint) where T : new()
        {

            var urlIntegracao = $@"{Environment.GetEnvironmentVariable("URL_BASE_SENIOR")}/{endpoint}";


            T retorno;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlIntegracao);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions(); options.PropertyNameCaseInsensitive = true;
                retorno = JsonSerializer.Deserialize<T>(responseContent, options);
            }

            if (retorno == null)
                retorno = new T();

            return retorno;
        }
    }
}
