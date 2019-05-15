using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartsTrader.ClientTools.API.Validators;

namespace PartsTrader.ClientTools.MSTest
{
    [TestClass]
    public class PartsValidatorTest
    {
        private PartsValidator _validator = new PartsValidator();

        [TestMethod]
        public void IsPartNumberValidTest()
        {
            var validPartNo = "1929-9as7d9a7sd";
            var invalidPartNo = "1929-";

            var result1 = _validator.IsPartNumberValid(validPartNo);
            var result2 = _validator.IsPartNumberValid(invalidPartNo);

            Assert.AreEqual(true, result1);
            Assert.AreEqual(false, result2);
        }

    }
}
