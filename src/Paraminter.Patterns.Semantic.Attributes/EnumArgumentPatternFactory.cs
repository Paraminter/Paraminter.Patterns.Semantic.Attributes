namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="IEnumArgumentPatternFactory"/>
public sealed class EnumArgumentPatternFactory : IEnumArgumentPatternFactory
{
    private static readonly IReadOnlyDictionary<Type, Func<Type, TypedConstant, (bool Match, object? Result)>> PatternDelegates = new Dictionary<Type, Func<Type, TypedConstant, (bool Match, object? Result)>>()
    {
        { typeof(byte), CreateNonGenericPatternDelegate<byte>(static (enumType, value) => Enum.ToObject(enumType, value)) },
        { typeof(sbyte), CreateNonGenericPatternDelegate<sbyte>(static (enumType, value) => Enum.ToObject(enumType, value)) },
        { typeof(short), CreateNonGenericPatternDelegate<short>(static (enumType, value) => Enum.ToObject(enumType, value)) },
        { typeof(ushort), CreateNonGenericPatternDelegate<ushort>(static (enumType, value) => Enum.ToObject(enumType, value)) },
        { typeof(int), CreateNonGenericPatternDelegate<int>(static (enumType, value) => Enum.ToObject(enumType, value)) },
        { typeof(uint), CreateNonGenericPatternDelegate<uint>(static (enumType, value) => Enum.ToObject(enumType, value)) },
        { typeof(long), CreateNonGenericPatternDelegate<long>(static (enumType, value) => Enum.ToObject(enumType, value)) },
        { typeof(ulong), CreateNonGenericPatternDelegate<ulong>(static (enumType, value) => Enum.ToObject(enumType, value)) },
    };

    private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

    /// <summary>Instantiates a <see cref="EnumArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching enum arguments.</summary>
    /// <param name="matchResultFactoryProvider">Provides factories of <see cref="IArgumentPatternMatchResult{TMatchedArgument}"/>.</param>
    public EnumArgumentPatternFactory(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        MatchResultFactoryProvider = matchResultFactoryProvider ?? throw new ArgumentNullException(nameof(matchResultFactoryProvider));
    }

    IArgumentPattern<TypedConstant, TEnum> IEnumArgumentPatternFactory.Create<TEnum>()
    {
        if (PatternDelegates.TryGetValue(typeof(TEnum).GetEnumUnderlyingType(), out var nonGenericPatternDelegate) is false)
        {
            return new ErrorArgumentPattern<TEnum>(MatchResultFactoryProvider.Unsuccessful);
        }

        return new EnumArgumentPattern<TEnum>(nonGenericPatternDelegate, MatchResultFactoryProvider);
    }

    private static Func<Type, TypedConstant, (bool Match, object? Result)> CreateNonGenericPatternDelegate<TUnderlying>(Func<Type, TUnderlying, object> factoryDelegate)
    {
        return pattern;

        (bool Match, object? Result) pattern(Type enumType, TypedConstant argument)
        {
            if (argument.Value is not TUnderlying matchingArgument)
            {
                return (false, null);
            }

            return (true, factoryDelegate(enumType, matchingArgument));
        }
    }

    private sealed class EnumArgumentPattern<TEnum> : IArgumentPattern<TypedConstant, TEnum>
    {
        private readonly Func<Type, TypedConstant, (bool Match, object? Result)> NonGenericPatternDelegate;

        private readonly IArgumentPatternMatchResultFactoryProvider MatchResultFactoryProvider;

        public EnumArgumentPattern(Func<Type, TypedConstant, (bool Match, object? Result)> nonGenericPattern, IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            NonGenericPatternDelegate = nonGenericPattern;

            MatchResultFactoryProvider = matchResultFactoryProvider;
        }

        IArgumentPatternMatchResult<TEnum> IArgumentPattern<TypedConstant, TEnum>.TryMatch(TypedConstant argument)
        {
            if (argument.Kind is not TypedConstantKind.Enum)
            {
                return CreateUnsuccessful();
            }

            var (nonGenericMatch, nonGenericResult) = NonGenericPatternDelegate(typeof(TEnum), argument);

            if (nonGenericMatch is false)
            {
                return CreateUnsuccessful();
            }

            return CreateSuccessful((TEnum)nonGenericResult!);
        }

        private IArgumentPatternMatchResult<TEnum> CreateSuccessful(TEnum matchedArgument) => MatchResultFactoryProvider.Successful.Create(matchedArgument);
        private IArgumentPatternMatchResult<TEnum> CreateUnsuccessful() => MatchResultFactoryProvider.Unsuccessful.Create<TEnum>();
    }
}
