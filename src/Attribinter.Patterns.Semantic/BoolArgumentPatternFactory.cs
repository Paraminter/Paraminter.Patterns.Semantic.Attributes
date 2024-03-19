namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="IBoolArgumentPatternFactory"/>
public sealed class BoolArgumentPatternFactory : IBoolArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="BoolArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="bool"/> arguments.</summary>
    public BoolArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, bool> IBoolArgumentPatternFactory.Create() => NonNullableArgumentPattern<bool>.Instance;
}
