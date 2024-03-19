namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_IntEnum
{
    private static ArgumentPatternMatchResult<IntEnum> Target(IArgumentPattern<TypedConstant, IntEnum> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext<IntEnum> Context = PatternContext<IntEnum>.Create();

    [Fact]
    public void IntEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.IntEnumAttribute(Attribinter.IntEnum.None)]
            public class Foo { }
            """;

        Successful(IntEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_IntEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.IntEnum.None)]
            public class Foo { }
            """;

        Successful(IntEnum.None, source);
    }

    [AssertionMethod]
    private static void Successful(IntEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
