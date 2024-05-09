namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

internal sealed class NullableArgumentPattern<T> : IArgumentPattern<TypedConstant, T?>
{
    private readonly IArgumentPattern<TypedConstant, T> NonNullablePattern;

    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    public NullableArgumentPattern(IArgumentPattern<TypedConstant, T> nonNullablePattern, IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        NonNullablePattern = nonNullablePattern;

        MatchResultFactoryProvider = matchResultFactoryProvider;
    }

    IArgumentPatternMatchResult<T?> IArgumentPattern<TypedConstant, T?>.TryMatch(TypedConstant argument)
    {
        if (argument.IsNull)
        {
            return CreateSuccessful(default);
        }

        var nonNullableResult = NonNullablePattern.TryMatch(argument);

        if (nonNullableResult.WasSuccessful is false)
        {
            return CreateUnsuccessful();
        }

        return CreateSuccessful(nonNullableResult.GetMatchedArgument());
    }

    private IArgumentPatternMatchResult<T?> CreateSuccessful(T? matchedArgument) => MatchResultFactoryProvider.Successful.Create(matchedArgument);
    private IArgumentPatternMatchResult<T?> CreateUnsuccessful() => MatchResultFactoryProvider.Unsuccessful.Create<T?>();
}
