namespace Attribinter.Patterns.Semantic.SByteArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new SByteArgumentPatternFactory());

    public SByteArgumentPatternFactory Factory { get; }

    private FactoryContext(SByteArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
