namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="IShortArgumentPatternFactory"/>
public sealed class ShortArgumentPatternFactory : IShortArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="ShortArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="short"/> arguments.</summary>
    public ShortArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, short> IShortArgumentPatternFactory.Create() => NonNullableArgumentPattern<short>.Instance;
}
