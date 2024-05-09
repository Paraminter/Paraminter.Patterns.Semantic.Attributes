namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullBoolArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            null!,
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullByteArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            null!,
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullSByteArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            null!,
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullCharArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            null!,
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullShortArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            null!,
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullUShortArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            null!,
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullIntArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            null!,
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullUIntArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            null!,
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullLongArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            null!,
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullULongArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            null!,
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullFloatArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            null!,
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullDoubleArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            null!,
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullEnumArgumentPatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            null!,
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullStringArgumentPatternFactoryProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            null!,
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullObjectArgumentPatternFactoryProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            null!,
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullTypeArgumentPatternFactoryProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            null!,
            Mock.Of<IArrayArgumentPatternFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullArrayArgumentPatternFactoryProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(
            Mock.Of<IBoolArgumentPatternFactory>(),
            Mock.Of<IByteArgumentPatternFactory>(),
            Mock.Of<ISByteArgumentPatternFactory>(),
            Mock.Of<ICharArgumentPatternFactory>(),
            Mock.Of<IShortArgumentPatternFactory>(),
            Mock.Of<IUShortArgumentPatternFactory>(),
            Mock.Of<IIntArgumentPatternFactory>(),
            Mock.Of<IUIntArgumentPatternFactory>(),
            Mock.Of<ILongArgumentPatternFactory>(),
            Mock.Of<IULongArgumentPatternFactory>(),
            Mock.Of<IFloatArgumentPatternFactory>(),
            Mock.Of<IDoubleArgumentPatternFactory>(),
            Mock.Of<IEnumArgumentPatternFactory>(),
            Mock.Of<IStringArgumentPatternFactoryProvider>(),
            Mock.Of<IObjectArgumentPatternFactoryProvider>(),
            Mock.Of<ITypeArgumentPatternFactoryProvider>(),
            Mock.Of<IArrayArgumentPatternFactoryProvider>());

        Assert.NotNull(result);
    }

    private static ArgumentPatternFactoryProvider Target(
        IBoolArgumentPatternFactory boolArgumentPatternFactory,
        IByteArgumentPatternFactory byteArgumentPatternFactory,
        ISByteArgumentPatternFactory sbyteArgumentPatternFactory,
        ICharArgumentPatternFactory charArgumentPatternFactory,
        IShortArgumentPatternFactory shortArgumentPatternFactory,
        IUShortArgumentPatternFactory ushortArgumentPatternFactory,
        IIntArgumentPatternFactory intArgumentPatternFactory,
        IUIntArgumentPatternFactory uintArgumentPatternFactory,
        ILongArgumentPatternFactory longArgumentPatternFactory,
        IULongArgumentPatternFactory ulongArgumentPatternFactory,
        IFloatArgumentPatternFactory floatArgumentPatternFactory,
        IDoubleArgumentPatternFactory doubleArgumentPatternFactory,
        IEnumArgumentPatternFactory enumArgumentPatternFactory,
        IStringArgumentPatternFactoryProvider stringArgumentPatternFactoryProvider,
        IObjectArgumentPatternFactoryProvider objectArgumentPatternFactoryProvider,
        ITypeArgumentPatternFactoryProvider typeArgumentPatternFactoryProvider,
        IArrayArgumentPatternFactoryProvider arrayArgumentPatternFactoryProvider)
    {
        return new(
            boolArgumentPatternFactory,
            byteArgumentPatternFactory,
            sbyteArgumentPatternFactory,
            charArgumentPatternFactory,
            shortArgumentPatternFactory,
            ushortArgumentPatternFactory,
            intArgumentPatternFactory,
            uintArgumentPatternFactory,
            longArgumentPatternFactory,
            ulongArgumentPatternFactory,
            floatArgumentPatternFactory,
            doubleArgumentPatternFactory,
            enumArgumentPatternFactory,
            stringArgumentPatternFactoryProvider,
            objectArgumentPatternFactoryProvider,
            typeArgumentPatternFactoryProvider,
            arrayArgumentPatternFactoryProvider);
    }
}
