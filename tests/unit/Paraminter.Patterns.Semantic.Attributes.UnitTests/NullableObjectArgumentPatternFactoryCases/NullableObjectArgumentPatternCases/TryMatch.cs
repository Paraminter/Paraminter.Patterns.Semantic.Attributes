namespace Paraminter.Patterns.Semantic.Attributes.NullableObjectArgumentPatternFactoryCases.NullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute((bool)42)]
            public class Foo { }
            """;

        Unsuccessful(source, NoSetup);
    }

    [Fact]
    public void NullableObjectAttribute_Null_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NonNullableObjectAttribute_Null_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NotNull_NonNullablePatternMatching_Successful()
    {
        var matchedArgument = Mock.Of<object>();

        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(42)]
            public class Foo { }
            """;

        Successful(matchedArgument, source, setup);

        void setup(TypedConstant argument)
        {
            Mock<IArgumentPatternMatchResult<object>> nonNullableMatchResultMock = new();

            nonNullableMatchResultMock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(true);
            nonNullableMatchResultMock.Setup(static (matchResult) => matchResult.GetMatchedArgument()).Returns(matchedArgument);

            Fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(nonNullableMatchResultMock.Object);
        }
    }

    [Fact]
    public void NotNull_NonNullablePatternNotMatching_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(42)]
            public class Foo { }
            """;

        Unsuccessful(source, setup);

        void setup(TypedConstant argument)
        {
            Mock<IArgumentPatternMatchResult<object>> nonNullableMatchResultMock = new();

            nonNullableMatchResultMock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(false);

            Fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(nonNullableMatchResultMock.Object);
        }
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup(TypedConstant argument) { }

    private IArgumentPatternMatchResult<object?> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(object? matchedArgument, string source, Action<TypedConstant> setupDelegate)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<object?>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(argument);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source, Action<TypedConstant> setupDelegate)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<object?>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<object?>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(argument);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
