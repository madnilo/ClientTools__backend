using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartsTrader.ClientTools.Api;
using PartsTrader.ClientTools.API.Domain;
using PartsTrader.ClientTools.API.Model.DTO;
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
        /// <returns>List of PartSummaryDTO</returns>
        // GET api/parts/:partNo.compatible
        [HttpGet("{partNo}/compatible")]
        public async Task<ActionResult<IEnumerable<PartSummaryDTO>>> GetCompatibleParts(string partNo)
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

            var results = await _service.GetCompatiblePartsByPartNo(partNo);

            return Ok(results);
        }

        /// <summary>
        /// Get a part with full details by partNo.
        /// </summary>
        /// <returns>PartDetailsDTO</returns>
        // GET api/parts/:partNo/details
        [HttpGet("{partNo}/details")]
        public async Task<ActionResult<PartDetailsDTO>> GetPartDetails(string partNo)
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

            var result = await _service.GetPartDetailsByPartNo(partNo);

            return Ok(result);
        }

    }
}
