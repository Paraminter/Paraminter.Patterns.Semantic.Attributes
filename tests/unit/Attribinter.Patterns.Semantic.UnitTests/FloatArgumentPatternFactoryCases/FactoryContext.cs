namespace Attribinter.Patterns.Semantic.FloatArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new FloatArgumentPatternFactory());

    public FloatArgumentPatternFactory Factory { get; }

    private FactoryContext(FloatArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
