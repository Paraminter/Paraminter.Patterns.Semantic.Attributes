namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ByteCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<byte> Target(IArgumentPattern<TypedConstant, byte> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext Context = PatternContext.Create();

    [Fact]
    public void ByteAttribute_Byte_Successful()
    {
        var source = """
            [Attribinter.Byte(1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Byte_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject((byte)1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Int_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject(42)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void ObjectAttribute_String_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject("")]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [AssertionMethod]
    private static void Successful(byte expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }

    [AssertionMethod]
    private static void Unsuccessful(string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.False(result.Successful);
    }
}
