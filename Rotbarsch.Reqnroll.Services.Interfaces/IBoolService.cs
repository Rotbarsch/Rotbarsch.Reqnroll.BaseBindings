namespace Rotbarsch.Reqnroll.Services.Interfaces;

public interface IBoolService
{
    void AreBooleanEqual(bool expected, string? actual);
    bool ParseBool(string? boolString, out bool parsed);
}