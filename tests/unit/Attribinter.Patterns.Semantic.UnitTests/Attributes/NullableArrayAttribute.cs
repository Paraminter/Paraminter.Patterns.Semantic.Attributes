namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class NullableArrayAttribute : Attribute
{
    public object[]? Value { get; }

    public NullableArrayAttribute(object[]? value)
    {
        Value = value;
    }
}
