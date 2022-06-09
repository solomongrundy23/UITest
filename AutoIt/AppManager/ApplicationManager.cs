using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace UITests.AppManager
{
    public class ApplicationManager
    {
        internal readonly string winTitle = "Free Address Book";
        internal readonly Application application;
        internal readonly Window mainWindow;
        public ApplicationManager() 
        {
            application = Application.Launch(@"C:\Tools\AppsForTesting\FreeAddressBookPortable\AddressBook.exe");
            mainWindow = application.GetWindow(winTitle);
        }

        public void StopManager() 
        {
            application.Close();
            application.Dispose();
        }

        private GroupsController groupsController;
        public GroupsController GroupsController
        {
            get
            {
                if (groupsController == null) groupsController = new GroupsController(this);
                return groupsController;
            }
        }

        private ContactsController contactsController;
        public ContactsController ContactsController
        {
            get
            {
                if (contactsController == null) contactsController = new ContactsController(this);
                return contactsController;
            }
        }

        private MainWindowController mainWindowController;
        public MainWindowController MainWindowController
        {
            get
            {
                if (mainWindowController == null) mainWindowController = new MainWindowController(this);
                return mainWindowController;
            }
        }
    }
}
