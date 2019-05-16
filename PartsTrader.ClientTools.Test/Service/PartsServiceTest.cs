using System;
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
            var details = new PartDetails() { PartNumber = "1111-ASDF" };
            var detailsDTO  = new PartDetailsDTO() { PartNumber = "1111-ASDF" };

            var mockRepository = new Mock<IPartsRepository>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(x => x.GetPartDetailsByPartNo(It.IsAny<string>()))
                .ReturnsAsync(details);
            mockMapper.Setup(x => x.Map<PartDetailsDTO>(It.IsAny<PartDetails>()))
                .Returns(detailsDTO);

            var _subject = new PartsService(mockRepository.Object, mockMapper.Object);
            var result = await _subject.GetPartDetailsByPartNo(details.PartNumber);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetCompatiblePartsByPartNoTests()
        {
            var exclusions = new List<PartSummary>(){ new PartSummary() { PartNo = "0987-kajsh" }};
            var summary = new List<PartSummary>(){ new PartSummary() { PartNo = "1234-QWOUE" }};
            var summaryDTO = new List<PartSummaryDTO>(){ new PartSummaryDTO() { PartNo = "1234-QWOUE" }};

            var mockRepository = new Mock<IPartsRepository>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(x => x.GetExcludedParts())
                .ReturnsAsync(exclusions);
            mockRepository.Setup(x => x.GetCompatiblePartsByPartNo(It.IsAny<string>()))
                .ReturnsAsync(summary);
            mockMapper.Setup(x => x.Map<List<PartSummaryDTO>>(It.IsAny<List<PartSummary>>()))
                .Returns(summaryDTO);

            var _subject = new PartsService(mockRepository.Object, mockMapper.Object);
            var result = await _subject.GetCompatiblePartsByPartNo("1234-pqowie");

            Assert.IsNotNull(result);
        }
    }
}


