namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ULongEnumAttribute : Attribute
{
    public ULongEnum Value { get; }

    public ULongEnumAttribute(ULongEnum value)
    {
        Value = value;
    }
}
