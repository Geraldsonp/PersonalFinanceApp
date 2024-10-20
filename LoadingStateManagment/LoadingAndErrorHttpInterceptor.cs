using PersonalFinanceApp.ErrorHandling;

namespace PersonalFinanceApp.LoadingStateManagment;

public class LoadingAndErrorHttpInterceptor: DelegatingHandler
{
    private readonly LoadingService _loadingService;
    private readonly IErrorHandler _errorHandler;

    public LoadingAndErrorHttpInterceptor(LoadingService loadingService, IErrorHandler errorHandler)
    {
        _loadingService = loadingService;
        _errorHandler = errorHandler;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _loadingService.IsLoading = true;
        try
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                _errorHandler.HandleError(new HttpRequestException($"HTTP request failed with status code {response.StatusCode}"));
            }
            return response;
        }
        catch (Exception ex)
        {
            _errorHandler.HandleError(ex);
            throw;
        }
        finally
        {
            _loadingService.IsLoading = false;
        }
    }
}