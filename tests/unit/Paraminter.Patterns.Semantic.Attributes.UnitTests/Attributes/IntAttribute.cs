namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class IntAttribute : Attribute
{
    public int Value { get; }

    public IntAttribute(int value)
    {
        Value = value;
    }
}
