using System;

namespace BookingApi.Abstractions.Models.Validation
{
    public abstract class BaseValidationAttribute : Attribute
    {
        public abstract (bool isValid, string validationMessage) Validate<T>(string fieldName, T value);
    }
}
