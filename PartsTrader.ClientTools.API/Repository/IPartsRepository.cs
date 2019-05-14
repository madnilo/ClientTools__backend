using System;
using System.Collections.Generic;
using PartsTrader.ClientTools.API.Entities;

namespace PartsTrader.ClientTools.API.Repository
{
    public interface IPartsRepository
    {
        List<PartSummary> GetExcludedParts();
        List<PartSummary> GetEquivalentPartsByPartNo();
        PartDetails GetPartDetailsByPartNo();
    }
}
