using UnitConversion.Api.DTOs;

namespace UnitConversion.Api.Interfaces
{
    public interface IConversionService
    {
        ConversionResponseDto Convert(ConversionRequestDto request);
    }
}