namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArrayArgumentPatternFactoryCases.NonNullableArrayArgumentPatternCases;

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

            [NonNullableArrayAttribute((object[])42)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup);
    }

    [Fact]
    public void ArrayAttribute_Null_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableArrayAttribute(null)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup);
    }

    [Fact]
    public void ArrayAttribute_Empty_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableArrayAttribute(new object[0])]
            public class Foo { }
            """;

        Successful(Array.Empty<object>(), source, NoSetup);
    }

    [Fact]
    public void ArrayAttribute_MatchingElements_Successful()
    {
        var element1 = Mock.Of<object>();
        var element2 = Mock.Of<object>();

        Mock<IArgumentPatternMatchResult<object>> matchResult1Mock = new();
        Mock<IArgumentPatternMatchResult<object>> matchResult2Mock = new();

        matchResult1Mock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(true);
        matchResult1Mock.Setup(static (matchResult) => matchResult.GetMatchedArgument()).Returns(element1);

        matchResult2Mock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(true);
        matchResult2Mock.Setup(static (matchResult) => matchResult.GetMatchedArgument()).Returns(element2);

        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableArrayAttribute(new object[] { 42, 43 })]
            public class Foo { }
            """;

        Successful(new[] { element1, element2 }, source, Setup(new[] { matchResult1Mock.Object, matchResult2Mock.Object }));
    }

    [Fact]
    public void ArrayAttribute_NonMatchingElement_Unsuccessful()
    {
        var element1 = Mock.Of<object>();

        Mock<IArgumentPatternMatchResult<object>> matchResult1Mock = new();
        Mock<IArgumentPatternMatchResult<object>> matchResult2Mock = new();

        matchResult1Mock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(true);
        matchResult1Mock.Setup(static (matchResult) => matchResult.GetMatchedArgument()).Returns(element1);

        matchResult2Mock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(false);

        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableArrayAttribute(new object[] { 42, 43 })]
            public class Foo { }
            """;

        Unsuccessful(source, Setup(new[] { matchResult1Mock.Object, matchResult2Mock.Object }));
    }

    [Fact]
    public void ObjectAttribute_Null_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(null)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup);
    }

    [Fact]
    public void ObjectAttribute_MatchingElements_Successful()
    {
        var element1 = Mock.Of<object>();
        var element2 = Mock.Of<object>();

        Mock<IArgumentPatternMatchResult<object>> matchResult1Mock = new();
        Mock<IArgumentPatternMatchResult<object>> matchResult2Mock = new();

        matchResult1Mock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(true);
        matchResult1Mock.Setup(static (matchResult) => matchResult.GetMatchedArgument()).Returns(element1);

        matchResult2Mock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(true);
        matchResult2Mock.Setup(static (matchResult) => matchResult.GetMatchedArgument()).Returns(element2);

        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(new object[] { 42, 43 })]
            public class Foo { }
            """;

        Successful(new[] { element1, element2 }, source, Setup(new[] { matchResult1Mock.Object, matchResult2Mock.Object }));
    }

    [Fact]
    public void ObjectAttribute_NonMatchingElement_Unsuccessful()
    {
        var element1 = Mock.Of<object>();

        Mock<IArgumentPatternMatchResult<object>> matchResult1Mock = new();
        Mock<IArgumentPatternMatchResult<object>> matchResult2Mock = new();

        matchResult1Mock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(true);
        matchResult1Mock.Setup(static (matchResult) => matchResult.GetMatchedArgument()).Returns(element1);

        matchResult2Mock.Setup(static (matchResult) => matchResult.WasSuccessful).Returns(false);

        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(new object[] { 42, 43 })]
            public class Foo { }
            """;

        Unsuccessful(source, Setup(new[] { matchResult1Mock.Object, matchResult2Mock.Object }));
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup<TElement>(
        IPatternFixture<TElement> fixture,
        TypedConstant argument)
    { }

    private static Action<IPatternFixture<TElement>, TypedConstant> Setup<TElement>(
        IEnumerable<IArgumentPatternMatchResult<TElement>> matchResults)
    {
        return (fixture, argument) =>
        {
            var i = 0;

            foreach (var matchResult in matchResults)
            {
                fixture.ElementPatternMock.Setup((pattern) => pattern.TryMatch(argument.Values[i])).Returns(matchResult);

                i += 1;
            }
        };
    }

    private static IArgumentPatternMatchResult<IReadOnlyList<TElement>> Target<TElement>(
        IPatternFixture<TElement> fixture,
        TypedConstant argument)
    {
        return fixture.Sut.TryMatch(argument);
    }

    [AssertionMethod]
    private static void Successful<TElement>(
        IReadOnlyList<TElement> matchedArgument,
        string source,
        Action<IPatternFixture<TElement>, TypedConstant> setupDelegate)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<IReadOnlyList<TElement>>>();

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
        var matchResult = Mock.Of<IArgumentPatternMatchResult<IReadOnlyList<TElement>>>();

        var fixture = PatternFixtureFactory.Create<TElement>();

        fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<IReadOnlyList<TElement>>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(fixture, argument);

        var result = Target(fixture, argument);

        Assert.Same(matchResult, result);
    }
}
