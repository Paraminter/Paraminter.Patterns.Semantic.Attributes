namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ByteEnumAttribute : Attribute
{
    public ByteEnum Value { get; }

    public ByteEnumAttribute(ByteEnum value)
    {
        Value = value;
    }
}
