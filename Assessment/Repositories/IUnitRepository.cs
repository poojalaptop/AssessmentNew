using Microsoft.EntityFrameworkCore;
using Assessment.Data;
using Assessment.Models;

namespace Assessment.Repositories
{
    public interface IUnitRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Unit>> GetUnitsByCategoryAsync(int categoryId);
        Task<Unit?> GetUnitBySymbolAsync(string symbol);
    }
}
