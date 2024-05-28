namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class BoolAttribute
    : Attribute
{
    public bool Value { get; }

    public BoolAttribute(
        bool value)
    {
        Value = value;
    }
}
