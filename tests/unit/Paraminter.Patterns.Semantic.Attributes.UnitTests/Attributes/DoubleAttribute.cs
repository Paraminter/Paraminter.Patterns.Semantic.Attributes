namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DoubleAttribute : Attribute
{
    public double Value { get; }

    public DoubleAttribute(double value)
    {
        Value = value;
    }
}
