namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="INonNullableObjectArgumentPatternFactory"/>
public sealed class NonNullableObjectArgumentPatternFactory : INonNullableObjectArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="NonNullableObjectArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="object"/> arguments.</summary>
    public NonNullableObjectArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, object> INonNullableObjectArgumentPatternFactory.Create() => NonNullableObjectArgumentPattern.Instance;

    private sealed class NonNullableObjectArgumentPattern : IArgumentPattern<TypedConstant, object>
    {
        public static NonNullableObjectArgumentPattern Instance { get; } = new();

        private NonNullableObjectArgumentPattern() { }

        ArgumentPatternMatchResult<object> IArgumentPattern<TypedConstant, object>.TryMatch(TypedConstant argument)
        {
            if (argument.Kind is TypedConstantKind.Error)
            {
                return CreateUnsuccessful();
            }

            var (success, value) = TryExtractValue(argument);

            if (success is false)
            {
                return CreateUnsuccessful();
            }

            if (value is null)
            {
                return CreateUnsuccessful();
            }

            return CreateSuccessful(value);
        }

        private static (bool, object?) TryExtractValue(TypedConstant value)
        {
            if (value.Kind is TypedConstantKind.Error)
            {
                return (false, null);
            }

            if (value.IsNull)
            {
                return (true, null);
            }

            if (value.Kind is not TypedConstantKind.Array)
            {
                return (true, value.Value);
            }

            if (value.Values.IsEmpty)
            {
                return (true, Array.Empty<object?>());
            }

            var arrayConstants = value.Values;
            var arrayValues = new object?[arrayConstants.Length];

            for (var i = 0; i < arrayConstants.Length; i++)
            {
                var (elementSuccess, elementValue) = TryExtractValue(arrayConstants[i]);

                if (elementSuccess is false)
                {
                    return (false, null);
                }

                arrayValues[i] = elementValue;
            }

            return (true, arrayValues);
        }

        private static ArgumentPatternMatchResult<object> CreateSuccessful(object matchedArgument) => ArgumentPatternMatchResult.CreateSuccessful(matchedArgument);
        private static ArgumentPatternMatchResult<object> CreateUnsuccessful() => ArgumentPatternMatchResult.CreateUnsuccessful<object>();
    }
}
