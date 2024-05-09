namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject((IntEnum)false)]
            public class Foo { }
            """;

        Unsuccessful<IntEnum>(source);
    }

    [Fact]
    public void Array_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(new string[0])]
            public class Foo { }
            """;

        Unsuccessful<IntEnum>(source);
    }

    [Fact]
    public void Int_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(0)]
            public class Foo { }
            """;

        Unsuccessful<IntEnum>(source);
    }

    [Fact]
    public void DifferentEnum_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(UIntEnum.None)]
            public class Foo { }
            """;

        Unsuccessful<IntEnum>(source);
    }

    private static IArgumentPatternMatchResult<TEnum> Target<TEnum>(IPatternFixture<TEnum> fixture, TypedConstant argument) => fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private static void Unsuccessful<TEnum>(string source)
        where TEnum : Enum
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<TEnum>>();

        var fixture = PatternFixtureFactory.Create<TEnum>();

        fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<TEnum>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(fixture, argument);

        Assert.Same(matchResult, result);
    }
}
