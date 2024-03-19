namespace Attribinter.Patterns.Semantic.LongArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new LongArgumentPatternFactory());

    public LongArgumentPatternFactory Factory { get; }

    private FactoryContext(LongArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
