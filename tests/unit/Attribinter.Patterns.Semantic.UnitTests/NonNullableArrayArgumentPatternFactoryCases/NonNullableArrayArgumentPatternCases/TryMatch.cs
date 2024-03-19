namespace Attribinter.Patterns.Semantic.NonNullableArrayArgumentPatternFactoryCases.NonNullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<IReadOnlyList<TElement>> Target<TElement>(IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableArray((object[])42)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup<object>, VerifyNoInvokations<object>);
    }

    [Fact]
    public void ArrayAttribute_Null_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableArray(null)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup<object>, VerifyNoInvokations<object>);
    }

    [Fact]
    public void ArrayAttribute_Empty_Successful()
    {
        var source = """
            [Attribinter.NonNullableArray(new object[0])]
            public class Foo { }
            """;

        Successful(Array.Empty<object>(), source, NoSetup<object>, VerifyNoInvokations<object>);
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

        Successful(new[] { element1, element2 }, source, Setup(new[] { matchResult1, matchResult2 }), VerifyInvoked<object>(2));
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

        Unsuccessful(source, Setup(new[] { matchResult1, matchResult2 }), VerifyInvoked<object>(2));
    }

    [Fact]
    public void ObjectAttribute_Null_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject(null)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup<object>, VerifyNoInvokations<object>);
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

        Successful(new[] { element1, element2 }, source, Setup(new[] { matchResult1, matchResult2 }), VerifyInvoked<object>(2));
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

        Unsuccessful(source, Setup(new[] { matchResult1, matchResult2 }), VerifyInvoked<object>(2));
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup<TElement>(PatternContext<TElement> context, TypedConstant argument) { }
    private static Action<PatternContext<TElement>, TypedConstant> Setup<TElement>(IEnumerable<ArgumentPatternMatchResult<TElement>> matchResults) => (context, argument) =>
    {
        var i = 0;

        foreach (var matchResult in matchResults)
        {
            context.ElementPatternMock.Setup((pattern) => pattern.TryMatch(argument.Values[i])).Returns(matchResult);

            i += 1;
        }
    };

    private static void VerifyNoInvokations<TElement>(PatternContext<TElement> context, TypedConstant argument) => context.ElementPatternMock.VerifyNoOtherCalls();
    private static Action<PatternContext<TElement>, TypedConstant> VerifyInvoked<TElement>(int argumentCount) => (context, argument) =>
    {
        for (var i = 0; i < argumentCount; i++)
        {
            context.ElementPatternMock.Verify((pattern) => pattern.TryMatch(argument.Values[i]), Times.Once());
        }

        context.ElementPatternMock.VerifyNoOtherCalls();
    };

    [AssertionMethod]
    private static void Successful<TElement>(IReadOnlyList<TElement> expected, string source, Action<PatternContext<TElement>, TypedConstant> setupDelegate, Action<PatternContext<TElement>, TypedConstant> verifyDelegate)
    {
        var context = PatternContext<TElement>.Create();

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(context, argument);

        var result = Target(context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());

        verifyDelegate(context, argument);
    }

    [AssertionMethod]
    private static void Unsuccessful<TElement>(string source, Action<PatternContext<TElement>, TypedConstant> setupDelegate, Action<PatternContext<TElement>, TypedConstant> verifyDelegate)
    {
        var context = PatternContext<TElement>.Create();

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(context, argument);

        var result = Target(context.Pattern, argument);

        Assert.False(result.Successful);

        verifyDelegate(context, argument);
    }
}
