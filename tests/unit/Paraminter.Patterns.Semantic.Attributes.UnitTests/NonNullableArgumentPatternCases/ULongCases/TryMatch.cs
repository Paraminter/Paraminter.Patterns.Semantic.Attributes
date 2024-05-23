namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases.ULongCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch
{
    private readonly IPatternFixture<ulong> Fixture = PatternFixtureFactory.CreateULong();

    [Fact]
    public void ULongAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [ULongAttribute(1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_ULong_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute((ulong)1)]
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

    private IArgumentPatternMatchResult<ulong> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(ulong matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<ulong>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<ulong>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<ulong>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
