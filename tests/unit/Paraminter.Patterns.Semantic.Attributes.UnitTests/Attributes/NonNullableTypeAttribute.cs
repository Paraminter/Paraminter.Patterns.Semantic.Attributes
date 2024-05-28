namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class NonNullableTypeAttribute
    : Attribute
{
    public Type Value { get; }

    public NonNullableTypeAttribute(
        Type value)
    {
        Value = value;
    }
}
