using System.Net.Http.Json;
using System.Text.Json;

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
        try
        {
            var response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            
            return await response.Content.ReadFromJsonAsync<T>();
        }
        catch (Exception)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(url);
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
