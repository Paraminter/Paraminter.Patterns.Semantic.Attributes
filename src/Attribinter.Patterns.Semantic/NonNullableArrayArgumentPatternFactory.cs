namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="INonNullableArrayArgumentPatternFactory"/>
public sealed class NonNullableArrayArgumentPatternFactory : INonNullableArrayArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="NonNullableArrayArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable array-valued arguments.</summary>
    public NonNullableArrayArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> INonNullableArrayArgumentPatternFactory.Create<TElement>(IArgumentPattern<TypedConstant, TElement> elementPattern)
    {
        if (elementPattern is null)
        {
            throw new ArgumentNullException(nameof(elementPattern));
        }

        return new NonNullableArrayArgumentPattern<TElement>(elementPattern);
    }

    internal sealed class NonNullableArrayArgumentPattern<TElement> : IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>
    {
        private readonly IArgumentPattern<TypedConstant, TElement> ElementPattern;

        public NonNullableArrayArgumentPattern(IArgumentPattern<TypedConstant, TElement> elementPattern)
        {
            ElementPattern = elementPattern;
        }

        ArgumentPatternMatchResult<IReadOnlyList<TElement>> IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>.TryMatch(TypedConstant argument)
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

                if (elementResult.Successful is false)
                {
                    return CreateUnsuccessful();
                }

                values[i] = elementResult.GetMatchedArgument();
            }

            return CreateSuccessful(values);
        }

        private static ArgumentPatternMatchResult<IReadOnlyList<TElement>> CreateSuccessful(IReadOnlyList<TElement> matchedArgument) => ArgumentPatternMatchResult.CreateSuccessful(matchedArgument);
        private static ArgumentPatternMatchResult<IReadOnlyList<TElement>> CreateUnsuccessful() => ArgumentPatternMatchResult.CreateUnsuccessful<IReadOnlyList<TElement>>();
    }
}
