namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class LongEnumAttribute : Attribute
{
    public LongEnum Value { get; }

    public LongEnumAttribute(LongEnum value)
    {
        Value = value;
    }
}
