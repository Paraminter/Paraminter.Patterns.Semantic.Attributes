namespace Attribinter.Patterns.Semantic.NullableObjectArgumentPatternFactoryCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class Create
{
    private static IArgumentPattern<TypedConstant, object?> Target(INullableObjectArgumentPatternFactory factory) => factory.Create();

    private static readonly FactoryContext Context = FactoryContext.Create();

    [Fact]
    public void ReturnsNotNull()
    {
        var actual = Target(Context.Factory);

        Assert.NotNull(actual);

        Context.NonNullablePatternFactoryMock.Verify(static (factory) => factory.Create(), Times.Once());

        Context.NonNullablePatternFactoryMock.VerifyNoOtherCalls();
    }
}
