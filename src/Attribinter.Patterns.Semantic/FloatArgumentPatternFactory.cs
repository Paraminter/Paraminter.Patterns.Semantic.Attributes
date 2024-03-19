namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="IFloatArgumentPatternFactory"/>
public sealed class FloatArgumentPatternFactory : IFloatArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="FloatArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="float"/> arguments.</summary>
    public FloatArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, float> IFloatArgumentPatternFactory.Create() => NonNullableArgumentPattern<float>.Instance;
}
