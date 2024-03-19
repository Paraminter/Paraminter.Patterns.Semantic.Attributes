namespace Attribinter.Patterns.Semantic;

using System;

/// <summary>Provides factories of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="Type"/> arguments.</summary>
public interface ITypeArgumentPatternFactoryProvider
{
    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="Type"/> arguments.</summary>
    public abstract INonNullableTypeArgumentPatternFactory NonNullable { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable <see cref="Type"/> arguments.</summary>
    public abstract INullableTypeArgumentPatternFactory Nullable { get; }
}
