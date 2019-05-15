using System.Collections.Generic;
using System.Threading.Tasks;
using PartsTrader.ClientTools.API.Model.DTO;

namespace PartsTrader.ClientTools.API.Service
{
    public interface IPartsService
    {
        Task<List<PartSummaryDTO>> GetCompatiblePartsByPartNo(string partNo);
        Task<PartDetailsDTO> GetPartDetailsByPartNo(string partNo);
    }
}
