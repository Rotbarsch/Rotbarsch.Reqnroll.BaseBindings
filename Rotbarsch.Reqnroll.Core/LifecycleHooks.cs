using Rotbarsch.Reqnroll.Services.Interfaces;
using Reqnroll;

namespace Rotbarsch.Reqnroll.Core;

/// <summary>
/// Default class for adding hooks for Reqnroll lifecycle.
/// </summary>
/// <param name="loggingService">Logger.</param>
/// <param name="settingsService">SettingsService.</param>
[Binding]
public class LifecycleHooks(ITestOutputLoggingService loggingService, IRotbarschReqnrollSettingsService settingsService)
{
    [BeforeScenario]
    public void OnBeforeScenario()
    {
        var loadedSettingsFiles = settingsService.GetLoadedSettingsFiles();
        loggingService.WriteLine($"Loaded and applied the following rotbarsch.reqnroll.json files: {string.Join(", ", loadedSettingsFiles)}");
    }
}