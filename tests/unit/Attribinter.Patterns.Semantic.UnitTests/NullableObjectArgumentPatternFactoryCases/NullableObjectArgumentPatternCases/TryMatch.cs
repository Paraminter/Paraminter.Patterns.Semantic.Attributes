namespace Attribinter.Patterns.Semantic.NullableObjectArgumentPatternFactoryCases.NullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<object?> Target(IArgumentPattern<TypedConstant, object?> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private readonly PatternContext Context = PatternContext.Create();
    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject((bool)42)]
            public class Foo { }
            """;

        Unsuccessful(source, VerifyNoInvokations);
    }

    [Fact]
    public void NullableObjectAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NullableObject(null)]
            public class Foo { }
            """;

        Successful(null, source, VerifyNoInvokations);
    }

    [Fact]
    public void NonNullableObjectAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(null)]
            public class Foo { }
            """;

        Successful(null, source, VerifyNoInvokations);
    }

    [Fact]
    public void NotNull_NonNullablePatternMatching_Successful()
    {
        var result = Mock.Of<object>();

        Context.NonNullablePatternMock.Setup(static (pattern) => pattern.TryMatch(It.IsAny<TypedConstant>())).Returns(ArgumentPatternMatchResult.CreateSuccessful(result));

        var source = """
            [Attribinter.NullableObject(42)]
            public class Foo { }
            """;

        Successful(result, source, VerifyInvokation);
    }

    [Fact]
    public void NotNull_NonNullablePatternNotMatching_Unsuccessful()
    {
        Context.NonNullablePatternMock.Setup(static (pattern) => pattern.TryMatch(It.IsAny<TypedConstant>())).Returns(ArgumentPatternMatchResult.CreateUnsuccessful<object>());

        var source = """
            [Attribinter.NullableObject(42)]
            public class Foo { }
            """;

        Unsuccessful(source, VerifyInvokation);
    }

    private void VerifyInvokation(TypedConstant argument)
    {
        Context.NonNullablePatternMock.Verify((pattern) => pattern.TryMatch(argument), Times.Once());
        Context.NonNullablePatternMock.VerifyNoOtherCalls();
    }

    private void VerifyNoInvokations(TypedConstant argument) => Context.NonNullablePatternMock.VerifyNoOtherCalls();

    [AssertionMethod]
    private void Successful(object? expected, string source, Action<TypedConstant> verifyDelegate)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());

        verifyDelegate(argument);
    }

    [AssertionMethod]
    private void Unsuccessful(string source, Action<TypedConstant> verifyDelegate)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.False(result.Successful);

        verifyDelegate(argument);
    }
}
