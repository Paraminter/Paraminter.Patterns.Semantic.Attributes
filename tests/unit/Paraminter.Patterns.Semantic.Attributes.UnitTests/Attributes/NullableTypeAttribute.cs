namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class NullableTypeAttribute : Attribute
{
    public Type? Value { get; }

    public NullableTypeAttribute(Type? value)
    {
        Value = value;
    }
}
