namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="INullableArrayArgumentPatternFactory"/>
public sealed class NullableArrayArgumentPatternFactory : INullableArrayArgumentPatternFactory
{
    private readonly INonNullableArrayArgumentPatternFactory NonNullablePatternFactory;

    /// <summary>Instantiates a <see cref="NullableArrayArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable array-valued arguments.</summary>
    /// <param name="nonNullablePatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable array-valued arguments.</param>
    public NullableArrayArgumentPatternFactory(INonNullableArrayArgumentPatternFactory nonNullablePatternFactory)
    {
        NonNullablePatternFactory = nonNullablePatternFactory ?? throw new ArgumentNullException(nameof(nonNullablePatternFactory));
    }

    IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> INullableArrayArgumentPatternFactory.Create<TElement>(IArgumentPattern<TypedConstant, TElement> elementPattern)
    {
        if (elementPattern is null)
        {
            throw new ArgumentNullException(nameof(elementPattern));
        }

        var nonNullablePattern = NonNullablePatternFactory.Create(elementPattern);

        return new NullableArrayArgumentPattern<TElement>(nonNullablePattern);
    }

    internal sealed class NullableArrayArgumentPattern<TElement> : IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?>
    {
        private readonly IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> NonNullableCollectionPattern;

        public NullableArrayArgumentPattern(IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> nonNullableCollectionPattern)
        {
            NonNullableCollectionPattern = nonNullableCollectionPattern;
        }

        ArgumentPatternMatchResult<IReadOnlyList<TElement>?> IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?>.TryMatch(TypedConstant argument)
        {
            if (argument.Kind is TypedConstantKind.Error)
            {
                return CreateUnsuccessful();
            }

            if (argument.IsNull)
            {
                return CreateSuccessful(null);
            }

            var nonNullableResult = NonNullableCollectionPattern.TryMatch(argument);

            if (nonNullableResult.Successful is false)
            {
                return CreateUnsuccessful();
            }

            return CreateSuccessful(nonNullableResult.GetMatchedArgument());
        }

        private static ArgumentPatternMatchResult<IReadOnlyList<TElement>?> CreateSuccessful(IReadOnlyList<TElement>? matchedArgument) => ArgumentPatternMatchResult.CreateSuccessful(matchedArgument);
        private static ArgumentPatternMatchResult<IReadOnlyList<TElement>?> CreateUnsuccessful() => ArgumentPatternMatchResult.CreateUnsuccessful<IReadOnlyList<TElement>?>();
    }
}
