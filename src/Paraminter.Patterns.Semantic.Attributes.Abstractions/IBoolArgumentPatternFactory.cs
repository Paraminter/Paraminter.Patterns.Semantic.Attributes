namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="bool"/> arguments.</summary>
public interface IBoolArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="bool"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, bool> Create();
}
