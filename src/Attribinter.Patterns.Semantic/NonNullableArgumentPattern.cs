namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

internal sealed class NonNullableArgumentPattern<T> : IArgumentPattern<TypedConstant, T>
{
    public static IArgumentPattern<TypedConstant, T> Instance { get; } = new NonNullableArgumentPattern<T>();

    private NonNullableArgumentPattern() { }

    ArgumentPatternMatchResult<T> IArgumentPattern<TypedConstant, T>.TryMatch(TypedConstant argument)
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

    private static ArgumentPatternMatchResult<T> CreateSuccessful(T matchedArgument) => ArgumentPatternMatchResult.CreateSuccessful(matchedArgument);
    private static ArgumentPatternMatchResult<T> CreateUnsuccessful() => ArgumentPatternMatchResult.CreateUnsuccessful<T>();
}
