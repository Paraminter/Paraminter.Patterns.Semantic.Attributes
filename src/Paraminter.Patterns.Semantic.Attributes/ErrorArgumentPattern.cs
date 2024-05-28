namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

internal sealed class ErrorArgumentPattern<T>
    : IArgumentPattern<TypedConstant, T>
{
    private readonly IUnsuccessfulArgumentPatternMatchResultFactory MatchResultFactoryProvider;

    public ErrorArgumentPattern(
        IUnsuccessfulArgumentPatternMatchResultFactory matchResultFactoryProvider)
    {
        MatchResultFactoryProvider = matchResultFactoryProvider;
    }

    IArgumentPatternMatchResult<T> IArgumentPattern<TypedConstant, T>.TryMatch(
        TypedConstant argument)
    {
        return MatchResultFactoryProvider.Create<T>();
    }
}
