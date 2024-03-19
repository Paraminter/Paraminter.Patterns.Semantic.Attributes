namespace Attribinter.Patterns.Semantic.ObjectArgumentPatternFactoryProviderCases;

using Moq;

internal sealed class ProviderContext
{
    public static ProviderContext Create()
    {
        var nonNullable = Mock.Of<INonNullableObjectArgumentPatternFactory>();
        var nullable = Mock.Of<INullableObjectArgumentPatternFactory>();

        ObjectArgumentPatternFactoryProvider provider = new(nonNullable, nullable);

        return new(provider, nonNullable, nullable);
    }

    public IObjectArgumentPatternFactoryProvider Provider { get; }

    public INonNullableObjectArgumentPatternFactory NonNullable { get; }
    public INullableObjectArgumentPatternFactory Nullable { get; }

    public ProviderContext(IObjectArgumentPatternFactoryProvider provider, INonNullableObjectArgumentPatternFactory nonNullable, INullableObjectArgumentPatternFactory nullable)
    {
        Provider = provider;

        NonNullable = nonNullable;
        Nullable = nullable;
    }
}
