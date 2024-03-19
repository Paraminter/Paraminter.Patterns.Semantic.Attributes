namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="string"/> arguments.</summary>
public interface INonNullableStringArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="string"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, string> Create();
}
