namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void Null_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(null)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Array_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(new object[0])]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute((bool)42)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    private static IArgumentPatternMatchResult<TOut> Target<TOut>(IPatternFixture<TOut> fixture, TypedConstant argument) => fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private static void Unsuccessful(string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<bool>>();

        var fixture = PatternFixtureFactory.CreateBool();

        fixture.MatchResultFactoryProviderMock.Setup(static (provider) => provider.Unsuccessful.Create<bool>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(fixture, argument);

        Assert.Same(matchResult, result);
    }
}
