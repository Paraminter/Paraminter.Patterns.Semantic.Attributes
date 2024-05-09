namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch_UIntEnum
{
    [Fact]
    public void UIntEnumAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [UIntEnumAttribute(UIntEnum.None)]
            public class Foo { }
            """;

        Successful(UIntEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_UIntEnum_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(UIntEnum.None)]
            public class Foo { }
            """;

        Successful(UIntEnum.None, source);
    }

    private IArgumentPatternMatchResult<UIntEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<UIntEnum> Fixture = PatternFixtureFactory.Create<UIntEnum>();

    [AssertionMethod]
    private void Successful(UIntEnum matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<UIntEnum>>();

        var argument = TypedConstantFactory.Create(source);

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
