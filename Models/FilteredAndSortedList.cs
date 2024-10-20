using PersonalFinanceApp.Pages.Trasactions;

public class TransactionFilterAndSorting
{
    private readonly IEnumerable<Transaction> _transactions;
    private readonly string _searchTerm;
    private readonly string _categoryFilter;
    private readonly string _sortBy;
    private readonly int _currentPage;
    private readonly int _pageSize;
    private readonly bool _isAscending;

    public TransactionFilterAndSorting(IEnumerable<Transaction> transactions, string searchTerm, string categoryFilter, string sortBy, int currentPage, int pageSize)
    {
        _transactions = transactions;
        _searchTerm = searchTerm;
        _categoryFilter = categoryFilter;
        _sortBy = sortBy;
        _currentPage = currentPage;
        _pageSize = pageSize;

    }

    public IEnumerable<Transaction> Filter()
    {
        var query = _transactions
            .Where(SearchPredicate)
            .Where(CategoryPredicate);

        if (IsAscending())
        {
            query = query.OrderBy(SortSelector);
        }
        else
        {
            query = query.OrderByDescending(SortSelector);
        }
        return query
            .Skip((_currentPage - 1) * _pageSize)
            .Take(_pageSize);
    }

    private bool SearchPredicate(Transaction t) =>
        string.IsNullOrEmpty(_searchTerm) || t.RecipientOrSender.Contains(_searchTerm, StringComparison.OrdinalIgnoreCase);

    private bool CategoryPredicate(Transaction t) =>
        string.IsNullOrEmpty(_categoryFilter) || t.Category == _categoryFilter;

    private object SortSelector(Transaction t) => _sortBy switch
    {
        "latest" => t.Date,
        "oldest" => t.Date,
        "highest" => -t.Amount,
        "lowest" => t.Amount,
        "a-to-z" => t.RecipientOrSender,
        "z-to-a" => t.RecipientOrSender,
        _ => t.Date // Default sort
    };

    private bool IsAscending() => _sortBy switch
    {
        "latest" => true,
        "oldest" => false,
        "highest" => false,
        "lowest" => true,
        "a-to-z" => true,
        "z-to-a" => false,
        _ => true
    };
}
