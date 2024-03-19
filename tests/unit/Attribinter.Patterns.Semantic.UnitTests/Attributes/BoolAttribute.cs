namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class BoolAttribute : Attribute
{
    public bool Value { get; }

    public BoolAttribute(bool value)
    {
        Value = value;
    }
}
