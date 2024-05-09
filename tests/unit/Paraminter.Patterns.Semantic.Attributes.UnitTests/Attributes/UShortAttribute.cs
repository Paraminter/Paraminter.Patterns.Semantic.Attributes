﻿namespace Paraminter.Patterns.Semantic.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class UShortAttribute : Attribute
{
    public ushort Value { get; }

    public UShortAttribute(ushort value)
    {
        Value = value;
    }
}
