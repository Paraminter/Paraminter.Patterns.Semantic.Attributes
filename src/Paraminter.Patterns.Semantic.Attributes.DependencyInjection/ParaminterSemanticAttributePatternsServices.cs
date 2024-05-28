namespace Paraminter.Patterns.Semantic.Attributes;

using Microsoft.Extensions.DependencyInjection;

using System;

/// <summary>Allows the services provided by <i>Paraminter.Patterns.Semantic.Attributes</i> to be registered with a <see cref="IServiceCollection"/>.</summary>
public static class ParaminterSemanticAttributePatternsServices
{
    /// <summary>Registers the services provided by <i>Paraminter.Patterns.Semantic.Attributes</i> with the provided <see cref="IServiceCollection"/>.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> with which services are registered.</param>
    /// <returns>The provided <see cref="IServiceCollection"/>, so that calls can be chained.</returns>
    public static IServiceCollection AddParaminterSemanticAttributePatterns(
        this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddParaminterPatterns();

        services.AddTransient<IArgumentPatternFactoryProvider, ArgumentPatternFactoryProvider>();
        services.AddTransient<IStringArgumentPatternFactoryProvider, StringArgumentPatternFactoryProvider>();
        services.AddTransient<IObjectArgumentPatternFactoryProvider, ObjectArgumentPatternFactoryProvider>();
        services.AddTransient<ITypeArgumentPatternFactoryProvider, TypeArgumentPatternFactoryProvider>();
        services.AddTransient<IArrayArgumentPatternFactoryProvider, ArrayArgumentPatternFactoryProvider>();

        services.AddTransient<IBoolArgumentPatternFactory, BoolArgumentPatternFactory>();
        services.AddTransient<IByteArgumentPatternFactory, ByteArgumentPatternFactory>();
        services.AddTransient<ISByteArgumentPatternFactory, SByteArgumentPatternFactory>();
        services.AddTransient<ICharArgumentPatternFactory, CharArgumentPatternFactory>();
        services.AddTransient<IShortArgumentPatternFactory, ShortArgumentPatternFactory>();
        services.AddTransient<IUShortArgumentPatternFactory, UShortArgumentPatternFactory>();
        services.AddTransient<IIntArgumentPatternFactory, IntArgumentPatternFactory>();
        services.AddTransient<IUIntArgumentPatternFactory, UIntArgumentPatternFactory>();
        services.AddTransient<ILongArgumentPatternFactory, LongArgumentPatternFactory>();
        services.AddTransient<IULongArgumentPatternFactory, ULongArgumentPatternFactory>();
        services.AddTransient<IFloatArgumentPatternFactory, FloatArgumentPatternFactory>();
        services.AddTransient<IDoubleArgumentPatternFactory, DoubleArgumentPatternFactory>();
        services.AddTransient<IEnumArgumentPatternFactory, EnumArgumentPatternFactory>();

        services.AddTransient<INonNullableStringArgumentPatternFactory, NonNullableStringArgumentPatternFactory>();
        services.AddTransient<INullableStringArgumentPatternFactory, NullableStringArgumentPatternFactory>();
        services.AddTransient<INonNullableObjectArgumentPatternFactory, NonNullableObjectArgumentPatternFactory>();
        services.AddTransient<INonNullableArrayArgumentPatternFactory, NonNullableArrayArgumentPatternFactory>();
        services.AddTransient<INullableObjectArgumentPatternFactory, NullableObjectArgumentPatternFactory>();
        services.AddTransient<INonNullableTypeArgumentPatternFactory, NonNullableTypeArgumentPatternFactory>();
        services.AddTransient<INullableTypeArgumentPatternFactory, NullableTypeArgumentPatternFactory>();
        services.AddTransient<INullableArrayArgumentPatternFactory, NullableArrayArgumentPatternFactory>();

        return services;
    }
}
