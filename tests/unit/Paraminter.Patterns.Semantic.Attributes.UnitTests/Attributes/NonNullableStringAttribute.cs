namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class NonNullableStringAttribute : Attribute
{
    public string Value { get; }

    public NonNullableStringAttribute(string value)
    {
        Value = value;
    }
}
