namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="INonNullableStringArgumentPatternFactory"/>
public sealed class NonNullableStringArgumentPatternFactory : INonNullableStringArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="NonNullableStringArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="string"/> arguments.</summary>
    public NonNullableStringArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, string> INonNullableStringArgumentPatternFactory.Create() => NonNullableArgumentPattern<string>.Instance;
}
