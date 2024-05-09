namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class NullableObjectAttribute : Attribute
{
    public object? Value { get; }

    public NullableObjectAttribute(object? value)
    {
        Value = value;
    }
}
