namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

internal static class TypedConstantFactory
{
    public static TypedConstant Create(string source)
    {
        var compilation = CSharpCompilationFactory.GetCompilation(source);

        return compilation.GetTypeByMetadataName("Foo")!.GetAttributes()[0].ConstructorArguments[0];
    }
}
