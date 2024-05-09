namespace Paraminter.Patterns.Semantic.Attributes;

/// <summary>Provides factories of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="object"/> arguments.</summary>
public interface IObjectArgumentPatternFactoryProvider
{
    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="object"/> arguments.</summary>
    public abstract INonNullableObjectArgumentPatternFactory NonNullable { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable <see cref="object"/> arguments.</summary>
    public abstract INullableObjectArgumentPatternFactory Nullable { get; }
}
