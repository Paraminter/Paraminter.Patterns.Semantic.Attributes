namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Moq;

internal static class ProviderFixtureFactory
{
    public static IProviderFixture Create()
    {
        Mock<IBoolArgumentPatternFactory> boolMock = new();
        Mock<IByteArgumentPatternFactory> byteMock = new();
        Mock<ISByteArgumentPatternFactory> sbyteMock = new();
        Mock<ICharArgumentPatternFactory> charMock = new();
        Mock<IShortArgumentPatternFactory> shortMock = new();
        Mock<IUShortArgumentPatternFactory> ushortMock = new();
        Mock<IIntArgumentPatternFactory> intMock = new();
        Mock<IUIntArgumentPatternFactory> uintMock = new();
        Mock<ILongArgumentPatternFactory> longMock = new();
        Mock<IULongArgumentPatternFactory> ulongMock = new();
        Mock<IFloatArgumentPatternFactory> floatMock = new();
        Mock<IDoubleArgumentPatternFactory> doubleMock = new();
        Mock<IEnumArgumentPatternFactory> enumMock = new();

        Mock<IStringArgumentPatternFactoryProvider> stringMock = new();
        Mock<IObjectArgumentPatternFactoryProvider> objectMock = new();
        Mock<ITypeArgumentPatternFactoryProvider> typeMock = new();
        Mock<IArrayArgumentPatternFactoryProvider> arrayMock = new();

        ArgumentPatternFactoryProvider sut = new(boolMock.Object, byteMock.Object, sbyteMock.Object, charMock.Object, shortMock.Object, ushortMock.Object, intMock.Object, uintMock.Object, longMock.Object, ulongMock.Object, floatMock.Object, doubleMock.Object, enumMock.Object, stringMock.Object, objectMock.Object, typeMock.Object, arrayMock.Object);

        return new ProviderFixture(sut, boolMock, byteMock, sbyteMock, charMock, shortMock, ushortMock, intMock, uintMock, longMock, ulongMock, floatMock, doubleMock, enumMock, stringMock, objectMock, typeMock, arrayMock);
    }

    private sealed class ProviderFixture : IProviderFixture
    {
        private readonly IArgumentPatternFactoryProvider Sut;

        private readonly Mock<IBoolArgumentPatternFactory> BoolMock;
        private readonly Mock<IByteArgumentPatternFactory> ByteMock;
        private readonly Mock<ISByteArgumentPatternFactory> SByteMock;
        private readonly Mock<ICharArgumentPatternFactory> CharMock;
        private readonly Mock<IShortArgumentPatternFactory> ShortMock;
        private readonly Mock<IUShortArgumentPatternFactory> UShortMock;
        private readonly Mock<IIntArgumentPatternFactory> IntMock;
        private readonly Mock<IUIntArgumentPatternFactory> UIntMock;
        private readonly Mock<ILongArgumentPatternFactory> LongMock;
        private readonly Mock<IULongArgumentPatternFactory> ULongMock;
        private readonly Mock<IFloatArgumentPatternFactory> FloatMock;
        private readonly Mock<IDoubleArgumentPatternFactory> DoubleMock;
        private readonly Mock<IEnumArgumentPatternFactory> EnumMock;

        private readonly Mock<IStringArgumentPatternFactoryProvider> StringMock;
        private readonly Mock<IObjectArgumentPatternFactoryProvider> ObjectMock;
        private readonly Mock<ITypeArgumentPatternFactoryProvider> TypeMock;
        private readonly Mock<IArrayArgumentPatternFactoryProvider> ArrayMock;

        public ProviderFixture(
            IArgumentPatternFactoryProvider sut,
            Mock<IBoolArgumentPatternFactory> boolMock,
            Mock<IByteArgumentPatternFactory> byteMock,
            Mock<ISByteArgumentPatternFactory> sbyteMock,
            Mock<ICharArgumentPatternFactory> charMock,
            Mock<IShortArgumentPatternFactory> shortMock,
            Mock<IUShortArgumentPatternFactory> ushortMock,
            Mock<IIntArgumentPatternFactory> intMock,
            Mock<IUIntArgumentPatternFactory> uintMock,
            Mock<ILongArgumentPatternFactory> longMock,
            Mock<IULongArgumentPatternFactory> ulongMock,
            Mock<IFloatArgumentPatternFactory> floatMock,
            Mock<IDoubleArgumentPatternFactory> doubleMock,
            Mock<IEnumArgumentPatternFactory> enumMock,
            Mock<IStringArgumentPatternFactoryProvider> stringMock,
            Mock<IObjectArgumentPatternFactoryProvider> objectMock,
            Mock<ITypeArgumentPatternFactoryProvider> typeMock,
            Mock<IArrayArgumentPatternFactoryProvider> arrayMock)
        {
            Sut = sut;

            BoolMock = boolMock;
            ByteMock = byteMock;
            SByteMock = sbyteMock;
            CharMock = charMock;
            ShortMock = shortMock;
            UShortMock = ushortMock;
            IntMock = intMock;
            UIntMock = uintMock;
            LongMock = longMock;
            ULongMock = ulongMock;
            FloatMock = floatMock;
            DoubleMock = doubleMock;
            EnumMock = enumMock;

            StringMock = stringMock;
            ObjectMock = objectMock;
            TypeMock = typeMock;
            ArrayMock = arrayMock;
        }

        IArgumentPatternFactoryProvider IProviderFixture.Sut => Sut;

        Mock<IBoolArgumentPatternFactory> IProviderFixture.BoolMock => BoolMock;
        Mock<IByteArgumentPatternFactory> IProviderFixture.ByteMock => ByteMock;
        Mock<ISByteArgumentPatternFactory> IProviderFixture.SByteMock => SByteMock;
        Mock<ICharArgumentPatternFactory> IProviderFixture.CharMock => CharMock;
        Mock<IShortArgumentPatternFactory> IProviderFixture.ShortMock => ShortMock;
        Mock<IUShortArgumentPatternFactory> IProviderFixture.UShortMock => UShortMock;
        Mock<IIntArgumentPatternFactory> IProviderFixture.IntMock => IntMock;
        Mock<IUIntArgumentPatternFactory> IProviderFixture.UIntMock => UIntMock;
        Mock<ILongArgumentPatternFactory> IProviderFixture.LongMock => LongMock;
        Mock<IULongArgumentPatternFactory> IProviderFixture.ULongMock => ULongMock;
        Mock<IFloatArgumentPatternFactory> IProviderFixture.FloatMock => FloatMock;
        Mock<IDoubleArgumentPatternFactory> IProviderFixture.DoubleMock => DoubleMock;
        Mock<IEnumArgumentPatternFactory> IProviderFixture.EnumMock => EnumMock;

        Mock<IStringArgumentPatternFactoryProvider> IProviderFixture.StringMock => StringMock;
        Mock<IObjectArgumentPatternFactoryProvider> IProviderFixture.ObjectMock => ObjectMock;
        Mock<ITypeArgumentPatternFactoryProvider> IProviderFixture.TypeMock => TypeMock;
        Mock<IArrayArgumentPatternFactoryProvider> IProviderFixture.ArrayMock => ArrayMock;
    }
}
