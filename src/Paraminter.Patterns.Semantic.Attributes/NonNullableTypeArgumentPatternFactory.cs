namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="INonNullableTypeArgumentPatternFactory"/>
public sealed class NonNullableTypeArgumentPatternFactory : INonNullableTypeArgumentPatternFactory
{
    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="NonNullableTypeArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="ITypeSymbol"/> arguments.</summary>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    /// <remarks>Attribute arguments of type <see cref="Type"/> will match the created patterns, as Roslyn uses <see cref="ITypeSymbol"/> to represent <see cref="Type"/>.</remarks>
    public NonNullableTypeArgumentPatternFactory(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, ITypeSymbol> INonNullableTypeArgumentPatternFactory.Create() => new NonNullableArgumentPattern<ITypeSymbol>(MatchResultFactoryProvider);
}
