namespace Rotbarsch.Reqnroll.Core.Contracts.Settings;

public record RotbarschReqnrollLoggingSettings
{
    public bool FormatJson { get; init; } = true;
    public bool FormatXml { get; init; } = true;
    public int? MaxLoggedContentLength { get; init; } = null;
}