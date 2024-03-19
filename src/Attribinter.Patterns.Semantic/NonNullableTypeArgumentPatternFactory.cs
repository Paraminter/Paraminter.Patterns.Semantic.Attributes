namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="INonNullableTypeArgumentPatternFactory"/>
public sealed class NonNullableTypeArgumentPatternFactory : INonNullableTypeArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="NonNullableTypeArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="ITypeSymbol"/> arguments.</summary>
    /// <remarks>Attribute arguments of type <see cref="Type"/> will match the created patterns, as Roslyn uses <see cref="ITypeSymbol"/> to represent <see cref="Type"/>.</remarks>
    public NonNullableTypeArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, ITypeSymbol> INonNullableTypeArgumentPatternFactory.Create() => NonNullableArgumentPattern<ITypeSymbol>.Instance;
}
