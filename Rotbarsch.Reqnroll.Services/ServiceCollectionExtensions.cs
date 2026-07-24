using Microsoft.Extensions.DependencyInjection;
using Rotbarsch.Reqnroll.Services.Interfaces;

namespace Rotbarsch.Reqnroll.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterRotbarschReqnrollServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IRotbarschReqnrollSettingsService, RotbarschReqnrollSettingsService>()
            .AddScoped<IBoolService, BoolService>()
            .AddScoped<IComparisonService, ComparisonService>()
            .AddScoped<ICultureInfoService, CultureInfoService>()
            .AddScoped<IDateTimeManipulationService, DateTimeManipulationService>()
            .AddScoped<IDebugUtilityService, DebugUtilityService>()
            .AddScoped<IFileSystemService, FileSystemService>()
            .AddScoped<IJsonPathService, JsonPathService>()
            .AddScoped<INumericService, NumericService>()
            .AddScoped<IRandomDataService, RandomDataService>()
            .AddScoped<IStopwatchService, StopwatchService>()
            .AddScoped<ITestOutputLoggingService, TestOutputLoggingService>()
            .AddScoped<IVariableService, VariableService>()
            .AddScoped<IWaitService, WaitService>()
            .AddScoped<IXPathService, XPathService>();

        return serviceCollection;
    }
}