namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="INonNullableObjectArgumentPatternFactory"/>
public sealed class NonNullableObjectArgumentPatternFactory
    : INonNullableObjectArgumentPatternFactory
{
    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="NonNullableObjectArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="object"/> arguments.</summary>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    public NonNullableObjectArgumentPatternFactory(
        IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, object> INonNullableObjectArgumentPatternFactory.Create() => new NonNullableObjectArgumentPattern(MatchResultFactoryProvider);

    private sealed class NonNullableObjectArgumentPattern
        : IArgumentPattern<TypedConstant, object>
    {
        private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

        public NonNullableObjectArgumentPattern(
            IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            MatchResultFactoryProvider = matchResultFactoryProvider;
        }

        IArgumentPatternMatchResult<object> IArgumentPattern<TypedConstant, object>.TryMatch(
            TypedConstant argument)
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

        private static (bool Success, object? Value) TryExtractValue(
            TypedConstant value)
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

        private IArgumentPatternMatchResult<object> CreateSuccessful(
            object matchedArgument)
        {
            return MatchResultFactoryProvider.Successful.Create(matchedArgument);
        }

        private IArgumentPatternMatchResult<object> CreateUnsuccessful() => MatchResultFactoryProvider.Unsuccessful.Create<object>();
    }
}
