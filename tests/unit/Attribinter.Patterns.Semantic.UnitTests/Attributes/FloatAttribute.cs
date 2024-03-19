namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class FloatAttribute : Attribute
{
    public float Value { get; }

    public FloatAttribute(float value)
    {
        Value = value;
    }
}
