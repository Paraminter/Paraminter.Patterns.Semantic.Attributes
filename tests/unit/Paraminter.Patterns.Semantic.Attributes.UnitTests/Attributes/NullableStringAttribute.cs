namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class NullableStringAttribute
    : Attribute
{
    public string? Value { get; }

    public NullableStringAttribute(
        string? value)
    {
        Value = value;
    }
}
