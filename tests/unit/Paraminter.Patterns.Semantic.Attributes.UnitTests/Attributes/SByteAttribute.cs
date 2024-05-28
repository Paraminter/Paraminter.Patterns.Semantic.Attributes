namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class SByteAttribute
    : Attribute
{
    public sbyte Value { get; }

    public SByteAttribute(
        sbyte value)
    {
        Value = value;
    }
}
