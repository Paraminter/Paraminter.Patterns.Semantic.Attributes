namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

internal static class PatternFixtureFactory
{
    public static IPatternFixture<bool> CreateBool()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, bool> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            IBoolArgumentPatternFactory factory = new BoolArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<byte> CreateByte()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, byte> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            IByteArgumentPatternFactory factory = new ByteArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<char> CreateChar()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, char> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            ICharArgumentPatternFactory factory = new CharArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<double> CreateDouble()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, double> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            IDoubleArgumentPatternFactory factory = new DoubleArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<float> CreateFloat()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, float> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            IFloatArgumentPatternFactory factory = new FloatArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<int> CreateInt()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, int> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            IIntArgumentPatternFactory factory = new IntArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<long> CreateLong()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, long> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            ILongArgumentPatternFactory factory = new LongArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<sbyte> CreateSByte()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, sbyte> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            ISByteArgumentPatternFactory factory = new SByteArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<short> CreateShort()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, short> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            IShortArgumentPatternFactory factory = new ShortArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<string> CreateString()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, string> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            INonNullableStringArgumentPatternFactory factory = new NonNullableStringArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<ITypeSymbol> CreateType()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, ITypeSymbol> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            INonNullableTypeArgumentPatternFactory factory = new NonNullableTypeArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<uint> CreateUInt()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, uint> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            IUIntArgumentPatternFactory factory = new UIntArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<ulong> CreateULong()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, ulong> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            IULongArgumentPatternFactory factory = new ULongArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<ushort> CreateUShort()
    {
        return Create(createPattern);

        static IArgumentPattern<TypedConstant, ushort> createPattern(IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            IUShortArgumentPatternFactory factory = new UShortArgumentPatternFactory(matchResultFactoryProvider);

            return factory.Create();
        }
    }

    private static PatternFixture<TOut> Create<TOut>(Func<IArgumentPatternMatchResultFactoryProvider, IArgumentPattern<TypedConstant, TOut>> patternDelegate)
    {
        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        var sut = patternDelegate(matchResultFactoryProviderMock.Object);

        return new PatternFixture<TOut>(sut, matchResultFactoryProviderMock);
    }

    private sealed class PatternFixture<TOut> : IPatternFixture<TOut>
    {
        private readonly IArgumentPattern<TypedConstant, TOut> Sut;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public PatternFixture(IArgumentPattern<TypedConstant, TOut> sut, Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IArgumentPattern<TypedConstant, TOut> IPatternFixture<TOut>.Sut => Sut;

        Mock<IArgumentPatternMatchResultFactoryProvider> IPatternFixture<TOut>.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
