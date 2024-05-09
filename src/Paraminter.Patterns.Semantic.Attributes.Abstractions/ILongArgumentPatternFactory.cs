namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="long"/> arguments.</summary>
public interface ILongArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="long"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, long> Create();
}
