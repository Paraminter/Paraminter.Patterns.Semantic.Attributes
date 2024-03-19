namespace Attribinter;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("Design", "CA1028: Enum Storage should be Int32", Justification = "Testing support for non-int-based enums")]
public enum SByteEnum : sbyte
{
    None = 0
}
