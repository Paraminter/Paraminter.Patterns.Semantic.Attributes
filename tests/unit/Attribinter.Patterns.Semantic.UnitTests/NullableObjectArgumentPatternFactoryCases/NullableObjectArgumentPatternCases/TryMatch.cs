namespace Attribinter.Patterns.Semantic.NullableObjectArgumentPatternFactoryCases.NullableObjectArgumentPatternCases;

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
            [Attribinter.NullableObject((bool)42)]
            public class Foo { }
            """;

        Unsuccessful(source, NoSetup);
    }

    [Fact]
    public void NullableObjectAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NullableObject(null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NonNullableObjectAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NotNull_NonNullablePatternMatching_Successful()
    {
        var result = Mock.Of<object>();

        var source = """
            [Attribinter.NullableObject(42)]
            public class Foo { }
            """;

        Successful(result, source, setup);

        void setup(TypedConstant argument) => Fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(ArgumentPatternMatchResult.CreateSuccessful(result));
    }

    [Fact]
    public void NotNull_NonNullablePatternNotMatching_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject(42)]
            public class Foo { }
            """;

        Unsuccessful(source, setup);

        void setup(TypedConstant argument) => Fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(ArgumentPatternMatchResult.CreateUnsuccessful<object>());
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup(TypedConstant argument) { }

    private ArgumentPatternMatchResult<object?> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(object? expected, string source, Action<TypedConstant> setupDelegate)
    {
        var argument = TypedConstantFactory.Create(source);

        setupDelegate(argument);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }

    [AssertionMethod]
    private void Unsuccessful(string source, Action<TypedConstant> setupDelegate)
    {
        var argument = TypedConstantFactory.Create(source);

        setupDelegate(argument);

        var result = Target(argument);

        Assert.False(result.Successful);
    }
}
