namespace Attribinter.Patterns.Semantic.DoubleArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new DoubleArgumentPatternFactory());

    public DoubleArgumentPatternFactory Factory { get; }

    private FactoryContext(DoubleArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
