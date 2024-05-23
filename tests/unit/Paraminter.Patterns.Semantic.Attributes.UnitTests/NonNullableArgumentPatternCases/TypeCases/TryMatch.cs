namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class TryMatch
{
    private readonly IPatternFixture<ITypeSymbol> Fixture = PatternFixtureFactory.CreateType();

    [Fact]
    public void TypeAttribute_NonNull_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableTypeAttribute(typeof(int))]
            public class Foo { }
            """;

        Successful(IntType, source);
    }

    [Fact]
    public void TypeAttribute_Null_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableTypeAttribute(null)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void ObjectAttribute_Type_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(typeof(int))]
            public class Foo { }
            """;

        Successful(IntType, source);
    }

    [Fact]
    public void ObjectAttribute_Int_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute(1)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void ObjectAttribute_String_Unsuccessful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NonNullableObjectAttribute("")]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    private static ITypeSymbol IntType(Compilation compilation) => compilation.GetSpecialType(SpecialType.System_Int32);

    private IArgumentPatternMatchResult<ITypeSymbol> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(Func<Compilation, ITypeSymbol> matchedArgumentDelegate, string source)
    {
        var compilation = CSharpCompilationFactory.Create(source);

        var matchedArgument = matchedArgumentDelegate(compilation);

        var matchResult = Mock.Of<IArgumentPatternMatchResult<ITypeSymbol>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<ITypeSymbol>>();

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Unsuccessful.Create<ITypeSymbol>()).Returns(matchResult);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
