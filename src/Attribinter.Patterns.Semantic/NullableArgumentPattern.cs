namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

internal sealed class NullableArgumentPattern<T> : IArgumentPattern<TypedConstant, T?>
{
    private readonly IArgumentPattern<TypedConstant, T> NonNullablePattern;

    public NullableArgumentPattern(IArgumentPattern<TypedConstant, T> nonNullablePattern)
    {
        NonNullablePattern = nonNullablePattern;
    }

    ArgumentPatternMatchResult<T?> IArgumentPattern<TypedConstant, T?>.TryMatch(TypedConstant argument)
    {
        if (argument.IsNull)
        {
            return CreateSuccessful(default);
        }

        var nonNullableResult = NonNullablePattern.TryMatch(argument);

        if (nonNullableResult.Successful is false)
        {
            return CreateUnsuccessful();
        }

        return CreateSuccessful(nonNullableResult.GetMatchedArgument());
    }

    private static ArgumentPatternMatchResult<T?> CreateSuccessful(T? matchedArgument) => ArgumentPatternMatchResult.CreateSuccessful(matchedArgument);
    private static ArgumentPatternMatchResult<T?> CreateUnsuccessful() => ArgumentPatternMatchResult.CreateUnsuccessful<T?>();
}
