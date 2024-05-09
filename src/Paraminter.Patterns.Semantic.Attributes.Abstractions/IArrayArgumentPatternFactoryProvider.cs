namespace Paraminter.Patterns.Semantic.Attributes;

/// <summary>Provides factories of <see cref="IArgumentPattern{TIn, TOut}"/> matching array-valued arguments.</summary>
public interface IArrayArgumentPatternFactoryProvider
{
    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable array-valued arguments.</summary>
    public abstract INonNullableArrayArgumentPatternFactory NonNullable { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable array-valued arguments.</summary>
    public abstract INullableArrayArgumentPatternFactory Nullable { get; }
}
