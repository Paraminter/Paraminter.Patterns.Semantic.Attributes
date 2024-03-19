namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="sbyte"/> arguments.</summary>
public interface ISByteArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="sbyte"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, sbyte> Create();
}
