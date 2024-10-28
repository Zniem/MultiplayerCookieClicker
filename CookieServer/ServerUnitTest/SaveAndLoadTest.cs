using CookieServer;

namespace ServerUnitTest {
    [TestClass]
    public class SaveAndLoadTest {
        private static String TestDirectoryPath;
        private static String TestFilePath;

        public void SetupTest() {
            TestDirectoryPath = $"{Environment.CurrentDirectory}/Test";
            TestFilePath = $"{TestDirectoryPath}/Test.txt";
            ProgressionData progressionData = new ProgressionData(0, 10, 20, 30, 40, 50, 60);



            if (!Directory.Exists(TestDirectoryPath)) {
                Directory.CreateDirectory(TestDirectoryPath);
            }
            if (!File.Exists(TestFilePath)) {
                FileStorage.SaveToFile(TestFilePath, progressionData);
            }
        }

        public void TestsCreatesSetup() {
            SetupTest();
            File.Delete(TestFilePath);
            Directory.Delete(TestDirectoryPath, false);
        }

        [TestMethod]
        public void TestsCreatesDirectory() {
            TestsCreatesSetup();
            SetupTest();
            Assert.IsTrue(Directory.Exists(TestDirectoryPath));
        }

        [TestMethod]
        public void TestsCreatesFile() {
            TestsCreatesSetup();
            SetupTest();
            Assert.IsTrue(File.Exists(TestFilePath));
        }
    }
}
