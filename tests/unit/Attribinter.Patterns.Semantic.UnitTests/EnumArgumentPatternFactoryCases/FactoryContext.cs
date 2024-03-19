namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new EnumArgumentPatternFactory());

    public EnumArgumentPatternFactory Factory { get; }

    private FactoryContext(EnumArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
