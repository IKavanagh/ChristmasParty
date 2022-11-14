using System.Net.Http;
using System.Net.Http.Json;

namespace Christmas.Services;

public class BaseService
{
    #region Configuration Parameters
    private static string BaseUrl => "https://raw.githubusercontent.com/IKavanagh/api/main/Christmas/";
    #endregion

    private readonly HttpClient httpClient;

    public BaseService() : this(BaseUrl) { }

    public BaseService(string baseUrl)
    {
        httpClient = new HttpClient()
        {
            BaseAddress = new Uri(baseUrl)
        };
    }

    protected async Task<T> GetAsync<T>(string url)
    {
        var response = await httpClient.GetAsync(url);

        return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<T>() : default;
    }
}
