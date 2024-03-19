namespace Attribinter.Patterns.Semantic.ShortArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new ShortArgumentPatternFactory());

    public ShortArgumentPatternFactory Factory { get; }

    private FactoryContext(ShortArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
