using AutoMapper;
using PartsTrader.ClientTools.API.Domain;
using PartsTrader.ClientTools.API.Model.DTO;

public class PartsProfile : Profile
{
    public PartsProfile()
    {
        CreateMap<PartSummary, PartSummaryDTO>();
        CreateMap<PartDetails, PartDetailsDTO>();
    }
}