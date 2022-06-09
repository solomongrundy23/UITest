using NUnit.Framework;

namespace UITests.Tests
{
    public class BaseTest
    {
        public AppManager.ApplicationManager appManager;

        [TestFixtureSetUp]
        public void InitTest()
        { 
            appManager = new AppManager.ApplicationManager();
        }

        [TestFixtureTearDown]
        public void CloseTest()
        { 
            appManager.StopManager();
        }
    }
}
