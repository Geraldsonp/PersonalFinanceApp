namespace PersonalFinanceApp.Services;

public interface IApiService<T, TKey> where T : class
{
    string Endpoint { get; init; }

    Task<IEnumerable<T>> GetAsync();

    Task<T> GetAsync(TKey id);

    Task<T> PostAsync(T obj);

    Task<T> PutAsync(T obj);

    Task DeleteAsync(TKey id);


}
