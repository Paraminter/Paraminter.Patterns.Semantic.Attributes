﻿namespace Attribinter;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class UIntEnumAttribute : Attribute
{
    public UIntEnum Value { get; }

    public UIntEnumAttribute(UIntEnum value)
    {
        Value = value;
    }
}
