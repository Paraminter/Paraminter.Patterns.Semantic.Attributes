namespace Attribinter.Patterns.Semantic.NullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<ITypeSymbol?> Target(IArgumentPattern<TypedConstant, ITypeSymbol?> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private readonly PatternContext Context = PatternContext.Create();

    [Fact]
    public void NullableTypeAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NullableType(null)]
            public class Foo { }
            """;

        Successful(null, source, VerifyNoInvokations);
    }

    [Fact]
    public void NonNullableTypeAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NonNullableType(null)]
            public class Foo { }
            """;

        Successful(null, source, VerifyNoInvokations);
    }

    [Fact]
    public void ObjectAttribute_NullType_Successful()
    {
        var source = """
            [Attribinter.NullableObject((System.Type)null)]
            public class Foo { }
            """;

        Successful(null, source, VerifyNoInvokations);
    }

    [Fact]
    public void ObjectAttribute_NullString_Successful()
    {
        var source = """
            [Attribinter.NullableObject((string)null)]
            public class Foo { }
            """;

        Successful(null, source, VerifyNoInvokations);
    }

    [Fact]
    public void NotNull_SuccessfulNonNullablePattern_Successful()
    {
        var result = Mock.Of<ITypeSymbol>();

        Context.NonNullablePatternMock.Setup(static (pattern) => pattern.TryMatch(It.IsAny<TypedConstant>())).Returns(ArgumentPatternMatchResult.CreateSuccessful(result));

        var source = """
            [Attribinter.NullableObject(42)]
            public class Foo { }
            """;

        Successful(result, source, VerifyInvokation);
    }

    [Fact]
    public void NotNull_UnsuccessfulNonNullablePattern_Unsuccessful()
    {
        Context.NonNullablePatternMock.Setup(static (pattern) => pattern.TryMatch(It.IsAny<TypedConstant>())).Returns(ArgumentPatternMatchResult.CreateUnsuccessful<ITypeSymbol>());

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
    private void Successful(ITypeSymbol? expected, string source, Action<TypedConstant> verifyDelegate)
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
