using Assessment.DTOs;
using Assessment.Repositories;

namespace Assessment.Services
{
    public class ConversionService : IConversionService
    {
        private readonly IUnitRepository _repository;

        public ConversionService(IUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _repository.GetAllCategoriesAsync();

            return categories
                .Select(c => new CategoryDto { Id = c.Id, Name = c.Name })
                .ToList();
        }

        public async Task<List<UnitDto>> GetUnitsAsync(int categoryId)
        {
            var units = await _repository.GetUnitsByCategoryAsync(categoryId);

            return units
                .Select(u => new UnitDto { Id = u.Id, Name = u.Name, Symbol = u.Symbol })
                .ToList();
        }

        public async Task<ConversionResultDto> ConvertAsync(double value, string fromSymbol, string toSymbol)
        {
            var fromUnit = await _repository.GetUnitBySymbolAsync(fromSymbol)
                ?? throw new ArgumentException($"Unit '{fromSymbol}' was not found.");

            var toUnit = await _repository.GetUnitBySymbolAsync(toSymbol)
                ?? throw new ArgumentException($"Unit '{toSymbol}' was not found.");

            if (fromUnit.CategoryId != toUnit.CategoryId)
            {
                throw new ArgumentException($"Cannot convert {fromUnit.Name} to {toUnit.Name}. They are different categories.");
            }

            double baseValue = (value + fromUnit.Offset) * fromUnit.Factor;

            if (fromUnit.Category!.Name == "Temperature" && baseValue < 0)
            {
                throw new ArgumentException("Temperature cannot be below absolute zero.");
            }

            double result = (baseValue / toUnit.Factor) - toUnit.Offset;

            return new ConversionResultDto
            {
                Value = value,
                FromUnit = fromUnit.Symbol,
                ToUnit = toUnit.Symbol,
                Result = Math.Round(result, 6),
                Category = fromUnit.Category.Name
            };
        }
    }
}
