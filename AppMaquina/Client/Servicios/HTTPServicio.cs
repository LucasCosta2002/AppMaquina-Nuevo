using System.Text.Json;

namespace AppMaquina.Client.Servicios
{
    public class HTTPServicio : IHTTPServicio
    {
        private readonly HttpClient http;

        public HTTPServicio(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HTTPRespuesta<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var respuesta = await Deserealizar<T>(response);
                return new HTTPRespuesta<T>(respuesta, false, response);
            }
            else
            {
                return new HTTPRespuesta<T>(default, true, response);
            }
        }

        private async Task<T?> Deserealizar<T>(HttpResponseMessage response)
        {
            var respuestaString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(respuestaString, new JsonSerializerOptions() { PropertyNameCaseInsensitive= true });
        }
    }
}
