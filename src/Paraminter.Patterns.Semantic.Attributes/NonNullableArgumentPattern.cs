namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

internal sealed class NonNullableArgumentPattern<T> : IArgumentPattern<TypedConstant, T>
{
    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    public NonNullableArgumentPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        MatchResultFactoryProvider = matchResultFactoryProvider;
    }

    IArgumentPatternMatchResult<T> IArgumentPattern<TypedConstant, T>.TryMatch(TypedConstant argument)
    {
        if (argument.Kind is TypedConstantKind.Error)
        {
            return CreateUnsuccessful();
        }

        if (argument.Kind is TypedConstantKind.Array)
        {
            return CreateUnsuccessful();
        }

        if (argument.IsNull)
        {
            return CreateUnsuccessful();
        }

        if (argument.Value is not T tArgument)
        {
            return CreateUnsuccessful();
        }

        return CreateSuccessful(tArgument);
    }

    private IArgumentPatternMatchResult<T> CreateSuccessful(T matchedArgument) => MatchResultFactoryProvider.Successful.Create(matchedArgument);
    private IArgumentPatternMatchResult<T> CreateUnsuccessful() => MatchResultFactoryProvider.Unsuccessful.Create<T>();
}
