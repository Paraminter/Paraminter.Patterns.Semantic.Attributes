namespace Attribinter.Patterns.Semantic.NullableArgumentPatternCases.StringCases;

using Microsoft.CodeAnalysis;

using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void NullableStringAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NullableString(null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NonNullableStringAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NonNullableString(null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void ObjectAttribute_NullString_Successful()
    {
        var source = """
            [Attribinter.NullableObject((string)null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void ObjectAttribute_NullType_Successful()
    {
        var source = """
            [Attribinter.NullableObject((System.Type)null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NotNull_SuccessfulNonNullablePattern_Successful()
    {
        var result = "42";

        var source = """
            [Attribinter.NullableObject(42)]
            public class Foo { }
            """;

        Successful(result, source, setup);

        void setup(TypedConstant argument) => Fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(ArgumentPatternMatchResult.CreateSuccessful(result));
    }

    [Fact]
    public void NotNull_UnsuccessfulNonNullablePattern_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject(42)]
            public class Foo { }
            """;

        Unsuccessful(source, setup);

        void setup(TypedConstant argument) => Fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(ArgumentPatternMatchResult.CreateUnsuccessful<string>());
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup(TypedConstant argument) { }

    private ArgumentPatternMatchResult<string?> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(string? expected, string source, Action<TypedConstant> setupDelegate)
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
