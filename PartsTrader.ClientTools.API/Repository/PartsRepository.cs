using System.Collections.Generic;
using PartsTrader.ClientTools.API.Entities;
using PartsTrader.ClientTools.API.Repository;

namespace PartsTrader.ClientTools.API
{
    class PartsRepository : IPartsRepository
    {
        public List<PartSummary> GetEquivalentPartsByPartNo()
        {
            throw new System.NotImplementedException();
        }

        public List<PartSummary> GetExcludedParts()
        {
            return new List<PartSummary>(){
                new PartSummary() { PartNo = "1111-Invoice", Description = "Invoice line" },
                new PartSummary() { PartNo = "1234-abcd", Description = "Test Part Number" },
                new PartSummary() { PartNo = "9999-charge", Description =  "Stealth charge added for rude customers" }
            };
        }

        public PartDetails GetPartDetailsByPartNo()
        {
            throw new System.NotImplementedException();
        }
    }
}