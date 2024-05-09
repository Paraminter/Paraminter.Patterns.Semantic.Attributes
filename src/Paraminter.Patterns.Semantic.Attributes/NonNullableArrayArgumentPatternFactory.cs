namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="INonNullableArrayArgumentPatternFactory"/>
public sealed class NonNullableArrayArgumentPatternFactory : INonNullableArrayArgumentPatternFactory
{
    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="NonNullableArrayArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable array-valued arguments.</summary>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    public NonNullableArrayArgumentPatternFactory(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> INonNullableArrayArgumentPatternFactory.Create<TElement>(IArgumentPattern<TypedConstant, TElement> elementPattern)
    {
        if (elementPattern is null)
        {
            throw new ArgumentNullException(nameof(elementPattern));
        }

        return new NonNullableArrayArgumentPattern<TElement>(elementPattern, MatchResultFactoryProvider);
    }

    internal sealed class NonNullableArrayArgumentPattern<TElement> : IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>
    {
        private readonly IArgumentPattern<TypedConstant, TElement> ElementPattern;

        private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

        public NonNullableArrayArgumentPattern(IArgumentPattern<TypedConstant, TElement> elementPattern, IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            ElementPattern = elementPattern;

            MatchResultFactoryProvider = matchResultFactoryProvider;
        }

        IArgumentPatternMatchResult<IReadOnlyList<TElement>> IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>.TryMatch(TypedConstant argument)
        {
            if (argument.Kind is not TypedConstantKind.Array)
            {
                return CreateUnsuccessful();
            }

            if (argument.IsNull)
            {
                return CreateUnsuccessful();
            }

            var values = new TElement[argument.Values.Length];

            for (var i = 0; i < values.Length; i++)
            {
                var elementResult = ElementPattern.TryMatch(argument.Values[i]);

                if (elementResult.WasSuccessful is false)
                {
                    return CreateUnsuccessful();
                }

                values[i] = elementResult.GetMatchedArgument();
            }

            return CreateSuccessful(values);
        }

        private IArgumentPatternMatchResult<IReadOnlyList<TElement>> CreateSuccessful(IReadOnlyList<TElement> matchedArgument) => MatchResultFactoryProvider.Successful.Create(matchedArgument);
        private IArgumentPatternMatchResult<IReadOnlyList<TElement>> CreateUnsuccessful() => MatchResultFactoryProvider.Unsuccessful.Create<IReadOnlyList<TElement>>();
    }
}
