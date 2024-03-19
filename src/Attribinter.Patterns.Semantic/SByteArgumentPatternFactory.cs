namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="ISByteArgumentPatternFactory"/>
public sealed class SByteArgumentPatternFactory : ISByteArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="SByteArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="sbyte"/> arguments.</summary>
    public SByteArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, sbyte> ISByteArgumentPatternFactory.Create() => NonNullableArgumentPattern<sbyte>.Instance;
}
