namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_LongEnum
{
    private static ArgumentPatternMatchResult<LongEnum> Target(IArgumentPattern<TypedConstant, LongEnum> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext<LongEnum> Context = PatternContext<LongEnum>.Create();

    [Fact]
    public void LongEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.LongEnumAttribute(Attribinter.LongEnum.None)]
            public class Foo { }
            """;

        Successful(LongEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_LongEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.LongEnum.None)]
            public class Foo { }
            """;

        Successful(LongEnum.None, source);
    }

    [AssertionMethod]
    private static void Successful(LongEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
