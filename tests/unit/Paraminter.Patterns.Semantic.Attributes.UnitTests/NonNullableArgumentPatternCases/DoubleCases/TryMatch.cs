namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases.DoubleCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void DoubleAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [DoubleAttribute(3.14)]
            public class Foo { }
            """;

        Successful(3.14, source);
    }

    [Fact]
    public void ObjectAttribute_Double_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(3.14)]
            public class Foo { }
            """;

        Successful(3.14, source);
    }

    [Fact]
    public void ObjectAttribute_Float_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(3.14f)]
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

    private IArgumentPatternMatchResult<double> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<double> Fixture = PatternFixtureFactory.CreateDouble();

    [AssertionMethod]
    private void Successful(double matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<double>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<double>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<double>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
