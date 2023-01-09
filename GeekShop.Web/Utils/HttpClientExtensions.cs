using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShop.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

        [return: MaybeNull]
        public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode) throw new
                    ApplicationException($"Something went wrong calling the API: " + $"{responseMessage.ReasonPhrase}");

            var dataAsString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);

            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType; 

            return httpClient.PostAsync(url, content);
        }
        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);

            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;

            return httpClient.PutAsync(url, content);
        }
    }
}
