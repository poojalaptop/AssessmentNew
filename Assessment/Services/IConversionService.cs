using Assessment.DTOs;

namespace Assessment.Services
{
    public interface IConversionService
    {
        Task<List<CategoryDto>> GetCategoriesAsync();
        Task<List<UnitDto>> GetUnitsAsync(int categoryId);
        Task<ConversionResultDto> ConvertAsync(double value, string fromSymbol, string toSymbol);
    }
}
