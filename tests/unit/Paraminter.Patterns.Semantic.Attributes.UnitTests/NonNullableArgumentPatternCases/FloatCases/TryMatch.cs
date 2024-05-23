namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases.FloatCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch
{
    private readonly IPatternFixture<float> Fixture = PatternFixtureFactory.CreateFloat();

    [Fact]
    public void FloatAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [FloatAttribute(3.14f)]
            public class Foo { }
            """;

        Successful(3.14f, source);
    }

    [Fact]
    public void ObjectAttribute_Float_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(3.14f)]
            public class Foo { }
            """;

        Successful(3.14f, source);
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

    private IArgumentPatternMatchResult<float> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(float matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<float>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<float>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<float>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
