namespace Attribinter.Patterns.Semantic.BoolArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new BoolArgumentPatternFactory());

    public BoolArgumentPatternFactory Factory { get; }

    private FactoryContext(BoolArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
