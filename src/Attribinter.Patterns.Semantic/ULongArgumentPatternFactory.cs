namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="IULongArgumentPatternFactory"/>
public sealed class ULongArgumentPatternFactory : IULongArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="ULongArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="ulong"/> arguments.</summary>
    public ULongArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, ulong> IULongArgumentPatternFactory.Create() => NonNullableArgumentPattern<ulong>.Instance;
}
