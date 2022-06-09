using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.WindowItems;

namespace UITests.AppManager
{
    public class ContactsController : BaseController
    {
        private readonly string contactTitle = "Contact Editor";
        private readonly string AIdClose = "Close";
        internal ContactsController(ApplicationManager applicationManager) : base(applicationManager) { }

        public ApplicationManager GetWindow(out Window window)
        {
            window = manager.mainWindow.ModalWindow(contactTitle);
            return manager;
        }
    }
}
