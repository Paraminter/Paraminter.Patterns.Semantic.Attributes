namespace Attribinter.Patterns.Semantic.NullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void NullableTypeAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NullableType(null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NonNullableTypeAttribute_Null_Successful()
    {
        var source = """
            [Attribinter.NonNullableType(null)]
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
    public void ObjectAttribute_NullString_Successful()
    {
        var source = """
            [Attribinter.NullableObject((string)null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NotNull_SuccessfulNonNullablePattern_Successful()
    {
        var result = Mock.Of<ITypeSymbol>();

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

        void setup(TypedConstant argument) => Fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(ArgumentPatternMatchResult.CreateUnsuccessful<ITypeSymbol>());
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup(TypedConstant argument) { }

    private ArgumentPatternMatchResult<ITypeSymbol?> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(ITypeSymbol? expected, string source, Action<TypedConstant> setupDelegate)
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
