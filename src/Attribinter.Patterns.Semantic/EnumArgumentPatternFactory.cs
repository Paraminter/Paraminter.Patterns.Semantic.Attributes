namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="IEnumArgumentPatternFactory"/>
public sealed class EnumArgumentPatternFactory : IEnumArgumentPatternFactory
{
    private static readonly IReadOnlyDictionary<Type, Func<Type, TypedConstant, ArgumentPatternMatchResult<object>>> PatternDelegates = new Dictionary<Type, Func<Type, TypedConstant, ArgumentPatternMatchResult<object>>>()
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

    /// <summary>Instantiates a <see cref="EnumArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching enum arguments.</summary>
    public EnumArgumentPatternFactory() { }

    IArgumentPattern<TypedConstant, TEnum> IEnumArgumentPatternFactory.Create<TEnum>()
    {
        if (PatternDelegates.TryGetValue(typeof(TEnum).GetEnumUnderlyingType(), out var nonGenericPatternDelegate) is false)
        {
            return ErrorArgumentPattern<TEnum>.Instance;
        }

        return new EnumArgumentPattern<TEnum>(nonGenericPatternDelegate);
    }

    private static Func<Type, TypedConstant, ArgumentPatternMatchResult<object>> CreateNonGenericPatternDelegate<TUnderlying>(Func<Type, TUnderlying, object> factoryDelegate)
    {
        return pattern;

        ArgumentPatternMatchResult<object> pattern(Type enumType, TypedConstant argument)
        {
            if (argument.Value is not TUnderlying matchingArgument)
            {
                return ArgumentPatternMatchResult.CreateUnsuccessful<object>();
            }

            return ArgumentPatternMatchResult.CreateSuccessful(factoryDelegate(enumType, matchingArgument));
        }
    }

    private sealed class EnumArgumentPattern<TEnum> : IArgumentPattern<TypedConstant, TEnum>
    {
        private readonly Func<Type, TypedConstant, ArgumentPatternMatchResult<object>> NonGenericPatternDelegate;

        public EnumArgumentPattern(Func<Type, TypedConstant, ArgumentPatternMatchResult<object>> nonGenericPattern)
        {
            NonGenericPatternDelegate = nonGenericPattern;
        }

        ArgumentPatternMatchResult<TEnum> IArgumentPattern<TypedConstant, TEnum>.TryMatch(TypedConstant argument)
        {
            if (argument.Kind is not TypedConstantKind.Enum)
            {
                return CreateUnsuccessful();
            }

            var nonGenericResult = NonGenericPatternDelegate(typeof(TEnum), argument);

            if (nonGenericResult.Successful is false)
            {
                return CreateUnsuccessful();
            }

            return CreateSuccessful((TEnum)nonGenericResult.GetMatchedArgument());
        }

        private static ArgumentPatternMatchResult<TEnum> CreateSuccessful(TEnum matchedArgument) => ArgumentPatternMatchResult.CreateSuccessful(matchedArgument);
        private static ArgumentPatternMatchResult<TEnum> CreateUnsuccessful() => ArgumentPatternMatchResult.CreateUnsuccessful<TEnum>();
    }
}
