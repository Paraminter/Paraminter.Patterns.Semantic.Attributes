namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class UShortEnumAttribute : Attribute
{
    public UShortEnum Value { get; }

    public UShortEnumAttribute(UShortEnum value)
    {
        Value = value;
    }
}
