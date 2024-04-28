namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using System;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject((Attribinter.IntEnum)false)]
            public class Foo { }
            """;

        Unsuccessful<IntEnum>(source);
    }

    [Fact]
    public void Array_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject(new string[0])]
            public class Foo { }
            """;

        Unsuccessful<IntEnum>(source);
    }

    [Fact]
    public void Int_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject(0)]
            public class Foo { }
            """;

        Unsuccessful<IntEnum>(source);
    }

    [Fact]
    public void DifferentEnum_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.UIntEnum.None)]
            public class Foo { }
            """;

        Unsuccessful<IntEnum>(source);
    }

    private static ArgumentPatternMatchResult<TEnum> Target<TEnum>(IPatternFixture<TEnum> fixture, TypedConstant argument) => fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private static void Unsuccessful<TEnum>(string source)
        where TEnum : Enum
    {
        var fixture = PatternFixtureFactory.Create<TEnum>();

        var argument = TypedConstantFactory.Create(source);

        var result = Target(fixture, argument);

        Assert.False(result.Successful);
    }
}
