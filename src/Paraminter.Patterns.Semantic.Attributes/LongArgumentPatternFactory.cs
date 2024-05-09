namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="ILongArgumentPatternFactory"/>
public sealed class LongArgumentPatternFactory : ILongArgumentPatternFactory
{
    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="LongArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="long"/> arguments.</summary>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    public LongArgumentPatternFactory(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, long> ILongArgumentPatternFactory.Create() => new NonNullableArgumentPattern<long>(MatchResultFactoryProvider);
}
