namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases.UShortCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch
{
    private readonly IPatternFixture<ushort> Fixture = PatternFixtureFactory.CreateUShort();

    [Fact]
    public void UShortAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [UShortAttribute(1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_UShort_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute((ushort)1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Int_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(1)]
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

    private IArgumentPatternMatchResult<ushort> Target(
        TypedConstant argument)
    {
        return Fixture.Sut.TryMatch(argument);
    }

    [AssertionMethod]
    private void Successful(
        ushort matchedArgument,
        string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<ushort>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(
        string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<ushort>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<ushort>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
