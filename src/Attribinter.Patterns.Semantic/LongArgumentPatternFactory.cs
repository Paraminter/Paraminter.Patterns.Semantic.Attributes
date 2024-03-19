namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="ILongArgumentPatternFactory"/>
public sealed class LongArgumentPatternFactory : ILongArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="LongArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="long"/> arguments.</summary>
    public LongArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, long> ILongArgumentPatternFactory.Create() => NonNullableArgumentPattern<long>.Instance;
}
