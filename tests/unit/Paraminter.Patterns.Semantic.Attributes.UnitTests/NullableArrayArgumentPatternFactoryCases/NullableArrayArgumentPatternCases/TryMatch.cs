namespace Paraminter.Patterns.Semantic.Attributes.NullableArrayArgumentPatternFactoryCases.NullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableArrayAttribute((object[])42)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup);
    }

    [Fact]
    public void ArrayAttribute_Null_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableArrayAttribute(null)]
            public class Foo { }
            """;

        Successful<object>(null, source, NoSetup);
    }

    [Fact]
    public void ObjectAttribute_NullArray_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute((object[])null)]
            public class Foo { }
            """;

        Successful<object>(null, source, NoSetup);
    }

    [Fact]
    public void ObjectAttribute_NullString_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute((string)null)]
            public class Foo { }
            """;

        Successful<object>(null, source, NoSetup);
    }

    [Fact]
    public void NonNullableMatching_Successful()
    {
        List<object> result = [];

        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(new string[0])]
            public class Foo { }
            """;

        Successful(result, source, setup);

        void setup(
            IPatternFixture<object> fixture,
            TypedConstant argument)
        {
            Mock<IArgumentPatternMatchResult<IReadOnlyList<object>>> nonNullableMatchResultMock = new();

            nonNullableMatchResultMock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(true);
            nonNullableMatchResultMock.Setup(static (matchResult) => matchResult.GetMatchedArgument()).Returns(result);

            fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(nonNullableMatchResultMock.Object);
        }
    }

    [Fact]
    public void NonNullableNotMatching_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(new string[0])]
            public class Foo { }
            """;

        Unsuccessful<object>(source, setup);

        void setup(
            IPatternFixture<object> fixture,
            TypedConstant argument)
        {
            Mock<IArgumentPatternMatchResult<IReadOnlyList<object>>> nonNullableMatchResultMock = new();

            nonNullableMatchResultMock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(false);

            fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(nonNullableMatchResultMock.Object);
        }
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup<TElement>(
        IPatternFixture<TElement> fixture,
        TypedConstant argument)
    { }

    private static IArgumentPatternMatchResult<IReadOnlyList<TElement>?> Target<TElement>(
        IPatternFixture<TElement> fixture,
        TypedConstant argument)
    {
        return fixture.Sut.TryMatch(argument);
    }

    [AssertionMethod]
    private static void Successful<TElement>(
        IReadOnlyList<TElement>? matchedArgument,
        string source,
        Action<IPatternFixture<TElement>, TypedConstant> setupDelegate)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<IReadOnlyList<TElement>?>>();

        var fixture = PatternFixtureFactory.Create<TElement>();

        fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(fixture, argument);

        var result = Target(fixture, argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private static void Unsuccessful<TElement>(
        string source,
        Action<IPatternFixture<TElement>, TypedConstant> setupDelegate)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<IReadOnlyList<TElement>?>>();

        var fixture = PatternFixtureFactory.Create<TElement>();

        fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<IReadOnlyList<TElement>?>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(fixture, argument);

        var result = Target(fixture, argument);

        Assert.Same(matchResult, result);
    }
}
