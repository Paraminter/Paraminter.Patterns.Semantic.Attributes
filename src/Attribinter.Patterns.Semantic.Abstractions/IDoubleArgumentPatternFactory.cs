namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="double"/> arguments.</summary>
public interface IDoubleArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="double"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, double> Create();
}
