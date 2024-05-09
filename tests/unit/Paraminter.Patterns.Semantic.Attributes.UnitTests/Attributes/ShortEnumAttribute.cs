namespace Paraminter.Patterns.Semantic.Attributes;

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
