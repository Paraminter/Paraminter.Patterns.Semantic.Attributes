namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

internal static class TypedConstantFactory
{
    public static TypedConstant Create(
        string source)
    {
        var compilation = CSharpCompilationFactory.Create(source);

        return compilation.GetTypeByMetadataName("Paraminter.Patterns.Semantic.Attributes.Foo")!.GetAttributes()[0].ConstructorArguments[0];
    }
}
