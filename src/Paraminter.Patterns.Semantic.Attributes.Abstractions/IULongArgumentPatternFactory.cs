namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="ulong"/> arguments.</summary>
public interface IULongArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="ulong"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, ulong> Create();
}
