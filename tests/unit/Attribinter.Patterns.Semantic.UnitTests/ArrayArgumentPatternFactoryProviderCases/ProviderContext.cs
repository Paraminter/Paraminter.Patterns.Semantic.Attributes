namespace Attribinter.Patterns.Semantic.ArrayArgumentPatternFactoryProviderCases;

using Moq;

internal sealed class ProviderContext
{
    public static ProviderContext Create()
    {
        var nonNullable = Mock.Of<INonNullableArrayArgumentPatternFactory>();
        var nullable = Mock.Of<INullableArrayArgumentPatternFactory>();

        ArrayArgumentPatternFactoryProvider provider = new(nonNullable, nullable);

        return new(provider, nonNullable, nullable);
    }

    public IArrayArgumentPatternFactoryProvider Provider { get; }

    public INonNullableArrayArgumentPatternFactory NonNullable { get; }
    public INullableArrayArgumentPatternFactory Nullable { get; }

    public ProviderContext(IArrayArgumentPatternFactoryProvider provider, INonNullableArrayArgumentPatternFactory nonNullable, INullableArrayArgumentPatternFactory nullable)
    {
        Provider = provider;

        NonNullable = nonNullable;
        Nullable = nullable;
    }
}
