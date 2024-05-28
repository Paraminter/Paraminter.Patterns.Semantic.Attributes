namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class IntEnumAttribute
    : Attribute
{
    public IntEnum Value { get; }

    public IntEnumAttribute(
        IntEnum value)
    {
        Value = value;
    }
}
