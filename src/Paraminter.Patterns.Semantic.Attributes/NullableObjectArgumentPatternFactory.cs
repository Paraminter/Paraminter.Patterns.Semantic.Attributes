namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="INullableObjectArgumentPatternFactory"/>
public sealed class NullableObjectArgumentPatternFactory : INullableObjectArgumentPatternFactory
{
    private readonly INonNullableObjectArgumentPatternFactory NonNullablePatternFactory;

    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="NullableObjectArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable <see cref="object"/> arguments.</summary>
    /// <param name="nonNullablePatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="object"/> arguments.</param>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    public NullableObjectArgumentPatternFactory(INonNullableObjectArgumentPatternFactory nonNullablePatternFactory, IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        NonNullablePatternFactory = nonNullablePatternFactory ?? throw new ArgumentNullException(nameof(nonNullablePatternFactory));

        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, object?> INullableObjectArgumentPatternFactory.Create() => new NullableObjectArgumentPattern(NonNullablePatternFactory.Create(), MatchResultFactoryProvider);

    private sealed class NullableObjectArgumentPattern : IArgumentPattern<TypedConstant, object?>
    {
        private readonly IArgumentPattern<TypedConstant, object> NonNullablePattern;

        private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

        public NullableObjectArgumentPattern(IArgumentPattern<TypedConstant, object> nonNullablePattern, IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            NonNullablePattern = nonNullablePattern;

            MatchResultFactoryProvider = matchResultFactoryProvider;
        }

        IArgumentPatternMatchResult<object?> IArgumentPattern<TypedConstant, object?>.TryMatch(TypedConstant argument)
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

        private IArgumentPatternMatchResult<object?> CreateSuccessful(object? matchedArgument) => MatchResultFactoryProvider.Successful.Create(matchedArgument);
        private IArgumentPatternMatchResult<object?> CreateUnsuccessful() => MatchResultFactoryProvider.Unsuccessful.Create<object?>();
    }
}
