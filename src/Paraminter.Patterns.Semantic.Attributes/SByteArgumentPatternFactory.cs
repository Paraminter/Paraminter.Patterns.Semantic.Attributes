namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="ISByteArgumentPatternFactory"/>
public sealed class SByteArgumentPatternFactory : ISByteArgumentPatternFactory
{
    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="SByteArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="sbyte"/> arguments.</summary>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    public SByteArgumentPatternFactory(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, sbyte> ISByteArgumentPatternFactory.Create() => new NonNullableArgumentPattern<sbyte>(MatchResultFactoryProvider);
}
