namespace Attribinter.Patterns.Semantic.IntArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new IntArgumentPatternFactory());

    public IntArgumentPatternFactory Factory { get; }

    private FactoryContext(IntArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
