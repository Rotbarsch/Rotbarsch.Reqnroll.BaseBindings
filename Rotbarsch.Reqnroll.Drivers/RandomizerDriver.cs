using Rotbarsch.Reqnroll.Core.Contracts;
using Rotbarsch.Reqnroll.Drivers.Interfaces;
using Rotbarsch.Reqnroll.Services.Interfaces;

namespace Rotbarsch.Reqnroll.Drivers;

public class RandomizerDriver(IVariableService variableService, IRandomDataService randomDataService, ICultureInfoService cultureInfoService)
    : IRandomizerDriver
{
    public void SetRandomNumberInRange(int minValue, int maxValue, string variableName)
    {
        variableService.SetVariable(variableName, randomDataService.GetIntegerInRange(minValue, maxValue).ToString());
    }

    public void SetRandomDoubleInRange(double minValue, double maxValue, string variableName)
    {
        var randomDouble = randomDataService.GetDoubleInRange(minValue, maxValue)
            .ToString(cultureInfoService.GetConfiguredCultureInfo());
        variableService.SetVariable(variableName, randomDouble);
    }

    public void SetRandomString(FakerStringType stringType, string variableName)
    {
        var randomString = randomDataService.GetRandomString(stringType);

        variableService.SetVariable(variableName, randomString);
    }
}