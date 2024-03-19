namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

using System;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<ITypeSymbol> Target(IArgumentPattern<TypedConstant, ITypeSymbol> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext Context = PatternContext.Create();

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

    [AssertionMethod]
    private static void Successful(Func<Compilation, ITypeSymbol> expectedDelegate, string source)
    {
        var compilation = CSharpCompilationFactory.GetCompilation(source);

        var expected = expectedDelegate(compilation);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }

    [AssertionMethod]
    private static void Unsuccessful(string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.False(result.Successful);
    }
}
