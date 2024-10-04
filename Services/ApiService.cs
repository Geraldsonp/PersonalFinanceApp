
using System.Net.Http.Json;

namespace PersonalFinanceApp.Services;

public abstract class GenericApiService<T, TKey> : IApiService<T, TKey> where T : class where TKey : notnull
{
    public string Endpoint { get; init; }
    private HttpClient _httpClient { get; init; }
    public GenericApiService(string endpoint, HttpClient httpClient)
    {
        Endpoint = endpoint;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress, Endpoint);
    }

    public async Task DeleteAsync(TKey id)
    {
        var response = await _httpClient.DeleteAsync($"{id}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        var response = await _httpClient.GetAsync("");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<T>>();
        }

        throw new Exception(response.ReasonPhrase);
    }

    public async Task<T> GetAsync(TKey id)
    {
        var response = await _httpClient.GetAsync($"{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }

        throw new Exception(response.ReasonPhrase);
    }

    public async Task<T> PostAsync(T obj)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }
        var response = await _httpClient.PostAsJsonAsync("", obj);

        if (!response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<T>();

        throw new Exception(response.ReasonPhrase);
    }

    public async Task<T> PutAsync(T obj)
    {
        var response = await _httpClient.PutAsJsonAsync("", obj);

        if (!response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<T>();

        throw new Exception(response.ReasonPhrase);
    }

}
