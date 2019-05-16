using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PartsTrader.ClientTools.API.Controllers;
using PartsTrader.ClientTools.API.Model.DTO;
using PartsTrader.ClientTools.API.Service;
using PartsTrader.ClientTools.API.Validators;

namespace PartsTrader.ClientTools.MSTest.Controllers
{
    [TestClass]
    public class PartsControllerTest
    {
        [TestMethod]
        public async Task GetPartsDetailsTest()
        {
            var partNumber = "1111-aaaa";
            var _logger = new Mock<ILogger<PartsController>>();
            var _validator = new Mock<IPartsValidator>();
            var _service = new Mock<IPartsService>();

            _validator.Setup(x => x.IsPartNumberValid(It.IsAny<string>())).Returns(true);
            _service.SetReturnsDefault<PartDetailsDTO>(new PartDetailsDTO(){ PartNumber = partNumber });

            var _controller = new PartsController(_logger.Object, _validator.Object, _service.Object);

            var result = await _controller.GetPartDetails(partNumber);

            Assert.IsInstanceOfType(result, typeof(ActionResult<PartDetailsDTO>));
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsNotNull(_service.Invocations);
        }

        [TestMethod]
        public async Task GetCompatibleParts()
        {
            var partNumber = "1111-aaaa";
            var _logger = new Mock<ILogger<PartsController>>();
            var _validator = new Mock<IPartsValidator>();
            var _service = new Mock<IPartsService>();

            _validator.Setup(x => x.IsPartNumberValid(It.IsAny<string>())).Returns(true);
            _service.SetReturnsDefault<List<PartSummaryDTO>>(new List<PartSummaryDTO>(){ new PartSummaryDTO() { PartNo = partNumber } });

            var _controller = new PartsController(_logger.Object, _validator.Object, _service.Object);

            var result = await _controller.GetCompatibleParts(partNumber);

            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<PartSummaryDTO>>));
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsNotNull(_service.Invocations);
        }
    }
}
