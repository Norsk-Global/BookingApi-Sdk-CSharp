using BookingApi.Abstractions.Models.Validation;

namespace BookingApi.Core.Models.Validation
{
    public class GreaterThanAttribute : BaseValidationAttribute
    {
        public int MinValue { get; }

        public GreaterThanAttribute(int minValue)
        {
            MinValue = minValue;
        }

        public override (bool isValid, string validationMessage) Validate<T>(string fieldName, T value)
        {
            if (value is decimal decimalValue)
                return decimalValue > MinValue
                    ? (false, $"The field {fieldName} must be greater than {MinValue}")
                    : (true, "");

            if (value is int intValue)
                return intValue > MinValue
                    ? (false, $"The field {fieldName} must be greater than {MinValue}")
                    : (true, "");

            return (true, "");
        }
    }
}
