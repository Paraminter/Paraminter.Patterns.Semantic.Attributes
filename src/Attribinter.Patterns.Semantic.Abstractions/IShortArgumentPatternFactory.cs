namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="short"/> arguments.</summary>
public interface IShortArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="short"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, short> Create();
}
