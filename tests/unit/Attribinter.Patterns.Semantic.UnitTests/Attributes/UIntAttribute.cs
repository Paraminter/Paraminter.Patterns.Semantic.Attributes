namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class UIntAttribute : Attribute
{
    public uint Value { get; }

    public UIntAttribute(uint value)
    {
        Value = value;
    }
}
