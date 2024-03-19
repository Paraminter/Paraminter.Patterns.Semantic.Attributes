namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_UIntEnum
{
    private static ArgumentPatternMatchResult<UIntEnum> Target(IArgumentPattern<TypedConstant, UIntEnum> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext<UIntEnum> Context = PatternContext<UIntEnum>.Create();

    [Fact]
    public void UIntEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.UIntEnumAttribute(Attribinter.UIntEnum.None)]
            public class Foo { }
            """;

        Successful(UIntEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_UIntEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.UIntEnum.None)]
            public class Foo { }
            """;

        Successful(UIntEnum.None, source);
    }

    [AssertionMethod]
    private static void Successful(UIntEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
