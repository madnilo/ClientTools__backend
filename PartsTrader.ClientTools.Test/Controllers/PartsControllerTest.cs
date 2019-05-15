//using System;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using PartsTrader.ClientTools.API.Controllers;
//using PartsTrader.ClientTools.API.Service;
//using PartsTrader.ClientTools.API.Validators;

//namespace PartsTrader.ClientTools.MSTest.Controllers
//{
//    [TestClass]
//    public class PartsControllerTest
//    {
//        PartsController _controller = null;
//        [TestMethod]
//        public async Task GetPartsDetailsTest()
//        {
//            var _logger = new Mock<ILogger<PartsController>>();
//            var _validator = new Mock<IPartsValidator>();
//            var _service = new Mock<IPartsService>();

//            _controller = new PartsController(_logger, _validator.Object, _service.Object);

//            _validator.Setup(x => x.IsPartNumberValid(It.IsAny<string>())).Returns(true);

//            var result = await _controller.GetCompatibleParts("1111-aaaa");

//            return Task.Run(() => );
//        }
//    }
//}
