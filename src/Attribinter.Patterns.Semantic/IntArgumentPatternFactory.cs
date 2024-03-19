namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="IIntArgumentPatternFactory"/>
public sealed class IntArgumentPatternFactory : IIntArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="IntArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="int"/> arguments.</summary>
    public IntArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, int> IIntArgumentPatternFactory.Create() => NonNullableArgumentPattern<int>.Instance;
}
