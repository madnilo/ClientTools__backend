using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PartsTrader.ClientTools.API.Domain;
using PartsTrader.ClientTools.API.Repository;

namespace PartsTrader.ClientTools.API
{
    public class PartsRepository : IPartsRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<PartsRepository> _logger;

        public PartsRepository(IHostingEnvironment hostingEnvironment,
            ILogger<PartsRepository> logger
            )
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }


        public async Task<List<PartSummary>> GetCompatiblePartsByPartNo(string partNo)
        {
            try
            {
                var results = await this.FakeCallToExternalProviderPartsTraderService("/Results.json");
                var converted = JsonConvert.DeserializeObject<List<PartSummary>>(results);
                return converted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<PartSummary>();
            }
        }

        public async Task<PartDetails> GetPartDetailsByPartNo(string partNo)
        {
            try
            {
                var results = await this.FakeCallToExternalProviderPartsTraderService("/PartDetails.json");
                return JsonConvert.DeserializeObject<PartDetails>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new PartDetails();
            }
        }

        public async Task<List<PartSummary>> GetExcludedParts()
        {

            var results = await this.FakeCallToExternalProviderPartsTraderService("/Exclusions.json");
            return JsonConvert.DeserializeObject<List<PartSummary>>(results);
        }

        /// <summary>
        /// Mocks the call to external provider parts trader service.
        /// </summary>
        /// <returns>The call to external provider parts trader service.</returns>
        /// <param name="path">Path of the json file</param>
        private async Task<string> FakeCallToExternalProviderPartsTraderService(string path)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var results = await Task.Run(() => System.IO.File.ReadAllText(contentRootPath + path));
            return results;
        }
    }
}