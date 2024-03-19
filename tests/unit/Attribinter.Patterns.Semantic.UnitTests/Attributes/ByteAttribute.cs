namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ByteAttribute : Attribute
{
    public byte Value { get; }

    public ByteAttribute(byte value)
    {
        Value = value;
    }
}
