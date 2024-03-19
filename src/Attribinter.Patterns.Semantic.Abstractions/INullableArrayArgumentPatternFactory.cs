namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

using System.Collections.Generic;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable array-valued arguments.</summary>
public interface INullableArrayArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are either <see langword="null"/> or arrays with elements that all match the provided pattern.</summary>
    /// <typeparam name="TElement">The element-type of the arguments matched by the created pattern.</typeparam>
    /// <param name="elementPattern">The pattern of each element of the matched arguments.</param>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> Create<TElement>(IArgumentPattern<TypedConstant, TElement> elementPattern);
}
