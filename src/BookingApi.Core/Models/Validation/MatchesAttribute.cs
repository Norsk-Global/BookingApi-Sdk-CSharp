using System.Text.RegularExpressions;
using BookingApi.Abstractions.Models.Validation;

namespace BookingApi.Core.Models.Validation
{
    public class MatchesAttribute : BaseValidationAttribute
    {
        private readonly string _errorMessage;
        private readonly Regex _expression;

        public MatchesAttribute(string expression, string errorMessage = null)
        {
            _errorMessage = errorMessage;
            _expression = new Regex(expression);
        }

        public override (bool isValid, string validationMessage) Validate<T>(string fieldName, T value)
        {
            if (!(value is string stringValue)) return (true, "Can not apply this rule to non-string types.");

            bool match = _expression.IsMatch(stringValue);
            if (!match) {
                return (false,
                    _errorMessage ??
                    $"The provided '{stringValue}' does not conform to the expression: '{_expression};");
            }

            return (true, "");
        }
    }
}
