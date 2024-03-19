namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using System;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<TEnum> Target<TEnum>(IArgumentPattern<TypedConstant, TEnum> pattern, TypedConstant argument) => pattern.TryMatch(argument);

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

    [AssertionMethod]
    private static void Unsuccessful<TEnum>(string source) where TEnum : Enum
    {
        var context = PatternContext<TEnum>.Create();

        var argument = TypedConstantFactory.Create(source);

        var result = Target(context.Pattern, argument);

        Assert.False(result.Successful);
    }
}
