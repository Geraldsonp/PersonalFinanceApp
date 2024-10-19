using System;
using PersonalFinanceApp.Models;

namespace PersonalFinanceApp.Services;

public interface IColorsService : IApiService<Color, int>
{

}

public class ColorsService : GenericApiService<Color, int>, IColorsService
{
    public ColorsService(HttpClient httpClient) : base("colors", httpClient)
    {
    }
}
