namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class SByteEnumAttribute : Attribute
{
    public SByteEnum Value { get; }

    public SByteEnumAttribute(SByteEnum value)
    {
        Value = value;
    }
}
