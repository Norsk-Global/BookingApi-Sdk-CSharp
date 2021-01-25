using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using BookingApi.Abstractions.Models.Validation;

namespace BookingApi.Abstractions.Models.Fluent
{
    public abstract class FluentBuilder<TImplementation, TInterface>
        where TImplementation : TInterface, new() where TInterface : class
    {
        public static implicit operator TImplementation(FluentBuilder<TImplementation, TInterface> builder) =>
            builder._model;

        protected readonly TImplementation _model;

        protected FluentBuilder(TInterface model)
        {
            model ??= new TImplementation();
            _model = (TImplementation)model;
        }

        protected T Validate<T>(T value, [CallerMemberName] string method = "")
        {
            var methodInfo = GetType().GetMethod(method);
            var attributes = methodInfo?.GetCustomAttributes<BaseValidationAttribute>();

            if (!attributes.Any()) return value;

            var errorMessages = attributes.Select(a => a.Validate(methodInfo?.Name, value))
                .Where(a => !a.isValid)
                .Select(a => a.validationMessage);

            if (!errorMessages.Any()) return value;

            throw new Exception(string.Join("\n", errorMessages));
        }
    }
}
