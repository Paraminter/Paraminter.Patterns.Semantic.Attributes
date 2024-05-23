namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch_SByteEnum
{
    private readonly IPatternFixture<SByteEnum> Fixture = PatternFixtureFactory.Create<SByteEnum>();

    [Fact]
    public void SByteEnumAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [SByteEnumAttribute(SByteEnum.None)]
            public class Foo { }
            """;

        Successful(SByteEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_SByteEnum_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(SByteEnum.None)]
            public class Foo { }
            """;

        Successful(SByteEnum.None, source);
    }

    private IArgumentPatternMatchResult<SByteEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(SByteEnum matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<SByteEnum>>();

        var argument = TypedConstantFactory.Create(source);

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
