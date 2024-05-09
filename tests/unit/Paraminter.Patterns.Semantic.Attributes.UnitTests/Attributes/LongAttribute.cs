namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class LongAttribute : Attribute
{
    public long Value { get; }

    public LongAttribute(long value)
    {
        Value = value;
    }
}
