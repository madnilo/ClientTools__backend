using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartsTrader.ClientTools.Api;
using PartsTrader.ClientTools.API.Service;
using PartsTrader.ClientTools.API.Validators;

namespace PartsTrader.ClientTools.API.Controllers
{
    [Route("api/parts")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly ILogger<PartsController> _logger;
        private readonly IPartsValidator _validator;
        private readonly IPartsService _service;

        public PartsController(ILogger<PartsController> logger,
        IPartsValidator validator,
        IPartsService service)
        {
            _logger = logger;
            _validator = validator;
            _service = service;
        }


        /// <summary>
        /// Get equivalent parts by a given PartNo.
        /// </summary>
        /// <returns>PartSearchResultsDTO</returns>
        // GET api/parts/:partNo
        [HttpGet("partNo")]
        public ActionResult<IEnumerable<string>> GetByPartNo(string partNo)
        {
            try
            {
                if (!_validator.IsPartNumberValid(partNo))
                {
                    throw new InvalidPartException(partNo);
                }
            }
            catch (InvalidPartException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(Messages.PARTS__INVALID_NUMBER);
            }

            var results = _service.GetPartsByPartNo(partNo);


            //TODO repository should call the external service

            //TODO return data to service

            //TODO service call the adapter to translate entity to DTO

            //TODO service return data to the controller

            //TODO controller returns OK(data)

            Console.WriteLine(partNo);
            _logger.LogInformation($"New request for parts at {DateTime.Now}");
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get a part with full details by partNo.
        /// </summary>
        /// <returns>PartWithEquivalentsDTO</returns>
        // GET api/parts/:ID
        [HttpGet("{partNo}/details")]
        public ActionResult<IEnumerable<string>> GetPartDetails(int partNo)
        {
            throw new NotImplementedException();
        }

    }
}
