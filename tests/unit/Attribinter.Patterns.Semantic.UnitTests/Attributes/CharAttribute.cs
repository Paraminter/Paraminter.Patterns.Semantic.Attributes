namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class CharAttribute : Attribute
{
    public char Value { get; }

    public CharAttribute(char value)
    {
        Value = value;
    }
}
