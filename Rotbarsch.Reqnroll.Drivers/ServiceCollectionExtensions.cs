using Microsoft.Extensions.DependencyInjection;
using Rotbarsch.Reqnroll.Drivers.Interfaces;

namespace Rotbarsch.Reqnroll.Drivers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterRotbarschReqnrollDrivers(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IBasicVariableDriver, BasicVariableDriver>()
            .AddScoped<IBoolVariableDriver, BoolVariableDriver>()
            .AddScoped<ICollectionVariableDriver, CollectionVariableDriver>()
            .AddScoped<IDateTimeDriver, DateTimeDriver>()
            .AddScoped<IFileSystemDriver, FileSystemDriver>()
            .AddScoped<IJsonPathDriver, JsonPathDriver>()
            .AddScoped<IJsonSchemaDriver, JsonSchemaDriver>()
            .AddScoped<IRandomizerDriver, RandomizerDriver>()
            .AddScoped<IRegExDriver, RegExDriver>()
            .AddScoped<IStopwatchDriver, StopwatchDriver>()
            .AddScoped<IStringDriver, StringDriver>()
            .AddScoped<IWaitDriver, WaitDriver>()
            .AddScoped<IXmlDriver, XmlDriver>();

        return serviceCollection;
    }
}