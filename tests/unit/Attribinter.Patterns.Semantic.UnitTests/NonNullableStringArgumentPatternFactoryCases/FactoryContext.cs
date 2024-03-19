namespace Attribinter.Patterns.Semantic.NonNullableStringArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create() => new(new NonNullableStringArgumentPatternFactory());

    public NonNullableStringArgumentPatternFactory Factory { get; }

    private FactoryContext(NonNullableStringArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
