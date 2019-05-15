using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PartsTrader.ClientTools.API.Domain;

namespace PartsTrader.ClientTools.API.Repository
{
    public interface IPartsRepository
    {
        Task<List<PartSummary>> GetExcludedParts();
        Task<List<PartSummary>> GetCompatiblePartsByPartNo(string partNo);
        Task<PartDetails> GetPartDetailsByPartNo(string partNo);
    }
}
