using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PartsTrader.ClientTools.API.Controllers
{
    [Route("api/parts")]
    [ApiController]
    public class PartsController : ControllerBase
    {

        private ILogger<PartsController> _logger;

        public PartsController(ILogger<PartsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetByPartNumber()
        {
            //TODO call validator on the part searched

            //TODO if validation is not ok throw invalid part exception

            //TODO in the pipeline, filter the exception to return 400 bad request?
            //TODO or treat the exception with try catch to return 400 bad request?

            //TODO if everything is okay, call the service layer

            //TODO the service layer should lookup on the exclusions list and return [] if the part is excluded

            //TODO if the part is not excluded, pass to repository layer

            //TODO repository should call the external service

            //TODO return data to service

            //TODO service call the adapter to translate entity to DTO

            //TODO service return data to the controller

            //TODO controller returns OK(data)

            Console.WriteLine("passed here");
            _logger.LogInformation($"New request for parts at {DateTime.Now}");
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetByTitle()
        {
            //TODO call validator on the title searched

            //TODO if validation is not ok throw invalid part exception

            //TODO in the pipeline, filter the exception to return 400 bad request?
            //TODO or treat the exception with try catch to return 400 bad request?

            //TODO if everything is okay, call the service layer

            //TODO repository should call the external service

            //TODO return data to service

            //TODO service call the adapter to translate entity to DTO

            //TODO service return data to the controller

            //TODO controller returns OK(data)

            Console.WriteLine("passed here");
            _logger.LogInformation($"New request for parts at {DateTime.Now}");
            return new string[] { "value1", "value2" };
        }

    }
}
