namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases.ByteCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch
{
    private readonly IPatternFixture<byte> Fixture = PatternFixtureFactory.CreateByte();

    [Fact]
    public void ByteAttribute_Byte_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [ByteAttribute(1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Byte_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute((byte)1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Int_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(42)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void ObjectAttribute_String_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute("")]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    private IArgumentPatternMatchResult<byte> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(byte matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<byte>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<byte>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<byte>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
