namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="INullableTypeArgumentPatternFactory"/>
public sealed class NullableTypeArgumentPatternFactory
    : INullableTypeArgumentPatternFactory
{
    private readonly INonNullableTypeArgumentPatternFactory NonNullablePatternFactory;

    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="NullableTypeArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable <see cref="ITypeSymbol"/> arguments.</summary>
    /// <param name="nonNullablePatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="ITypeSymbol"/> arguments.</param>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    /// <remarks>Attribute arguments of type <see cref="Type"/> will match the created patterns, as Roslyn uses <see cref="ITypeSymbol"/> to represent <see cref="Type"/>.</remarks>
    public NullableTypeArgumentPatternFactory(
        INonNullableTypeArgumentPatternFactory nonNullablePatternFactory,
        IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        NonNullablePatternFactory = nonNullablePatternFactory ?? throw new ArgumentNullException(nameof(nonNullablePatternFactory));

        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, ITypeSymbol?> INullableTypeArgumentPatternFactory.Create() => new NullableArgumentPattern<ITypeSymbol>(NonNullablePatternFactory.Create(), MatchResultFactoryProvider);
}
