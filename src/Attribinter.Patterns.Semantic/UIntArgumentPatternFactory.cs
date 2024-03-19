namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="IUIntArgumentPatternFactory"/>
public sealed class UIntArgumentPatternFactory : IUIntArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="UIntArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="uint"/> arguments.</summary>
    public UIntArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, uint> IUIntArgumentPatternFactory.Create() => NonNullableArgumentPattern<uint>.Instance;
}
