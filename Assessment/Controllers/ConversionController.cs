using Assessment.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _conversionService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("units/{categoryId}")]
        public async Task<IActionResult> GetUnits(int categoryId)
        {
            var units = await _conversionService.GetUnitsAsync(categoryId);
            return Ok(units);
        }

        [HttpGet("convert")]
        public async Task<IActionResult> Convert(double value, string from, string to)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
            {
                return BadRequest(new { message = "Please provide both 'from' and 'to' units." });
            }

            try
            {
                var result = await _conversionService.ConvertAsync(value, from, to);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
