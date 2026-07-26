using Rotbarsch.Reqnroll.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace Rotbarsch.Reqnroll.Bindings.Actions;

/// <summary>
/// Step bindings for pausing test execution.
/// </summary>
[Binding]
public class WaitBindings(IWaitDriver waitDriver)
{
    /// <summary>
    /// When step: Pauses test execution for the specified number of seconds.
    /// </summary>
    /// <param name="secondsToWaitAsString">Amount of seconds to wait.</param>
    [When("test execution is paused for '(.*)' seconds")]
    public void Wait(string secondsToWaitAsString)
    {
        if(!double.TryParse(secondsToWaitAsString,out var secondsToWait)) Assert.Fail($"{secondsToWaitAsString} is no valid double.");
        waitDriver.Wait(secondsToWait);
    }
}