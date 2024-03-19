namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_UShortEnum
{
    private static ArgumentPatternMatchResult<UShortEnum> Target(IArgumentPattern<TypedConstant, UShortEnum> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext<UShortEnum> Context = PatternContext<UShortEnum>.Create();

    [Fact]
    public void UShortEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.UShortEnumAttribute(Attribinter.UShortEnum.None)]
            public class Foo { }
            """;

        Successful(UShortEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_UShortEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.UShortEnum.None)]
            public class Foo { }
            """;

        Successful(UShortEnum.None, source);
    }

    [AssertionMethod]
    private static void Successful(UShortEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
