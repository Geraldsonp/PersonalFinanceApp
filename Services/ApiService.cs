
using System.Net.Http.Json;
using PersonalFinanceApp.Models;

namespace PersonalFinanceApp.Services;

public abstract class GenericApiService<T, TKey> : IApiService<T, TKey> where T : class where TKey : notnull
{
    public string _endpoint { get; init; }
    private HttpClient _httpClient { get; init; }
    public GenericApiService(string endpoint, HttpClient httpClient)
    {
        if (!endpoint.StartsWith("/"))
        {
            _endpoint = $"/{endpoint}";
        }
        else
        {

            _endpoint =   endpoint;
        }
        _httpClient = httpClient;
    }

    public async Task DeleteAsync(TKey id)
    {
        var uri = $"{_endpoint}/{id}";
        var response = await _httpClient.DeleteAsync(uri);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        var uri = _endpoint;
        var response = await _httpClient.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<T>>();
        }

        throw new Exception(response.ReasonPhrase);
    }

    public async Task<T> GetAsync(TKey id)
    {
        var uri =  $"{_endpoint}/{id}";
        var response = await _httpClient.GetAsync(uri);
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

        if(obj is IHasId hasId){
            hasId.Id = Guid.NewGuid().ToString();
        }

        var uri =_endpoint;
        var response = await _httpClient.PostAsJsonAsync(uri, obj);

        if (!response.IsSuccessStatusCode)
            throw new Exception(response.ReasonPhrase);

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<T> PutAsync(T obj, TKey id)
    {
        var uri = _endpoint + "/" + id;
        var response = await _httpClient.PutAsJsonAsync(uri, obj);

        if (!response.IsSuccessStatusCode)
            throw new Exception(response.ReasonPhrase);
        
        return await response.Content.ReadFromJsonAsync<T>();
    }

}
