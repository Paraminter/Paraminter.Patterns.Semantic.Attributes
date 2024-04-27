﻿namespace Attribinter.Patterns.Semantic.NonNullableObjectArgumentPatternFactoryCases.NonNullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using System;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject((bool)42)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Null_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject(null)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Int_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(0)]
            public class Foo { }
            """;

        Successful(0, source);
    }

    [Fact]
    public void String_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject("")]
            public class Foo { }
            """;

        Successful(string.Empty, source);
    }

    [Fact]
    public void Array_ErrorElement_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject(new[] { (bool)42 })]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Array_Empty_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(new object[0])]
            public class Foo { }
            """;

        Successful(Array.Empty<object>(), source);
    }

    [Fact]
    public void Array_ValidElements_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(new[] { 42 })]
            public class Foo { }
            """;

        Successful(ArrayArgument, source);
    }

    private static readonly object ArrayArgument = new[] { 42 };

    private ArgumentPatternMatchResult<object> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(object expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.False(result.Successful);
    }
}
