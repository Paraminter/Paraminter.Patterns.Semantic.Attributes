namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="ICharArgumentPatternFactory"/>
public sealed class CharArgumentPatternFactory : ICharArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="CharArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="char"/> arguments.</summary>
    public CharArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, char> ICharArgumentPatternFactory.Create() => NonNullableArgumentPattern<char>.Instance;
}
