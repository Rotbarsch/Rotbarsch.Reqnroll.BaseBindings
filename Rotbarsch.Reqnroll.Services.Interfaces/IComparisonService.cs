using Rotbarsch.Reqnroll.Core.Contracts;

namespace Rotbarsch.Reqnroll.Services.Interfaces;

public interface IComparisonService
{
    bool Compare(string? value, ComparisonOperation comparisonOperation, string? comparisonValue = null);
}