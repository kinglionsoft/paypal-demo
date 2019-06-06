using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PayPal.Server
{
    public static class HttpExtensions
    {
        public static async Task<T> ReadFromBodyAsync<T>(this HttpRequest request)
        {
            using (var reader = new StreamReader(request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(body);
            }
        }

        public static Task WriteJsonAsync(this HttpResponse response, object data)
        {
            return response.WriteAsync(JsonConvert.SerializeObject(data));
        }
    }
}