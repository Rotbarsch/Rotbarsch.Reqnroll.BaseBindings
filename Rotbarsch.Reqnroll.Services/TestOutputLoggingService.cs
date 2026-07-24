using System.Text.RegularExpressions;
using Rotbarsch.Reqnroll.Services.Interfaces;
using Reqnroll;

namespace Rotbarsch.Reqnroll.Services;

/// <summary>
///     Service that writes log messages to the test output helper.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="TestOutputLoggingService" /> class.
/// </remarks>
/// <param name="outputHelper">The Reqnroll output helper to write logs to.</param>
public partial class TestOutputLoggingService(IReqnrollOutputHelper outputHelper) : ITestOutputLoggingService
{
    /// <inheritdoc />
    public void WriteLine(string logMessage)
    {
        outputHelper.WriteLine("[Rotbarsch.Reqnroll]" + logMessage);
    }

    public void WriteLine(string logMessage, params object[] messageParameters)
    {
        int i = 0;
        var numeric = VariableRegEx().Replace(logMessage, _ => $"{{{i++}}}");
        var result = string.Format(numeric, [.. messageParameters]);

        WriteLine(result);
    }

    [GeneratedRegex(@"{[^}]+}")]
    private static partial Regex VariableRegEx();
}