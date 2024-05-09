namespace Paraminter.Patterns.Semantic.Attributes;

using System;

/// <inheritdoc cref="IArgumentPatternFactoryProvider"/>
public sealed class ArgumentPatternFactoryProvider : IArgumentPatternFactoryProvider
{
    private readonly IBoolArgumentPatternFactory Bool;
    private readonly IByteArgumentPatternFactory Byte;
    private readonly ISByteArgumentPatternFactory SByte;
    private readonly ICharArgumentPatternFactory Char;
    private readonly IShortArgumentPatternFactory Short;
    private readonly IUShortArgumentPatternFactory UShort;
    private readonly IIntArgumentPatternFactory Int;
    private readonly IUIntArgumentPatternFactory UInt;
    private readonly ILongArgumentPatternFactory Long;
    private readonly IULongArgumentPatternFactory ULong;
    private readonly IFloatArgumentPatternFactory Float;
    private readonly IDoubleArgumentPatternFactory Double;
    private readonly IEnumArgumentPatternFactory Enum;

    private readonly IStringArgumentPatternFactoryProvider String;
    private readonly IObjectArgumentPatternFactoryProvider Object;
    private readonly ITypeArgumentPatternFactoryProvider Type;
    private readonly IArrayArgumentPatternFactoryProvider Array;

    /// <summary>Instantiates a <see cref="ArgumentPatternFactoryProvider"/>, providing factories of <see cref="IArgumentPattern{TIn, TOut}"/>.</summary>
    /// <param name="boolArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="bool"/> arguments.</param>
    /// <param name="byteArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="byte"/> arguments.</param>
    /// <param name="sbyteArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="sbyte"/> arguments.</param>
    /// <param name="charArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="char"/> arguments.</param>
    /// <param name="shortArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="short"/> arguments.</param>
    /// <param name="ushortArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="ushort"/> arguments.</param>
    /// <param name="intArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="int"/> arguments.</param>
    /// <param name="uintArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="uint"/> arguments.</param>
    /// <param name="longArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="long"/> arguments.</param>
    /// <param name="ulongArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="ulong"/> arguments.</param>
    /// <param name="floatArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="float"/> arguments.</param>
    /// <param name="doubleArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="double"/> arguments.</param>
    /// <param name="enumArgumentPatternFactory">Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching enum arguments.</param>
    /// <param name="stringArgumentPatternFactoryProvider">Provides factories handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="string"/> arguments.</param>
    /// <param name="objectArgumentPatternFactoryProvider">Provides factories handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="object"/> arguments.</param>
    /// <param name="typeArgumentPatternFactoryProvider">Provides factories handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="System.Type"/> arguments.</param>
    /// <param name="arrayArgumentPatternFactoryProvider">Provides factories handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching array-valued arguments.</param>
    public ArgumentPatternFactoryProvider(
        IBoolArgumentPatternFactory boolArgumentPatternFactory,
        IByteArgumentPatternFactory byteArgumentPatternFactory,
        ISByteArgumentPatternFactory sbyteArgumentPatternFactory,
        ICharArgumentPatternFactory charArgumentPatternFactory,
        IShortArgumentPatternFactory shortArgumentPatternFactory,
        IUShortArgumentPatternFactory ushortArgumentPatternFactory,
        IIntArgumentPatternFactory intArgumentPatternFactory,
        IUIntArgumentPatternFactory uintArgumentPatternFactory,
        ILongArgumentPatternFactory longArgumentPatternFactory,
        IULongArgumentPatternFactory ulongArgumentPatternFactory,
        IFloatArgumentPatternFactory floatArgumentPatternFactory,
        IDoubleArgumentPatternFactory doubleArgumentPatternFactory,
        IEnumArgumentPatternFactory enumArgumentPatternFactory,
        IStringArgumentPatternFactoryProvider stringArgumentPatternFactoryProvider,
        IObjectArgumentPatternFactoryProvider objectArgumentPatternFactoryProvider,
        ITypeArgumentPatternFactoryProvider typeArgumentPatternFactoryProvider,
        IArrayArgumentPatternFactoryProvider arrayArgumentPatternFactoryProvider)
    {
        Bool = boolArgumentPatternFactory ?? throw new ArgumentNullException(nameof(boolArgumentPatternFactory));
        Byte = byteArgumentPatternFactory ?? throw new ArgumentNullException(nameof(byteArgumentPatternFactory));
        SByte = sbyteArgumentPatternFactory ?? throw new ArgumentNullException(nameof(sbyteArgumentPatternFactory));
        Char = charArgumentPatternFactory ?? throw new ArgumentNullException(nameof(charArgumentPatternFactory));
        Short = shortArgumentPatternFactory ?? throw new ArgumentNullException(nameof(shortArgumentPatternFactory));
        UShort = ushortArgumentPatternFactory ?? throw new ArgumentNullException(nameof(ushortArgumentPatternFactory));
        Int = intArgumentPatternFactory ?? throw new ArgumentNullException(nameof(intArgumentPatternFactory));
        UInt = uintArgumentPatternFactory ?? throw new ArgumentNullException(nameof(uintArgumentPatternFactory));
        Long = longArgumentPatternFactory ?? throw new ArgumentNullException(nameof(longArgumentPatternFactory));
        ULong = ulongArgumentPatternFactory ?? throw new ArgumentNullException(nameof(ulongArgumentPatternFactory));
        Float = floatArgumentPatternFactory ?? throw new ArgumentNullException(nameof(floatArgumentPatternFactory));
        Double = doubleArgumentPatternFactory ?? throw new ArgumentNullException(nameof(doubleArgumentPatternFactory));
        Enum = enumArgumentPatternFactory ?? throw new ArgumentNullException(nameof(enumArgumentPatternFactory));
        String = stringArgumentPatternFactoryProvider ?? throw new ArgumentNullException(nameof(stringArgumentPatternFactoryProvider));
        Object = objectArgumentPatternFactoryProvider ?? throw new ArgumentNullException(nameof(objectArgumentPatternFactoryProvider));
        Type = typeArgumentPatternFactoryProvider ?? throw new ArgumentNullException(nameof(typeArgumentPatternFactoryProvider));
        Array = arrayArgumentPatternFactoryProvider ?? throw new ArgumentNullException(nameof(arrayArgumentPatternFactoryProvider));
    }

    IBoolArgumentPatternFactory IArgumentPatternFactoryProvider.Bool => Bool;
    IByteArgumentPatternFactory IArgumentPatternFactoryProvider.Byte => Byte;
    ISByteArgumentPatternFactory IArgumentPatternFactoryProvider.SByte => SByte;
    ICharArgumentPatternFactory IArgumentPatternFactoryProvider.Char => Char;
    IShortArgumentPatternFactory IArgumentPatternFactoryProvider.Short => Short;
    IUShortArgumentPatternFactory IArgumentPatternFactoryProvider.UShort => UShort;
    IIntArgumentPatternFactory IArgumentPatternFactoryProvider.Int => Int;
    IUIntArgumentPatternFactory IArgumentPatternFactoryProvider.UInt => UInt;
    ILongArgumentPatternFactory IArgumentPatternFactoryProvider.Long => Long;
    IULongArgumentPatternFactory IArgumentPatternFactoryProvider.ULong => ULong;
    IFloatArgumentPatternFactory IArgumentPatternFactoryProvider.Float => Float;
    IDoubleArgumentPatternFactory IArgumentPatternFactoryProvider.Double => Double;

    IEnumArgumentPatternFactory IArgumentPatternFactoryProvider.Enum => Enum;

    IStringArgumentPatternFactoryProvider IArgumentPatternFactoryProvider.String => String;
    IObjectArgumentPatternFactoryProvider IArgumentPatternFactoryProvider.Object => Object;
    ITypeArgumentPatternFactoryProvider IArgumentPatternFactoryProvider.Type => Type;
    IArrayArgumentPatternFactoryProvider IArgumentPatternFactoryProvider.Array => Array;
}
