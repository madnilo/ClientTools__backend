using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using PartsTrader.ClientTools.API.Domain;
using PartsTrader.ClientTools.Integration;

namespace PartsTrader.ClientTools.External.Services
{
    public class PartsTraderPartsService : IPartsTraderPartsService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public PartsTraderPartsService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<PartSummary> FindAllCompatiblePartsByPartNumber(string partNumber)
        {
            try
            {
                var results = this.ReadJsonDatabase("/PartDetails.json");
                var converted = JsonConvert.DeserializeObject<List<PartSummary>>(results);
                return converted;
            }
            catch (Exception)
            {
                return new List<PartSummary>();
            }
        }

        public PartDetails FindPartByPartNumber(string partNumber)
        {
            try
            {
                var results = this.ReadJsonDatabase("/PartDetails.json");
                return JsonConvert.DeserializeObject<PartDetails>(results);
            }
            catch (Exception)
            {
                return new PartDetails();
            }
        }

        private string ReadJsonDatabase(string path)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var results = System.IO.File.ReadAllText(contentRootPath + path);
            return results;
        }
    }
}
