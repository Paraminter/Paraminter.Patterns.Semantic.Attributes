namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_ULongEnum
{
    private static ArgumentPatternMatchResult<ULongEnum> Target(IArgumentPattern<TypedConstant, ULongEnum> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext<ULongEnum> Context = PatternContext<ULongEnum>.Create();

    [Fact]
    public void ULongEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.ULongEnumAttribute(Attribinter.ULongEnum.None)]
            public class Foo { }
            """;

        Successful(ULongEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_ULongEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.ULongEnum.None)]
            public class Foo { }
            """;

        Successful(ULongEnum.None, source);
    }

    [AssertionMethod]
    private static void Successful(ULongEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
