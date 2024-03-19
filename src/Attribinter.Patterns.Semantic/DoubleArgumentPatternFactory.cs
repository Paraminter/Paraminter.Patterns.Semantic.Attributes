namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="IDoubleArgumentPatternFactory"/>
public sealed class DoubleArgumentPatternFactory : IDoubleArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="DoubleArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="double"/> arguments.</summary>
    public DoubleArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, double> IDoubleArgumentPatternFactory.Create() => NonNullableArgumentPattern<double>.Instance;
}
