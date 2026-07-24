namespace Rotbarsch.Reqnroll.Core.Contracts.Settings;

public record RotbarschReqnrollSettings
{
    public List<string> AdditionalConfigurationFiles { get; init; } = [];

    public List<SettingsVariable> GlobalVariables { get; init; } = [];

    public List<FileRedirect> FileRedirects { get; init; } = [];

    public RotbarschReqnrollLoggingSettings Logging { get; init; } = new();
}