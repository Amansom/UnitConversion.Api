using UnitConversion.Api.DTOs;
using UnitConversion.Api.Interfaces;

namespace UnitConversion.Api.Services
{
    public class ConversionService : IConversionService
    {
        private readonly Dictionary<string, double> _lengthUnits =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Meter", 1 },
                { "Foot", 0.3048 },
                { "Kilometer", 1000 },
                { "Mile", 1609.344 },
                { "Centimeter", 0.01 },
                { "Inch", 0.0254 }
            };

        private readonly Dictionary<string, double> _weightUnits =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Kilogram", 1 },
                { "Pound", 0.45359237 },
                { "Gram", 0.001 },
                { "Ounce", 0.0283495 }
            };

        public ConversionResponseDto Convert(ConversionRequestDto request)
        {
            var fromUnit = request.FromUnit.Trim();
            var toUnit = request.ToUnit.Trim();

            double convertedValue;

            // Length Conversion
            if (_lengthUnits.ContainsKey(fromUnit) &&
                _lengthUnits.ContainsKey(toUnit))
            {
                convertedValue = ConvertUsingBaseUnit(
                    request.Value,
                    fromUnit,
                    toUnit,
                    _lengthUnits);
            }
            // Weight Conversion
            else if (_weightUnits.ContainsKey(fromUnit) &&
                     _weightUnits.ContainsKey(toUnit))
            {
                convertedValue = ConvertUsingBaseUnit(
                    request.Value,
                    fromUnit,
                    toUnit,
                    _weightUnits);
            }
            // Temperature Conversion
            else
            {
                convertedValue = ConvertTemperature(
                    request.Value,
                    fromUnit,
                    toUnit);
            }

            return new ConversionResponseDto
            {
                OriginalValue = request.Value,
                FromUnit = fromUnit,
                ToUnit = toUnit,
                ConvertedValue = Math.Round(convertedValue, 4)
            };
        }

        private double ConvertUsingBaseUnit(
            double value,
            string fromUnit,
            string toUnit,
            Dictionary<string, double> units)
        {
            // Convert to base unit first
            var baseValue = value * units[fromUnit];

            // Convert base unit to target unit
            return baseValue / units[toUnit];
        }

        private double ConvertTemperature(
            double value,
            string fromUnit,
            string toUnit)
        {
            fromUnit = fromUnit.ToLower();
            toUnit = toUnit.ToLower();

            if (fromUnit == toUnit)
            {
                return value;
            }

            switch (fromUnit)
            {
                case "celsius":
                    if (toUnit == "fahrenheit")
                    {
                        return (value * 9 / 5) + 32;
                    }

                    if (toUnit == "kelvin")
                    {
                        return value + 273.15;
                    }

                    break;

                case "fahrenheit":
                    if (toUnit == "celsius")
                    {
                        return (value - 32) * 5 / 9;
                    }

                    if (toUnit == "kelvin")
                    {
                        return ((value - 32) * 5 / 9) + 273.15;
                    }

                    break;

                case "kelvin":
                    if (toUnit == "celsius")
                    {
                        return value - 273.15;
                    }

                    if (toUnit == "fahrenheit")
                    {
                        return ((value - 273.15) * 9 / 5) + 32;
                    }

                    break;
            }

            throw new ArgumentException(
                $"Unsupported conversion from '{fromUnit}' to '{toUnit}'.");
        }
    }
}