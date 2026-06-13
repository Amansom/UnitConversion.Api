namespace UnitConversion.Api.DTOs
{
    public class ConversionRequestDto
    {
        public double Value { get; set; }

        public string FromUnit { get; set; } = string.Empty;

        public string ToUnit { get; set; } = string.Empty;
    }
}