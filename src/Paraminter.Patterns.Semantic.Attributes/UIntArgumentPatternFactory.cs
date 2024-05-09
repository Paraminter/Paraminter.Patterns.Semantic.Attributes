namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="IUIntArgumentPatternFactory"/>
public sealed class UIntArgumentPatternFactory : IUIntArgumentPatternFactory
{
    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="UIntArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="uint"/> arguments.</summary>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    public UIntArgumentPatternFactory(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, uint> IUIntArgumentPatternFactory.Create() => new NonNullableArgumentPattern<uint>(MatchResultFactoryProvider);
}
