using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PartsTrader.ClientTools.API;
using PartsTrader.ClientTools.API.Domain;
using PartsTrader.ClientTools.API.Model.DTO;
using PartsTrader.ClientTools.API.Repository;

namespace PartsTrader.ClientTools.MSTest
{
    [TestClass]
    public class PartsServiceTest
    {

        [TestMethod]
        public async Task GetPartDetailsByPartNoTests()
        {
            var partNo = "1111-apsodi";
            var mockRepository = new Mock<IPartsRepository>();
            var _subject = new PartsService(mockRepository.Object);

            mockRepository.Setup(x => x.GetPartDetailsByPartNo(partNo))
                .Returns(Task.Run(() => new PartDetails(){ Title = "Bla" }));

            var result = await _subject.GetPartDetailsByPartNo(partNo);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetCompatiblePartsByPartNoTests()
        {
            var partNo = "1111-apsodi";
            var mockRepository = new Mock<IPartsRepository>();
            var _subject = new PartsService(mockRepository.Object);


            mockRepository.Setup(x => x.GetCompatiblePartsByPartNo(partNo))
                .Returns(Task.Run(() => new List<PartSummary>(){
                    new PartSummary(){
                        Title = "Bla"
                    }
                }));

            mockRepository.Setup(x => x.GetExcludedParts())
                .Returns(Task.Run(() => new List<PartSummary>()));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<PartSummary, PartSummaryDTO>(It.IsAny<PartSummary>()))
                .Returns( new PartSummaryDTO() { Title = "Bla" }); 

            var result = await _subject.GetCompatiblePartsByPartNo(partNo);

            Assert.IsNotNull(result);
        }


    }
}


