namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ULongAttribute
    : Attribute
{
    public ulong Value { get; }

    public ULongAttribute(
        ulong value)
    {
        Value = value;
    }
}
