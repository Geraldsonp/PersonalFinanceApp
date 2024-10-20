namespace PersonalFinanceApp.LoadingStateManagment;

public class LoadingService
{
    private bool isLoading;
    public event Action OnChange;

    public bool IsLoading
    {
        get => isLoading;
        set
        {
            isLoading = value;
            OnChange?.Invoke();
        }
    }
}