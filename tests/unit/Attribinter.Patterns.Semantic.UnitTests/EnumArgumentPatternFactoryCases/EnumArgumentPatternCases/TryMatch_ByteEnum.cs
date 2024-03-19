namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_ByteEnum
{
    private static ArgumentPatternMatchResult<ByteEnum> Target(IArgumentPattern<TypedConstant, ByteEnum> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext<ByteEnum> Context = PatternContext<ByteEnum>.Create();

    [Fact]
    public void ByteEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.ByteEnumAttribute(Attribinter.ByteEnum.None)]
            public class Foo { }
            """;

        Successful(ByteEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_ByteEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.ByteEnum.None)]
            public class Foo { }
            """;

        Successful(ByteEnum.None, source);
    }

    [AssertionMethod]
    private static void Successful(ByteEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
