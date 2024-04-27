namespace Attribinter.Patterns.Semantic.NonNullableArrayArgumentPatternFactoryCases.NonNullableArrayArgumentPatternCases;

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
            [Attribinter.NonNullableArray((object[])42)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup<object>);
    }

    [Fact]
    public void ArrayAttribute_Null_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableArray(null)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup<object>);
    }

    [Fact]
    public void ArrayAttribute_Empty_Successful()
    {
        var source = """
            [Attribinter.NonNullableArray(new object[0])]
            public class Foo { }
            """;

        Successful(Array.Empty<object>(), source, NoSetup<object>);
    }

    [Fact]
    public void ArrayAttribute_MatchingElements_Successful()
    {
        var element1 = Mock.Of<object>();
        var element2 = Mock.Of<object>();

        var matchResult1 = ArgumentPatternMatchResult.CreateSuccessful(element1);
        var matchResult2 = ArgumentPatternMatchResult.CreateSuccessful(element2);

        var source = """
            [Attribinter.NonNullableArray(new object[] { 42, 43 })]
            public class Foo { }
            """;

        Successful(new[] { element1, element2 }, source, Setup(new[] { matchResult1, matchResult2 }));
    }

    [Fact]
    public void ArrayAttribute_NonMatchingElement_Unsuccessful()
    {
        var matchResult1 = ArgumentPatternMatchResult.CreateSuccessful(Mock.Of<object>());
        var matchResult2 = ArgumentPatternMatchResult.CreateUnsuccessful<object>();

        var source = """
            [Attribinter.NonNullableArray(new object[] { 42, 43 })]
            public class Foo { }
            """;

        Unsuccessful(source, Setup(new[] { matchResult1, matchResult2 }));
    }

    [Fact]
    public void ObjectAttribute_Null_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject(null)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup<object>);
    }

    [Fact]
    public void ObjectAttribute_MatchingElements_Successful()
    {
        var element1 = Mock.Of<object>();
        var element2 = Mock.Of<object>();

        var matchResult1 = ArgumentPatternMatchResult.CreateSuccessful(element1);
        var matchResult2 = ArgumentPatternMatchResult.CreateSuccessful(element2);

        var source = """
            [Attribinter.NullableObject(new object[] { 42, 43 })]
            public class Foo { }
            """;

        Successful(new[] { element1, element2 }, source, Setup(new[] { matchResult1, matchResult2 }));
    }

    [Fact]
    public void ObjectAttribute_NonMatchingElement_Unsuccessful()
    {
        var matchResult1 = ArgumentPatternMatchResult.CreateSuccessful(Mock.Of<object>());
        var matchResult2 = ArgumentPatternMatchResult.CreateUnsuccessful<object>();

        var source = """
            [Attribinter.NullableObject(new object[] { 42, 43 })]
            public class Foo { }
            """;

        Unsuccessful(source, Setup(new[] { matchResult1, matchResult2 }));
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup<TElement>(IPatternFixture<TElement> fixture, TypedConstant argument) { }
    private static Action<IPatternFixture<TElement>, TypedConstant> Setup<TElement>(IEnumerable<ArgumentPatternMatchResult<TElement>> matchResults) => (fixture, argument) =>
    {
        var i = 0;

        foreach (var matchResult in matchResults)
        {
            fixture.ElementPatternMock.Setup((pattern) => pattern.TryMatch(argument.Values[i])).Returns(matchResult);

            i += 1;
        }
    };

    private static ArgumentPatternMatchResult<IReadOnlyList<TElement>> Target<TElement>(IPatternFixture<TElement> fixture, TypedConstant argument) => fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private static void Successful<TElement>(IReadOnlyList<TElement> expected, string source, Action<IPatternFixture<TElement>, TypedConstant> setupDelegate)
    {
        var fixture = PatternFixtureFactory.Create<TElement>();

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(fixture, argument);

        var result = Target(fixture, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }

    [AssertionMethod]
    private static void Unsuccessful<TElement>(string source, Action<IPatternFixture<TElement>, TypedConstant> setupDelegate)
    {
        var fixture = PatternFixtureFactory.Create<TElement>();

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(fixture, argument);

        var result = Target(fixture, argument);

        Assert.False(result.Successful);
    }
}
