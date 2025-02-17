using NasaPet.Models;
using Newtonsoft.Json;

namespace NasaPet.APIs;

public class NasaHttpClient<T> : INasaHttpClient<T> where T : BaseModel
{
    private readonly HttpClient _httpClient;

    public NasaHttpClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("NasaClient");
    }

    public async Task<T>? GetListAsync(string url, string? urlParams)
    {
        var response = await _httpClient.GetAsync(_httpClient.BaseAddress + url + urlParams);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        return null;
    }
}
