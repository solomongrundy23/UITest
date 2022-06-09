using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;

namespace UITests.AppManager
{
    public class MainWindowController : BaseController
    {
        internal MainWindowController(ApplicationManager applicationManager) : base(applicationManager) { }

        public ApplicationManager PressNew()
        {
            manager.mainWindow.Get<Button>("uxNewAddressButton").Click();
            return manager;
        }

        public ApplicationManager PressClose()
        {
            manager.mainWindow.Get<Button>("uxExitAddressButton").Click();
            return manager;
        }
    }
}
