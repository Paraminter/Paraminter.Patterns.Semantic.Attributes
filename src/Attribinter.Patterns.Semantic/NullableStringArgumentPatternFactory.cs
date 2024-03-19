namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="INullableStringArgumentPatternFactory"/>
public sealed class NullableStringArgumentPatternFactory : INullableStringArgumentPatternFactory
{
    private readonly INonNullableStringArgumentPatternFactory NonNullablePatternFactory;

    /// <summary>Instantiates a <see cref="NullableStringArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable <see cref="string"/> arguments.</summary>
    /// <param name="nonNullablePatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="string"/> arguments.</param>
    public NullableStringArgumentPatternFactory(INonNullableStringArgumentPatternFactory nonNullablePatternFactory)
    {
        NonNullablePatternFactory = nonNullablePatternFactory ?? throw new System.ArgumentNullException(nameof(nonNullablePatternFactory));
    }

    IArgumentPattern<TypedConstant, string?> INullableStringArgumentPatternFactory.Create() => new NullableArgumentPattern<string>(NonNullablePatternFactory.Create());
}
