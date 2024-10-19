using System;
using PersonalFinanceApp.Models;

namespace PersonalFinanceApp.Services;

public class CategoriesService : GenericApiService<Category, int>, ICategoryService
{
    public CategoriesService(HttpClient httpClient) : base("categories", httpClient)
    {
    }
}

public interface ICategoryService : IApiService<Category, int>
{
}
