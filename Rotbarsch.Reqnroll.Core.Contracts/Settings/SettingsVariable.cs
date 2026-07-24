namespace Rotbarsch.Reqnroll.Core.Contracts.Settings;

public record SettingsVariable
{
    public required string Name { get; set; }
    public string? Value { get; set; }
}