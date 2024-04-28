namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

using System;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void TypeAttribute_NonNull_Successful()
    {
        var source = """
            [Attribinter.NonNullableType(typeof(int))]
            public class Foo { }
            """;

        Successful(IntType, source);
    }

    [Fact]
    public void TypeAttribute_Null_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableType(null)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void ObjectAttribute_Type_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(typeof(int))]
            public class Foo { }
            """;

        Successful(IntType, source);
    }

    [Fact]
    public void ObjectAttribute_Int_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject(1)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void ObjectAttribute_String_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject("")]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    private static ITypeSymbol IntType(Compilation compilation) => compilation.GetSpecialType(SpecialType.System_Int32);

    private ArgumentPatternMatchResult<ITypeSymbol> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(Func<Compilation, ITypeSymbol> expectedDelegate, string source)
    {
        var compilation = CSharpCompilationFactory.GetCompilation(source);

        var expected = expectedDelegate(compilation);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.False(result.Successful);
    }
}
