namespace Paraminter.Patterns.Semantic.Attributes.NonNullableObjectArgumentPatternFactoryCases.NonNullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class TryMatch
{
    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute((bool)42)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Null_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(null)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Int_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(0)]
            public class Foo { }
            """;

        Successful(0, source);
    }

    [Fact]
    public void String_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute("")]
            public class Foo { }
            """;

        Successful(string.Empty, source);
    }

    [Fact]
    public void Array_ErrorElement_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(new[] { (bool)42 })]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Array_Empty_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(new object[0])]
            public class Foo { }
            """;

        Successful(Array.Empty<object>(), source);
    }

    [Fact]
    public void Array_ValidElements_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(new[] { 42 })]
            public class Foo { }
            """;

        Successful(ArrayArgument, source);
    }

    private static readonly object ArrayArgument = new[] { 42 };

    private IArgumentPatternMatchResult<object> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(object matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<object>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<object>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<object>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
