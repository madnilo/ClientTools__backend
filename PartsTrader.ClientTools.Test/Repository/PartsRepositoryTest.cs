using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PartsTrader.ClientTools.API;

namespace PartsTrader.ClientTools.MSTest.Repository
{
    [TestClass]
    public class PartsRepositoryTest
    {
        [TestMethod]
        public async Task ExclusionsListTest()
        {
            var _env = new Mock<IHostingEnvironment>();
            var _logger = new Mock<ILogger<PartsRepository>>();

            _env
                .Setup(x => x.ContentRootPath)
                .Returns(System.IO.Path.GetFullPath(@"../../../../") + "PartsTrader.ClientTools.API");

            var repo = new PartsRepository(_env.Object, _logger.Object);

            var result = await repo.GetExcludedParts();

            Assert.IsNotNull(result[0].PartNo);
        }

        [TestMethod]
        public async Task GetCompatiblePartsByPartNoTest()
        {
            var _env = new Mock<IHostingEnvironment>();
            var _logger = new Mock<ILogger<PartsRepository>>();

            _env
                .Setup(x => x.ContentRootPath)
                .Returns(System.IO.Path.GetFullPath(@"../../../../") + "PartsTrader.ClientTools.API");

            var repo = new PartsRepository(_env.Object, _logger.Object);

            var result = await repo.GetCompatiblePartsByPartNo("1231-asdasd");

            Assert.IsNotNull(result[0].PartNo);
        }

        [TestMethod]
        public async Task GetPartDetailsByPartNoTest()
        {
            var _env = new Mock<IHostingEnvironment>();
            var _logger = new Mock<ILogger<PartsRepository>>();

            _env
                .Setup(x => x.ContentRootPath)
                .Returns(System.IO.Path.GetFullPath(@"../../../../") + "PartsTrader.ClientTools.API");

            var repo = new PartsRepository(_env.Object, _logger.Object);

            var result = await repo.GetPartDetailsByPartNo("1231-asdasd");

            Assert.IsNotNull(result.Title);
        }
    }
}
