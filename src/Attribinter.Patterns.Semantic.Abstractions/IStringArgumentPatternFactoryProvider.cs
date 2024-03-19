namespace Attribinter.Patterns.Semantic;

/// <summary>Provides factories of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="string"/> arguments.</summary>
public interface IStringArgumentPatternFactoryProvider
{
    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching non-nullable <see cref="string"/> arguments.</summary>
    public abstract INonNullableStringArgumentPatternFactory NonNullable { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching nullable <see cref="string"/> arguments.</summary>
    public abstract INullableStringArgumentPatternFactory Nullable { get; }
}
