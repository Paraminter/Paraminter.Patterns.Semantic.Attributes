namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="INullableArrayArgumentPatternFactory"/>
public sealed class NullableArrayArgumentPatternFactory : INullableArrayArgumentPatternFactory
{
    private readonly INonNullableArrayArgumentPatternFactory NonNullablePatternFactory;

    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="NullableArrayArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable array-valued arguments.</summary>
    /// <param name="nonNullablePatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable array-valued arguments.</param>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    public NullableArrayArgumentPatternFactory(INonNullableArrayArgumentPatternFactory nonNullablePatternFactory, IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        NonNullablePatternFactory = nonNullablePatternFactory ?? throw new ArgumentNullException(nameof(nonNullablePatternFactory));

        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> INullableArrayArgumentPatternFactory.Create<TElement>(IArgumentPattern<TypedConstant, TElement> elementPattern)
    {
        if (elementPattern is null)
        {
            throw new ArgumentNullException(nameof(elementPattern));
        }

        var nonNullablePattern = NonNullablePatternFactory.Create(elementPattern);

        return new NullableArrayArgumentPattern<TElement>(nonNullablePattern, MatchResultFactoryProvider);
    }

    internal sealed class NullableArrayArgumentPattern<TElement> : IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?>
    {
        private readonly IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> NonNullablePattern;

        private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

        public NullableArrayArgumentPattern(IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> nonNullablePattern, IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            NonNullablePattern = nonNullablePattern;

            MatchResultFactoryProvider = matchResultFactoryProvider;
        }

        IArgumentPatternMatchResult<IReadOnlyList<TElement>?> IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?>.TryMatch(TypedConstant argument)
        {
            if (argument.Kind is TypedConstantKind.Error)
            {
                return CreateUnsuccessful();
            }

            if (argument.IsNull)
            {
                return CreateSuccessful(null);
            }

            var nonNullableResult = NonNullablePattern.TryMatch(argument);

            if (nonNullableResult.WasSuccessful is false)
            {
                return CreateUnsuccessful();
            }

            return CreateSuccessful(nonNullableResult.GetMatchedArgument());
        }

        private IArgumentPatternMatchResult<IReadOnlyList<TElement>?> CreateSuccessful(IReadOnlyList<TElement>? matchedArgument) => MatchResultFactoryProvider.Successful.Create(matchedArgument);
        private IArgumentPatternMatchResult<IReadOnlyList<TElement>?> CreateUnsuccessful() => MatchResultFactoryProvider.Unsuccessful.Create<IReadOnlyList<TElement>?>();
    }
}
