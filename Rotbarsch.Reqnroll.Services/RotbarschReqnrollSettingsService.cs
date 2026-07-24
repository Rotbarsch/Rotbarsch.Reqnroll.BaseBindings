using Rotbarsch.Reqnroll.Core.Contracts.Settings;
using Rotbarsch.Reqnroll.Services.Interfaces;
using Newtonsoft.Json.Linq;

namespace Rotbarsch.Reqnroll.Services;

/// <summary>
/// Service for interacting with RotbarschReqnrollSettings.json file.
/// </summary>
public class RotbarschReqnrollSettingsService : IRotbarschReqnrollSettingsService
{
    private readonly RotbarschReqnrollSettings _settings;
    private readonly List<string> _loadedSettingsFiles = [];
    private static readonly string SettingsFileName = "rotbarsch.reqnroll.json";

    public RotbarschReqnrollSettingsService()
    {
        _settings = ConstructSettings();
    }

    /// <summary>
    /// Returns configured global variables.
    /// </summary>
    /// <returns>All variables as defined in settings.</returns>
    public IEnumerable<SettingsVariable> GetVariables() => _settings.GlobalVariables;

    /// <summary>
    /// Returns configured file redirects.
    /// </summary>
    /// <returns>All file redirects as defined in settings.</returns>
    public IEnumerable<FileRedirect> GetFileRedirects() => _settings.FileRedirects;

    /// <summary>
    /// Returns logging configuration.
    /// </summary>
    /// <returns>The logging configuration.</returns>
    public RotbarschReqnrollLoggingSettings GetLoggingSettings() => _settings.Logging;

    /// <summary>
    /// Returns paths of all actually loaded settings files.
    /// </summary>
    /// <returns>List of file paths.</returns>
    public IEnumerable<string> GetLoadedSettingsFiles() => _loadedSettingsFiles;

    private RotbarschReqnrollSettings ConstructSettings()
    {
        if (!File.Exists(SettingsFileName)) return new RotbarschReqnrollSettings();
        var json = File.ReadAllText(SettingsFileName);
        var settingsObject = JObject.Parse(json) ?? JObject.FromObject(new RotbarschReqnrollSettings());
        _loadedSettingsFiles.Add(SettingsFileName);

        if (settingsObject.TryGetValue("additionalConfigurationFiles", out var additionalConfigurationFilesToken))
        {
            foreach (var additionalContentFile in additionalConfigurationFilesToken.Values<string>())
            {
                TryMergeIntoSettingsObject(ref settingsObject, additionalContentFile);
            }
        }

        return settingsObject.ToObject<RotbarschReqnrollSettings>() ?? new RotbarschReqnrollSettings();
    }

    private void TryMergeIntoSettingsObject(ref JObject settingsObject, string? additionalContentFile)
    {
        if (string.IsNullOrEmpty(additionalContentFile) || !File.Exists(additionalContentFile))
        {
            return;
        }

        var subJson = File.ReadAllText(additionalContentFile);
        var subObject = JObject.Parse(subJson);

        if (subObject.TryGetValue("additionalConfigurationFiles", out var additionalConfigurationFilesToken))
        {
            foreach (var subAdditionalContentFile in additionalConfigurationFilesToken.Values<string>())
            {
                TryMergeIntoSettingsObject(ref subObject, subAdditionalContentFile);
            }
        }

        settingsObject.Merge(subObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
        _loadedSettingsFiles.Add(additionalContentFile);
    }
}