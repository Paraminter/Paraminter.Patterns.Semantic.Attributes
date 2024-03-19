namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="IUShortArgumentPatternFactory"/>
public sealed class UShortArgumentPatternFactory : IUShortArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="UShortArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="ushort"/> arguments.</summary>
    public UShortArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, ushort> IUShortArgumentPatternFactory.Create() => NonNullableArgumentPattern<ushort>.Instance;
}
