using Microsoft.AspNetCore.Mvc;
using UnitConversion.Api.DTOs;
using UnitConversion.Api.Interfaces;

namespace UnitConversion.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionsController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionsController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost]
        public IActionResult Convert([FromBody] ConversionRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(request.FromUnit))
            {
                return BadRequest("FromUnit is required.");
            }

            if (string.IsNullOrWhiteSpace(request.ToUnit))
            {
                return BadRequest("ToUnit is required.");
            }

            var result = _conversionService.Convert(request);

            return Ok(result);
        }
    }
}