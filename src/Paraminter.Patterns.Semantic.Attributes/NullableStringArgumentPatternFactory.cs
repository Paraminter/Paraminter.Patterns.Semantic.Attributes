namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="INullableStringArgumentPatternFactory"/>
public sealed class NullableStringArgumentPatternFactory : INullableStringArgumentPatternFactory
{
    private readonly INonNullableStringArgumentPatternFactory NonNullablePatternFactory;

    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="NullableStringArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable <see cref="string"/> arguments.</summary>
    /// <param name="nonNullablePatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="string"/> arguments.</param>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    public NullableStringArgumentPatternFactory(INonNullableStringArgumentPatternFactory nonNullablePatternFactory, IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        NonNullablePatternFactory = nonNullablePatternFactory ?? throw new ArgumentNullException(nameof(nonNullablePatternFactory));

        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, string?> INullableStringArgumentPatternFactory.Create() => new NullableArgumentPattern<string>(NonNullablePatternFactory.Create(), MatchResultFactoryProvider);
}
