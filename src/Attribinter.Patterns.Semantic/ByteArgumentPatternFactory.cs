namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="IByteArgumentPatternFactory"/>
public sealed class ByteArgumentPatternFactory : IByteArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="ByteArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="byte"/> arguments.</summary>
    public ByteArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, byte> IByteArgumentPatternFactory.Create() => NonNullableArgumentPattern<byte>.Instance;
}
