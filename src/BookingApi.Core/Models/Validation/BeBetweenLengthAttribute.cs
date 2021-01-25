using System;
using BookingApi.Abstractions.Models.Validation;

namespace BookingApi.Core.Models.Validation
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BeBetweenLengthAttribute : BaseValidationAttribute
    {
        public int MinLength { get; }
        public int MaxLength { get; }

        public BeBetweenLengthAttribute(int minLength, int maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }

        public override (bool isValid, string validationMessage) Validate<T>(string fieldName, T value)
        {
            if (!(value is string stringValue)) return (true, "");

            return stringValue.Length < MinLength || stringValue.Length > MaxLength
                ? (false, $"The field {fieldName} must between {MinLength} and {MaxLength} characters.")
                : (true, "");
        }
    }
}
