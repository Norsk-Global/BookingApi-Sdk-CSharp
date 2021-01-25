using System;
using BookingApi.Abstractions.Models.Validation;

namespace BookingApi.Core.Models.Validation
{
    public class NotBeEmptyAttribute : BaseValidationAttribute
    {
        public override (bool isValid, string validationMessage) Validate<T>(string fieldName, T value)
        {
            if (!(value is string stringValue)) return (true, "");

            return string.IsNullOrEmpty(stringValue)
                ? (false, $"The field {fieldName} must not be empty.")
                : (true, "");
        }
    }
}
