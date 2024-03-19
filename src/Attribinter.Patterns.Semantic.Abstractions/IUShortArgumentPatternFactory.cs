namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="ushort"/> arguments.</summary>
public interface IUShortArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="ushort"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, ushort> Create();
}
