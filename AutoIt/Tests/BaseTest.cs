using NUnit.Framework;

namespace UITests.Tests
{
    public class BaseTest
    {
        public AppManager.ApplicationManager appManager;

        [SetUp]
        public void InitTest()
        { 
            appManager = new AppManager.ApplicationManager();
        }

        [TearDown]
        public void CloseTest()
        { 
            appManager.StopManager();
        }
    }
}
