using Rotbarsch.Reqnroll.Bindings.Interfaces.Actions;
using Rotbarsch.Reqnroll.Drivers.Interfaces;
using Reqnroll;

namespace Rotbarsch.Reqnroll.Bindings.Actions;

/// <summary>
/// Step bindings for actions on collection variables (e.g., lists of items).
/// </summary>
/// <param name="collectionVariableDriver">Driver component used for interactions with collections.</param>
[Binding]
public class CollectionVariableBindings(ICollectionVariableDriver collectionVariableDriver) : ICollectionVariableBindings
{
    /// <summary>
    /// Gets the length of the collection stored in the specified variable and stores it in another variable.
    /// </summary>
    /// <param name="collectionVariableName">Name of the variable holding the collection.</param>
    /// <param name="targetVariableName">Name of the variable receiving the value.</param>
    [When("the length of collection variable '(.*)' is stored in variable '(.*)'")]
    public void StoreCollectionLengthInVariable(string collectionVariableName, string targetVariableName)
    {
        collectionVariableDriver.StoreCollectionLengthInVariable(collectionVariableName, targetVariableName);
    }
}