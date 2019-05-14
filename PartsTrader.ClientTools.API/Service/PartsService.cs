using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using PartsTrader.ClientTools.API.Model;
using PartsTrader.ClientTools.API.Repository;
using PartsTrader.ClientTools.API.Service;

namespace PartsTrader.ClientTools.API
{
    public class PartsService : IPartsService
    {
        private readonly IPartsRepository _repo;
        public PartsService(IPartsRepository repo)
        {
            _repo = repo;
        }

        public PartDetailsDTO GetPartDetailsByPartNo(string partNo)
        {
            throw new System.NotImplementedException();
        }

        public List<PartSummaryDTO> GetPartsByPartNo(string partNo)
        {
            //check exclusions list
            var exclusions = _repo.GetExcludedParts();
            if(exclusions.FindAll(item => item.PartNo == partNo).Count > 0)
            {
                //if item is excluded return empty array
                return new List<PartSummaryDTO>();
            }

            //TODO otherwise call repo to fund equivalents
            throw new System.NotImplementedException();
        }

    }
}