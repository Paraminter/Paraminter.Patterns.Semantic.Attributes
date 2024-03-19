namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_SByteEnum
{
    private static ArgumentPatternMatchResult<SByteEnum> Target(IArgumentPattern<TypedConstant, SByteEnum> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext<SByteEnum> Context = PatternContext<SByteEnum>.Create();

    [Fact]
    public void SByteEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.SByteEnumAttribute(Attribinter.SByteEnum.None)]
            public class Foo { }
            """;

        Successful(SByteEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_SByteEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.SByteEnum.None)]
            public class Foo { }
            """;

        Successful(SByteEnum.None, source);
    }

    [AssertionMethod]
    private static void Successful(SByteEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
