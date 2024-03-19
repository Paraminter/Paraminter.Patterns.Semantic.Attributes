namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_ShortEnum
{
    private static ArgumentPatternMatchResult<ShortEnum> Target(IArgumentPattern<TypedConstant, ShortEnum> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext<ShortEnum> Context = PatternContext<ShortEnum>.Create();

    [Fact]
    public void ShortEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.ShortEnumAttribute(Attribinter.ShortEnum.None)]
            public class Foo { }
            """;

        Successful(ShortEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_ShortEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.ShortEnum.None)]
            public class Foo { }
            """;

        Successful(ShortEnum.None, source);
    }

    [AssertionMethod]
    private static void Successful(ShortEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
