using UITests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TreeItems;
using System.Threading;
using TestStack.White.UIItems.Finders;

namespace UITests.AppManager
{
    public class ContactsController : BaseController
    {
        private readonly string contactTitle = "Contact Editor";
        private readonly string questionTitle = "Question";
        private readonly string AIdClose = "Close";
        private readonly string AIdSave = "uxSaveAddressButton";
        private readonly string AIdExit = "uxExitAddressButton";
        private readonly string AIdNew = "uxNewAddressButton";
        private readonly string AIdDelete = "uxDeleteAddressButton";
        private readonly string AIdGroupFilter = "uxGroupComboTreeView";
        private readonly string AIdContactsGrid = "uxAddressGrid";
        private readonly string questionDialogButtonsClass = "WindowsForms10.BUTTON.app.0.2c908d5";

        internal ContactsController(ApplicationManager applicationManager) : base(applicationManager) { }

        public ApplicationManager PressNew()
        {
            manager.mainWindow.Get<Button>(AIdNew).Click();
            return manager;
        }

        public ApplicationManager PressClose()
        {
            manager.mainWindow.Get<Button>(AIdExit).Click();
            return manager;
        }

        public ApplicationManager PressDelete()
        {
            manager.mainWindow.Get<Button>(AIdDelete).Click();
            return manager;
        }

        public ApplicationManager GetWindow(out Window window)
        {
            window = manager.mainWindow.ModalWindow(contactTitle);
            return manager;
        }

        public ApplicationManager AddContact(ContactData contactData)
        {
            PressNew();
            GetWindow(out var dialog);
            contactData.Fill(dialog);
            dialog.Get<Button>(AIdSave).Click();
            return manager;
        }

        public ApplicationManager GetAllContacts(out List<ContactData> contacts)
        {
            var grid = manager.mainWindow.Get<Table>();
            Thread.Sleep(3000);
            contacts = new List<ContactData>();
            foreach (var row in grid.Rows)
            {
                contacts.Add(new ContactData() {
                    FirstName = row.Cells[0].Value?.ToString(),
                    LastName = row.Cells[1].Value?.ToString(),
                    Company = row.Cells[2].Value?.ToString(),
                    City = row.Cells[3].Value?.ToString(),
                    Address = row.Cells[4].Value?.ToString(),
                });
            }
            return manager;
        }

        public ApplicationManager Question(bool accept)
        {
            var dialog = manager.mainWindow.ModalWindow(questionTitle);
            if (accept)
            {
                dialog.Get(SearchCriteria.ByText("Yes")).Click();
            }
            else
            {
                dialog.Get(SearchCriteria.ByText("No")).Click();
            }
            return manager;
        }

        public ApplicationManager SelectContact(ContactData contactData)
        {
            var contactRow = GetContactRow(contactData);
            contactRow.Click();
            return manager;
        }

        private TableRow GetContactRow(ContactData contactData)
        {
            var grid = manager.mainWindow.Get<Table>(AIdContactsGrid);
            Thread.Sleep(3000);
            foreach (var row in grid.Rows)
            {
                var contact = new ContactData()
                {
                    FirstName = row.Cells[0].Value?.ToString(),
                    LastName = row.Cells[1].Value?.ToString(),
                    Company = row.Cells[2].Value?.ToString(),
                    City = row.Cells[3].Value?.ToString(),
                    Address = row.Cells[4].Value?.ToString(),
                };
                if (contact.Equals(contactData)) return row;
            }
            throw new Exception("I can't find contact row");
        }
    }
}
