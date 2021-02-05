using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookingApi.Core.Http.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var rawJsonContent = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(rawJsonContent);
        }

        public static async Task<T> ReadAsStreamAsync<T>(this HttpContent content)
        {
            var rawJsonContent = JsonConvert.SerializeObject((await content.ReadAsStreamAsync() as MemoryStream).ToArray());
            return JsonConvert.DeserializeObject<T>(rawJsonContent);
        }
    }
}
