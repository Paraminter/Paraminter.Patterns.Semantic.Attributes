namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

internal sealed class ErrorArgumentPattern<T> : IArgumentPattern<TypedConstant, T>
{
    public static IArgumentPattern<TypedConstant, T> Instance { get; } = new ErrorArgumentPattern<T>();

    private ErrorArgumentPattern() { }

    ArgumentPatternMatchResult<T> IArgumentPattern<TypedConstant, T>.TryMatch(TypedConstant argument) => ArgumentPatternMatchResult.CreateUnsuccessful<T>();
}
