namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.CodeAnalysis;

/// <summary>Provides factories handling creation of <see cref="IArgumentPattern{TIn, TOut}"/>.</summary>
public interface IArgumentPatternFactoryProvider
{
    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="bool"/> arguments.</summary>
    public abstract IBoolArgumentPatternFactory Bool { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="byte"/> arguments.</summary>
    public abstract IByteArgumentPatternFactory Byte { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="sbyte"/> arguments.</summary>
    public abstract ISByteArgumentPatternFactory SByte { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="char"/> arguments.</summary>
    public abstract ICharArgumentPatternFactory Char { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="short"/> arguments.</summary>
    public abstract IShortArgumentPatternFactory Short { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="ushort"/> arguments.</summary>
    public abstract IUShortArgumentPatternFactory UShort { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="int"/> arguments.</summary>
    public abstract IIntArgumentPatternFactory Int { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="uint"/> arguments.</summary>
    public abstract IUIntArgumentPatternFactory UInt { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="long"/> arguments.</summary>
    public abstract ILongArgumentPatternFactory Long { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="ulong"/> arguments.</summary>
    public abstract IULongArgumentPatternFactory ULong { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="float"/> arguments.</summary>
    public abstract IFloatArgumentPatternFactory Float { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="double"/> arguments.</summary>
    public abstract IDoubleArgumentPatternFactory Double { get; }

    /// <summary>Handles creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching enum arguments.</summary>
    public abstract IEnumArgumentPatternFactory Enum { get; }

    /// <summary>Privates factories handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="string"/> arguments.</summary>
    public abstract IStringArgumentPatternFactoryProvider String { get; }

    /// <summary>Privates factories handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="object"/> arguments.</summary>
    public abstract IObjectArgumentPatternFactoryProvider Object { get; }

    /// <summary>Provides factories handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching <see cref="ITypeSymbol"/> arguments.</summary>
    /// <remarks>Attribute arguments of type <see cref="System.Type"/> will match the patterns created by these factories, as Roslyn uses <see cref="ITypeSymbol"/> to represent <see cref="System.Type"/>.</remarks>
    public abstract ITypeArgumentPatternFactoryProvider Type { get; }

    /// <summary>Privates factories handling creation of <see cref="IArgumentPattern{TIn, TOut}"/> matching array-valued arguments.</summary>
    public abstract IArrayArgumentPatternFactoryProvider Array { get; }
}
