using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PartsTrader.ClientTools.API.Model;

namespace PartsTrader.ClientTools.API.Service
{
    public interface IPartsService
    {
        List<PartSummaryDTO> GetPartsByPartNo(string partNo);
        PartDetailsDTO GetPartDetailsByPartNo(string partNo);


    }
}
