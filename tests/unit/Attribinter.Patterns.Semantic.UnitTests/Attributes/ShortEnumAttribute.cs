namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ShortEnumAttribute : Attribute
{
    public ShortEnum Value { get; }

    public ShortEnumAttribute(ShortEnum value)
    {
        Value = value;
    }
}
