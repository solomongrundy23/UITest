using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Models;
using UITests.Helpers;

namespace UITests.Tests
{
    public class ContactsTest : BaseTest
    {
        [Test]
        public void AddContact()
        {
            var contact = ContactData.GetRandom();
            appManager.ContactsController.AddContact(contact)
                      .ContactsController.GetAllContacts(out var contacts);
            Assert.IsTrue(contacts.Contains(contact));  
        }

        [Test]
        public void RemoveContact()
        {
            appManager.ContactsController.GetAllContacts(out var contacts);
            var contact = contacts.Random();
            appManager.ContactsController.SelectContact(contact)
                      .ContactsController.PressDelete()
                      .ContactsController.Question(true)
                      .ContactsController.GetAllContacts(out contacts);
            Assert.IsFalse(contacts.Contains(contact));
        }
    }
}
