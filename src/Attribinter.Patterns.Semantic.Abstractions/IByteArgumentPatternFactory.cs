﻿namespace Attribinter.Patterns.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="byte"/> arguments.</summary>
public interface IByteArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of type <see cref="byte"/>.</summary>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TypedConstant, byte> Create();
}
