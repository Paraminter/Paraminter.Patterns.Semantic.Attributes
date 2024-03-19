namespace Attribinter.Patterns.Semantic.ULongArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new ULongArgumentPatternFactory());

    public ULongArgumentPatternFactory Factory { get; }

    private FactoryContext(ULongArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
