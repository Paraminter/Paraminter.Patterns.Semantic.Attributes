namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Moq;

internal interface IProviderFixture
{
    public abstract IArgumentPatternFactoryProvider Sut { get; }

    public abstract Mock<IBoolArgumentPatternFactory> BoolMock { get; }
    public abstract Mock<IByteArgumentPatternFactory> ByteMock { get; }
    public abstract Mock<ISByteArgumentPatternFactory> SByteMock { get; }
    public abstract Mock<ICharArgumentPatternFactory> CharMock { get; }
    public abstract Mock<IShortArgumentPatternFactory> ShortMock { get; }
    public abstract Mock<IUShortArgumentPatternFactory> UShortMock { get; }
    public abstract Mock<IIntArgumentPatternFactory> IntMock { get; }
    public abstract Mock<IUIntArgumentPatternFactory> UIntMock { get; }
    public abstract Mock<ILongArgumentPatternFactory> LongMock { get; }
    public abstract Mock<IULongArgumentPatternFactory> ULongMock { get; }
    public abstract Mock<IFloatArgumentPatternFactory> FloatMock { get; }
    public abstract Mock<IDoubleArgumentPatternFactory> DoubleMock { get; }
    public abstract Mock<IEnumArgumentPatternFactory> EnumMock { get; }

    public abstract Mock<IStringArgumentPatternFactoryProvider> StringMock { get; }
    public abstract Mock<IObjectArgumentPatternFactoryProvider> ObjectMock { get; }
    public abstract Mock<ITypeArgumentPatternFactoryProvider> TypeMock { get; }
    public abstract Mock<IArrayArgumentPatternFactoryProvider> ArrayMock { get; }
}
