namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Moq;

internal sealed class ProviderContext
{
    public static ProviderContext Create()
    {
        var boolArgumentPatternFactory = Mock.Of<IBoolArgumentPatternFactory>();
        var byteArgumentPatternFactory = Mock.Of<IByteArgumentPatternFactory>();
        var sbyteArgumentPatternFactory = Mock.Of<ISByteArgumentPatternFactory>();
        var charArgumentPatternFactory = Mock.Of<ICharArgumentPatternFactory>();
        var shortArgumentPatternFactory = Mock.Of<IShortArgumentPatternFactory>();
        var ushortArgumentPatternFactory = Mock.Of<IUShortArgumentPatternFactory>();
        var intArgumentPatternFactory = Mock.Of<IIntArgumentPatternFactory>();
        var uintArgumentPatternFactory = Mock.Of<IUIntArgumentPatternFactory>();
        var longArgumentPatternFactory = Mock.Of<ILongArgumentPatternFactory>();
        var ulongArgumentPatternFactory = Mock.Of<IULongArgumentPatternFactory>();
        var floatArgumentPatternFactory = Mock.Of<IFloatArgumentPatternFactory>();
        var doubleArgumentPatternFactory = Mock.Of<IDoubleArgumentPatternFactory>();
        var enumArgumentPatternFactory = Mock.Of<IEnumArgumentPatternFactory>();

        var stringArgumentPatternFactoryProvider = Mock.Of<IStringArgumentPatternFactoryProvider>();
        var objectArgumentPatternFactoryProvider = Mock.Of<IObjectArgumentPatternFactoryProvider>();
        var typeArgumentPatternFactoryProvider = Mock.Of<ITypeArgumentPatternFactoryProvider>();
        var arrayArgumentPatternFactoryProvider = Mock.Of<IArrayArgumentPatternFactoryProvider>();

        ArgumentPatternFactoryProvider provider = new(boolArgumentPatternFactory, byteArgumentPatternFactory, sbyteArgumentPatternFactory, charArgumentPatternFactory, shortArgumentPatternFactory,
            ushortArgumentPatternFactory, intArgumentPatternFactory, uintArgumentPatternFactory, longArgumentPatternFactory, ulongArgumentPatternFactory, floatArgumentPatternFactory, doubleArgumentPatternFactory,
            enumArgumentPatternFactory, stringArgumentPatternFactoryProvider, objectArgumentPatternFactoryProvider, typeArgumentPatternFactoryProvider, arrayArgumentPatternFactoryProvider);

        return new(provider, boolArgumentPatternFactory, byteArgumentPatternFactory, sbyteArgumentPatternFactory, charArgumentPatternFactory, shortArgumentPatternFactory,
            ushortArgumentPatternFactory, intArgumentPatternFactory, uintArgumentPatternFactory, longArgumentPatternFactory, ulongArgumentPatternFactory, floatArgumentPatternFactory, doubleArgumentPatternFactory,
            enumArgumentPatternFactory, stringArgumentPatternFactoryProvider, objectArgumentPatternFactoryProvider, typeArgumentPatternFactoryProvider, arrayArgumentPatternFactoryProvider);
    }

    public IArgumentPatternFactoryProvider Provider { get; }

    public IBoolArgumentPatternFactory Bool { get; }
    public IByteArgumentPatternFactory Byte { get; }
    public ISByteArgumentPatternFactory SByte { get; }
    public ICharArgumentPatternFactory Char { get; }
    public IShortArgumentPatternFactory Short { get; }
    public IUShortArgumentPatternFactory UShort { get; }
    public IIntArgumentPatternFactory Int { get; }
    public IUIntArgumentPatternFactory UInt { get; }
    public ILongArgumentPatternFactory Long { get; }
    public IULongArgumentPatternFactory ULong { get; }
    public IFloatArgumentPatternFactory Float { get; }
    public IDoubleArgumentPatternFactory Double { get; }
    public IEnumArgumentPatternFactory Enum { get; }

    public IStringArgumentPatternFactoryProvider String { get; }
    public IObjectArgumentPatternFactoryProvider Object { get; }
    public ITypeArgumentPatternFactoryProvider Type { get; }
    public IArrayArgumentPatternFactoryProvider Array { get; }

    public ProviderContext(IArgumentPatternFactoryProvider provider, IBoolArgumentPatternFactory boolArgumentPatternFactory, IByteArgumentPatternFactory byteArgumentPatternFactory, ISByteArgumentPatternFactory sbyteArgumentPatternFactory,
        ICharArgumentPatternFactory charArgumentPatternFactory, IShortArgumentPatternFactory shortArgumentPatternFactory, IUShortArgumentPatternFactory ushortArgumentPatternFactory, IIntArgumentPatternFactory intArgumentPatternFactory,
        IUIntArgumentPatternFactory uintArgumentPatternFactory, ILongArgumentPatternFactory longArgumentPatternFactory, IULongArgumentPatternFactory ulongArgumentPatternFactory, IFloatArgumentPatternFactory floatArgumentPatternFactory,
        IDoubleArgumentPatternFactory doubleArgumentPatternFactory, IEnumArgumentPatternFactory enumArgumentPatternFactory, IStringArgumentPatternFactoryProvider stringArgumentPatternFactoryProvider,
        IObjectArgumentPatternFactoryProvider objectArgumentPatternFactoryProvider, ITypeArgumentPatternFactoryProvider typeArgumentPatternFactoryProvider, IArrayArgumentPatternFactoryProvider arrayArgumentPatternFactoryProvider)
    {
        Provider = provider;

        Byte = byteArgumentPatternFactory;
        Bool = boolArgumentPatternFactory;
        SByte = sbyteArgumentPatternFactory;
        Char = charArgumentPatternFactory;
        Short = shortArgumentPatternFactory;
        UShort = ushortArgumentPatternFactory;
        Int = intArgumentPatternFactory;
        UInt = uintArgumentPatternFactory;
        Long = longArgumentPatternFactory;
        ULong = ulongArgumentPatternFactory;
        Float = floatArgumentPatternFactory;
        Double = doubleArgumentPatternFactory;
        Enum = enumArgumentPatternFactory;

        String = stringArgumentPatternFactoryProvider;
        Object = objectArgumentPatternFactoryProvider;
        Type = typeArgumentPatternFactoryProvider;
        Array = arrayArgumentPatternFactoryProvider;
    }
}
