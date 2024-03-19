namespace Attribinter.Patterns.Semantic.ByteArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new ByteArgumentPatternFactory());

    public ByteArgumentPatternFactory Factory { get; }

    private FactoryContext(ByteArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
