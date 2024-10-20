namespace PersonalFinanceApp.ErrorHandling;

public interface IErrorHandler
{
    void HandleError(Exception ex);
}

public class GlobalErrorHandler : IErrorHandler
{
    public void HandleError(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}