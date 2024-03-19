namespace Attribinter.Patterns.Semantic.StringArgumentPatternFactoryProviderCases;

using Moq;

internal sealed class ProviderContext
{
    public static ProviderContext Create()
    {
        var nonNullableArgumentPatternFactory = Mock.Of<INonNullableStringArgumentPatternFactory>();
        var nullableArgumentPatternFactory = Mock.Of<INullableStringArgumentPatternFactory>();

        StringArgumentPatternFactoryProvider provider = new(nonNullableArgumentPatternFactory, nullableArgumentPatternFactory);

        return new(provider, nonNullableArgumentPatternFactory, nullableArgumentPatternFactory);
    }

    public IStringArgumentPatternFactoryProvider Provider { get; }

    public INonNullableStringArgumentPatternFactory NonNullable { get; }
    public INullableStringArgumentPatternFactory Nullable { get; }

    public ProviderContext(IStringArgumentPatternFactoryProvider provider, INonNullableStringArgumentPatternFactory nonNullable, INullableStringArgumentPatternFactory nullable)
    {
        Provider = provider;

        NonNullable = nonNullable;
        Nullable = nullable;
    }
}
