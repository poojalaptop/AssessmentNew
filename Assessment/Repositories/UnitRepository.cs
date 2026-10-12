using Assessment.Data;
using Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly AppDbContext _context;

        public UnitRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<List<Unit>> GetUnitsByCategoryAsync(int categoryId)
        {
            return await _context.Units
                .Where(u => u.CategoryId == categoryId) 
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task<Unit?> GetUnitBySymbolAsync(string symbol)
        {
            return await _context.Units
                .Include(u => u.Category)
                .FirstOrDefaultAsync(u => u.Symbol == symbol);
        }
    }
}
