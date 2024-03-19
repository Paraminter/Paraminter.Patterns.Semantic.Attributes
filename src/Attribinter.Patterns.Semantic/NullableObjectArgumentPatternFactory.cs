namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="INullableObjectArgumentPatternFactory"/>
public sealed class NullableObjectArgumentPatternFactory : INullableObjectArgumentPatternFactory
{
    private readonly INonNullableObjectArgumentPatternFactory NonNullablePatternFactory;

    /// <summary>Instantiates a <see cref="NullableObjectArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable <see cref="object"/> arguments.</summary>
    /// <param name="nonNullablePatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="object"/> arguments.</param>
    public NullableObjectArgumentPatternFactory(INonNullableObjectArgumentPatternFactory nonNullablePatternFactory)
    {
        NonNullablePatternFactory = nonNullablePatternFactory ?? throw new ArgumentNullException(nameof(nonNullablePatternFactory));
    }

    IArgumentPattern<TypedConstant, object?> INullableObjectArgumentPatternFactory.Create() => new NullableObjectArgumentPattern(NonNullablePatternFactory.Create());

    private sealed class NullableObjectArgumentPattern : IArgumentPattern<TypedConstant, object?>
    {
        private readonly IArgumentPattern<TypedConstant, object> NonNullablePattern;

        public NullableObjectArgumentPattern(IArgumentPattern<TypedConstant, object> nonNullablePattern)
        {
            NonNullablePattern = nonNullablePattern;
        }

        ArgumentPatternMatchResult<object?> IArgumentPattern<TypedConstant, object?>.TryMatch(TypedConstant argument)
        {
            if (argument.Kind is TypedConstantKind.Error)
            {
                return CreateUnsuccessful();
            }

            if (argument.IsNull)
            {
                return CreateSuccessful(null);
            }

            var nonNullableResult = NonNullablePattern.TryMatch(argument);

            if (nonNullableResult.Successful is false)
            {
                return CreateUnsuccessful();
            }

            return CreateSuccessful(nonNullableResult.GetMatchedArgument());
        }

        private static ArgumentPatternMatchResult<object?> CreateSuccessful(object? matchedArgument) => ArgumentPatternMatchResult.CreateSuccessful(matchedArgument);
        private static ArgumentPatternMatchResult<object?> CreateUnsuccessful() => ArgumentPatternMatchResult.CreateUnsuccessful<object?>();
    }
}
