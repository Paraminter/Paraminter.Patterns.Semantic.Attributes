namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="ITypeSymbol"/> arguments.</summary>
/// <remarks>Attribute arguments of type <see cref="Type"/> will match the created patterns, as Roslyn uses <see cref="ITypeSymbol"/> to represent <see cref="Type"/>.</remarks>
public interface INonNullableTypeArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="ITypeSymbol"/> .</summary>
    /// <remarks>Attribute arguments of type <see cref="Type"/> will match the created pattern, as Roslyn uses <see cref="ITypeSymbol"/> to represent <see cref="Type"/>.</remarks>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, ITypeSymbol> Create();
}
