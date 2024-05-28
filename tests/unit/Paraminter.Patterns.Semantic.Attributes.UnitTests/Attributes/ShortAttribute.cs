namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ShortAttribute
    : Attribute
{
    public short Value { get; }

    public ShortAttribute(
        short value)
    {
        Value = value;
    }
}
