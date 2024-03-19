namespace Attribinter.Patterns.Semantic.TypeArgumentPatternFactoryProviderCases;

using Moq;

internal sealed class ProviderContext
{
    public static ProviderContext Create()
    {
        var nonNullable = Mock.Of<INonNullableTypeArgumentPatternFactory>();
        var nullable = Mock.Of<INullableTypeArgumentPatternFactory>();

        TypeArgumentPatternFactoryProvider provider = new(nonNullable, nullable);

        return new(provider, nonNullable, nullable);
    }

    public ITypeArgumentPatternFactoryProvider Provider { get; }

    public INonNullableTypeArgumentPatternFactory NonNullable { get; }
    public INullableTypeArgumentPatternFactory Nullable { get; }

    public ProviderContext(ITypeArgumentPatternFactoryProvider provider, INonNullableTypeArgumentPatternFactory nonNullable, INullableTypeArgumentPatternFactory nullable)
    {
        Provider = provider;

        NonNullable = nonNullable;
        Nullable = nullable;
    }
}
