namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases.LongCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch
{
    private readonly IPatternFixture<long> Fixture = PatternFixtureFactory.CreateLong();

    [Fact]
    public void LongAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [LongAttribute(1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Long_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute((long)1)]
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

    private IArgumentPatternMatchResult<long> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(long matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<long>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<long>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<long>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
