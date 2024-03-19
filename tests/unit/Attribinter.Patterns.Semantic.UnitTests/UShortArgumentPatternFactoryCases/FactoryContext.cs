namespace Attribinter.Patterns.Semantic.UShortArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new UShortArgumentPatternFactory());

    public UShortArgumentPatternFactory Factory { get; }

    private FactoryContext(UShortArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
