﻿namespace Paraminter.Patterns.Semantic.Attributes.NullableArgumentPatternCases.StringCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void NullableStringAttribute_Null_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableStringAttribute(null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NonNullableStringAttribute_Null_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableStringAttribute(null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void ObjectAttribute_NullString_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute((string)null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void ObjectAttribute_NullType_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute((System.Type)null)]
            public class Foo { }
            """;

        Successful(null, source, NoSetup);
    }

    [Fact]
    public void NotNull_SuccessfulNonNullablePattern_Successful()
    {
        var matchedArgument = "42";

        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(42)]
            public class Foo { }
            """;

        Successful(matchedArgument, source, setup);

        void setup(TypedConstant argument)
        {
            Mock<IArgumentPatternMatchResult<string>> nonNullableMatchResultMock = new();

            nonNullableMatchResultMock.Setup(static (pattern) => pattern.WasSuccessful).Returns(true);
            nonNullableMatchResultMock.Setup(static (pattern) => pattern.GetMatchedArgument()).Returns(matchedArgument);

            Fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(nonNullableMatchResultMock.Object);
        }
    }

    [Fact]
    public void NotNull_UnsuccessfulNonNullablePattern_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObjectAttribute(42)]
            public class Foo { }
            """;

        Unsuccessful(source, setup);

        void setup(TypedConstant argument)
        {
            Mock<IArgumentPatternMatchResult<string>> nonNullableMatchResultMock = new();

            nonNullableMatchResultMock.Setup(static (pattern) => pattern.WasSuccessful).Returns(false);

            Fixture.NonNullablePatternMock.Setup((pattern) => pattern.TryMatch(argument)).Returns(nonNullableMatchResultMock.Object);
        }
    }

    [SuppressMessage("Critical Code Smell", "S1186: Methods should not be empty", Justification = "Implements pseudo-interface.")]
    private static void NoSetup(TypedConstant argument) { }

    private IArgumentPatternMatchResult<string?> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<string> Fixture = PatternFixtureFactory.CreateString();

    [AssertionMethod]
    private void Successful(string? matchedArgument, string source, Action<TypedConstant> setupDelegate)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<string>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(argument);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source, Action<TypedConstant> setupDelegate)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<string>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<string>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        setupDelegate(argument);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
