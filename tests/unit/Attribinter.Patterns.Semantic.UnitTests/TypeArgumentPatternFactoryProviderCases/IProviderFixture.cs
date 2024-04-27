﻿namespace Attribinter.Patterns.Semantic.TypeArgumentPatternFactoryProviderCases;

using Moq;

internal interface IProviderFixture
{
    public abstract ITypeArgumentPatternFactoryProvider Sut { get; }

    public abstract Mock<INonNullableTypeArgumentPatternFactory> NonNullableMock { get; }
    public abstract Mock<INullableTypeArgumentPatternFactory> NullableMock { get; }
}
