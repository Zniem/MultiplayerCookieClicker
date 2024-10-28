using CookieServer;

namespace ServerUnitTest {
    [TestClass]
    public class ProgressionTests {

        public ProgressionData SetupProgressionAtZero() {
            return new ProgressionData(0, 0, 0, 0, 0, 0, 0);
        }
        public ProgressionData SetupProgressionAtOne() {
            return new ProgressionData(1, 1, 1, 1, 1, 1, 1);
        }

        public ProgressionData SetupProgressionAtOneHundred() {
            return new ProgressionData(100, 100, 100, 100, 100, 100, 100);
        }

        //price tests at zero

        [TestMethod]
        public void TestCpsZeroBuildings() {
            ProgressionData data = SetupProgressionAtZero();
            Assert.AreEqual(0, data.Cps);
        }

        [TestMethod]
        public void FingerPriceZeroFingersTest() {
            ProgressionData data = SetupProgressionAtZero();
            Assert.AreEqual(15, data.FingerPrice);
        }

        [TestMethod]
        public void GrandmaPriceZeroGrandmasTest() {
            ProgressionData data = SetupProgressionAtZero();
            Assert.AreEqual(100, data.GrandmaPrice);
        }

        [TestMethod]
        public void FarmPriceZeroFarmsTest() {
            ProgressionData data = SetupProgressionAtZero();
            Assert.AreEqual(1100, data.FarmPrice);
        }

        [TestMethod]
        public void MinePriceZeroMinesTest() {
            ProgressionData data = SetupProgressionAtZero();
            Assert.AreEqual(12000, data.MinePrice);
        }

        [TestMethod]
        public void FactoryPriceZeroFactoriesTest() {
            ProgressionData data = SetupProgressionAtZero();
            Assert.AreEqual(130000, data.FactoryPrice);
        }


        [TestMethod]
        public void BankPriceZeroBanksTest() {
            ProgressionData data = SetupProgressionAtZero();
            Assert.AreEqual(1400000, data.BankPrice);
        }

        //price tests at one
        [TestMethod]
        public void TestCpsOneOfAllBuildings() {
            ProgressionData data = SetupProgressionAtOne();
            Assert.AreEqual(1716, data.Cps);
        }

        [TestMethod]
        public void FingerPriceOneFingerTest() {
            ProgressionData data = SetupProgressionAtOne();
            Assert.AreEqual(18, data.FingerPrice);
        }

        [TestMethod]
        public void GrandmaPriceOneGrandmaTest() {
            ProgressionData data = SetupProgressionAtOne();
            Assert.AreEqual(115, data.GrandmaPrice);
        }

        [TestMethod]
        public void FarmPriceOneFarmTest() {
            ProgressionData data = SetupProgressionAtOne();
            Assert.AreEqual(1265, data.FarmPrice);
        }

        [TestMethod]
        public void MinePriceOneMineTest() {
            ProgressionData data = SetupProgressionAtOne();
            Assert.AreEqual(13800, data.MinePrice);
        }

        [TestMethod]
        public void FactoryPriceOneFactoryTest() {
            ProgressionData data = SetupProgressionAtOne();
            Assert.AreEqual(149500, data.FactoryPrice);
        }


        [TestMethod]
        public void BankPriceOneBankTest() {
            ProgressionData data = SetupProgressionAtOne();
            Assert.AreEqual(1610000, data.BankPrice);
        }

        //price tests at one hundred
        [TestMethod]
        public void TestCpsOneHundredOfAllBuildings() {
            ProgressionData data = SetupProgressionAtOneHundred();
            Assert.AreEqual(171610, data.Cps);
        }

        [TestMethod]
        public void FingerPriceOneHundredFingersTest() {
            ProgressionData data = SetupProgressionAtOneHundred();
            Assert.AreEqual(17614702, data.FingerPrice);
        }

        [TestMethod]
        public void GrandmaPriceOneHundredGrandmasTest() {
            ProgressionData data = SetupProgressionAtOneHundred();
            Assert.AreEqual(117431346, data.GrandmaPrice);
        }

        [TestMethod]
        public void FarmPriceOneHundredFarmsTest() {
            ProgressionData data = SetupProgressionAtOneHundred();
            Assert.AreEqual(1291744796, data.FarmPrice);
        }

        [TestMethod]
        public void MinePriceOneHundredMinesTest() {
            ProgressionData data = SetupProgressionAtOneHundred();
            Assert.AreEqual(14091761409, data.MinePrice);
        }

        [TestMethod]
        public void FactoryPriceOneHundredFactoriesTest() {
            ProgressionData data = SetupProgressionAtOneHundred();
            Assert.AreEqual(152660748592, data.FactoryPrice);
        }


        [TestMethod]
        public void BankPriceOneHundredBanksTest() {
            ProgressionData data = SetupProgressionAtOneHundred();
            Assert.AreEqual(1644038830981, data.BankPrice);
        }
    }
}