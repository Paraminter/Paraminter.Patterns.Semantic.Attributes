namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch_ByteEnum
{
    private readonly IPatternFixture<ByteEnum> Fixture = PatternFixtureFactory.Create<ByteEnum>();

    [Fact]
    public void ByteEnumAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [ByteEnumAttribute(ByteEnum.None)]
            public class Foo { }
            """;

        Successful(ByteEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_ByteEnum_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(ByteEnum.None)]
            public class Foo { }
            """;

        Successful(ByteEnum.None, source);
    }

    private IArgumentPatternMatchResult<ByteEnum> Target(
        TypedConstant argument)
    {
        return Fixture.Sut.TryMatch(argument);
    }

    [AssertionMethod]
    private void Successful(
        ByteEnum matchedArgument,
        string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<ByteEnum>>();

        var argument = TypedConstantFactory.Create(source);

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
