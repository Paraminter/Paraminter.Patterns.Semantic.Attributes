namespace Attribinter.Patterns.Semantic.NullableArrayArgumentPatternFactoryCases.NullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

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
            [Attribinter.NullableArray((object[])42)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup<object>);
    }

    [Fact]
    public void ArrayAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NullableArray(null)]
            public class Foo { }
            """;

        Successful<object>(null, source, NoSetup<object>);
    }

    [Fact]
    public void ObjectAttribute_NullArray_Successful()
    {
        var source = """
            [Attribinter.NullableObject((object[])null)]
            public class Foo { }
            """;

        Successful<object>(null, source, NoSetup<object>);
    }

    [Fact]
    public void ObjectAttribute_NullString_Successful()
    {
        var source = """
            [Attribinter.NullableObject((string)null)]
            public class Foo { }
            """;

        Successful<object>(null, source, NoSetup<object>);
    }

    [Fact]
    public void NonNullableMatching_Successful()
    {
        List<object> result = [];

        var matchResult = ArgumentPatternMatchResult.CreateSuccessful<IReadOnlyList<object>>(result);

        var source = """
            [Attribinter.NullableObject(new string[0])]
            public class Foo { }
            """;

        Successful(result, source, setup);

        void setup(IPatternFixture<object> fixture, TypedConstant argument) => fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(matchResult);
    }

    [Fact]
    public void NonNullableNotMatching_Unsuccessful()
    {
        var matchResult = ArgumentPatternMatchResult.CreateUnsuccessful<IReadOnlyList<object>>();

        var source = """
            [Attribinter.NullableObject(new string[0])]
            public class Foo { }
            """;

        Unsuccessful<object>(source, setup);

        void setup(IPatternFixture<object> fixture, TypedConstant argument) => fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(matchResult);
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup<TElement>(IPatternFixture<TElement> fixture, TypedConstant argument) { }

    private static ArgumentPatternMatchResult<IReadOnlyList<TElement>?> Target<TElement>(IPatternFixture<TElement> fixture, TypedConstant argument) => fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private static void Successful<TElement>(IReadOnlyList<TElement>? expected, string source, Action<IPatternFixture<TElement>, TypedConstant> setupDelegate)
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
