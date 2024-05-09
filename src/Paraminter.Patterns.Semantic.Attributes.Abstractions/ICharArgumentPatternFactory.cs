namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="char"/> arguments.</summary>
public interface ICharArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="char"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, char> Create();
}
