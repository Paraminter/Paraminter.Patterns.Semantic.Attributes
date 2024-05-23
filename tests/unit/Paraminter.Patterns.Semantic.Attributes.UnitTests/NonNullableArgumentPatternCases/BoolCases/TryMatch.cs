namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases.BoolCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch
{
    private readonly IPatternFixture<bool> Fixture = PatternFixtureFactory.CreateBool();

    [Fact]
    public void BoolAttribute_True_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [BoolAttribute(true)]
            public class Foo { }
            """;

        Successful(true, source);
    }

    [Fact]
    public void BoolAttribute_False_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [BoolAttribute(false)]
            public class Foo { }
            """;

        Successful(false, source);
    }

    [Fact]
    public void ObjectAttribute_True_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(true)]
            public class Foo { }
            """;

        Successful(true, source);
    }

    [Fact]
    public void ObjectAttribute_False_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(false)]
            public class Foo { }
            """;

        Successful(false, source);
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

    private IArgumentPatternMatchResult<bool> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(bool matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<bool>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<bool>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<bool>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
