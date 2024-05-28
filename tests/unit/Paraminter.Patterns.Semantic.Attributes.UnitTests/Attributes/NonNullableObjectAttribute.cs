namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class NonNullableObjectAttribute
    : Attribute
{
    public object Value { get; }

    public NonNullableObjectAttribute(
        object value)
    {
        Value = value;
    }
}
