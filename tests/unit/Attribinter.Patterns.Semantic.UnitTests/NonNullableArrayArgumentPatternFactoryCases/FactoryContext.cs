namespace Attribinter.Patterns.Semantic.NonNullableArrayArgumentPatternFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create()
    {
        NonNullableArrayArgumentPatternFactory factory = new();

        return new(factory);
    }

    public INonNullableArrayArgumentPatternFactory Factory { get; }

    public FactoryContext(INonNullableArrayArgumentPatternFactory factory)
    {
        Factory = factory;
    }
}
