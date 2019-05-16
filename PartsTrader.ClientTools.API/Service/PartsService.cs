using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using PartsTrader.ClientTools.API.Domain;
using PartsTrader.ClientTools.API.Model.DTO;
using PartsTrader.ClientTools.API.Repository;
using PartsTrader.ClientTools.API.Service;

namespace PartsTrader.ClientTools.API
{
    public class PartsService : IPartsService
    {
        private readonly IPartsRepository _repo;
        private readonly IMapper _mapper;

        public PartsService(IPartsRepository repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<PartDetailsDTO> GetPartDetailsByPartNo(string partNo)
        {
            var details = await _repo.GetPartDetailsByPartNo(partNo);
            var result = _mapper.Map<PartDetailsDTO>(details);
            return result;
        }

        public async Task<List<PartSummaryDTO>> GetCompatiblePartsByPartNo(string partNo)
        {
            //check exclusions list
            var exclusions = await _repo.GetExcludedParts();
            if(exclusions.FindAll(item => item.PartNo == partNo).Count > 0)
            {
                //if item is excluded return empty array
                return new List<PartSummaryDTO>();
            }

            return _mapper.Map<List<PartSummaryDTO>>(await _repo.GetCompatiblePartsByPartNo(partNo));
        }

    }
}