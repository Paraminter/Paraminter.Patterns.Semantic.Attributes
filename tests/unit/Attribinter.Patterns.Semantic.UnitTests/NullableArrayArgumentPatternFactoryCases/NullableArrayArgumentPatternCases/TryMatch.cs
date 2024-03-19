namespace Attribinter.Patterns.Semantic.NullableArrayArgumentPatternFactoryCases.NullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<IReadOnlyList<TElement>?> Target<TElement>(IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableArray((object[])42)]
            public class Foo { }
            """;

        Unsuccessful<object>(source, NoSetup<object>, VerifyNoInvokations<object>);
    }

    [Fact]
    public void ArrayAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NullableArray(null)]
            public class Foo { }
            """;

        Successful<object>(null, source, NoSetup<object>, VerifyNoInvokations<object>);
    }

    [Fact]
    public void ObjectAttribute_NullArray_Successful()
    {
        var source = """
            [Attribinter.NullableObject((object[])null)]
            public class Foo { }
            """;

        Successful<object>(null, source, NoSetup<object>, VerifyNoInvokations<object>);
    }

    [Fact]
    public void ObjectAttribute_NullString_Successful()
    {
        var source = """
            [Attribinter.NullableObject((string)null)]
            public class Foo { }
            """;

        Successful<object>(null, source, NoSetup<object>, VerifyNoInvokations<object>);
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

        Successful(result, source, setup, VerifyInvoked<object>);

        void setup(PatternContext<object> context, TypedConstant argument) => context.NonNullablePatternMock.Setup(static (pattern) => pattern.TryMatch(It.IsAny<TypedConstant>())).Returns(matchResult);
    }

    [Fact]
    public void NonNullableNotMatching_Unsuccessful()
    {
        var matchResult = ArgumentPatternMatchResult.CreateUnsuccessful<IReadOnlyList<object>>();

        var source = """
            [Attribinter.NullableObject(new string[0])]
            public class Foo { }
            """;

        Unsuccessful<object>(source, setup, VerifyInvoked<object>);

        void setup(PatternContext<object> context, TypedConstant argument) => context.NonNullablePatternMock.Setup(static (pattern) => pattern.TryMatch(It.IsAny<TypedConstant>())).Returns(matchResult);
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup<TElement>(PatternContext<TElement> context, TypedConstant argument) { }

    private static void VerifyNoInvokations<TElement>(PatternContext<TElement> context, TypedConstant argument) => context.NonNullablePatternMock.VerifyNoOtherCalls();
    private static void VerifyInvoked<TElement>(PatternContext<TElement> context, TypedConstant argument)
    {
        context.NonNullablePatternMock.Verify((pattern) => pattern.TryMatch(argument), Times.Once());
        context.NonNullablePatternMock.VerifyNoOtherCalls();
    }

    [AssertionMethod]
    private static void Successful<TElement>(IReadOnlyList<TElement>? expected, string source, Action<PatternContext<TElement>, TypedConstant> setupDelegate, Action<PatternContext<TElement>, TypedConstant> verifyDelegate)
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
