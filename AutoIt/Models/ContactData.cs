using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace UITests.Models
{
    public class ContactData : IEquatable<ContactData>
    {
        public void Fill(Window contactWindow)
        {
            Fill(contactWindow, "ueFirstNameAddressTextBox", FirstName);
            Fill(contactWindow, "ueLastNameAddressTextBox", LastName);
            contactWindow.Get<CheckBox>("uxIsCompanyGasCheckBox").Checked = true;
            Fill(contactWindow, "ueCompanyAddressTextBox", Company);
            Fill(contactWindow, "ueCityAddressTextBox", City);
            Fill(contactWindow, "ueAddressAddressTextBox", Address);
        }

        public override string ToString()
        {
            return $"FirstName={FirstName}\r\nLastName={LastName}\r\nCompany={Company}\r\nCity={City}\r\nAddress={Address}";
        }

        private void Fill(Window contactWindow, string aid, string text)
        { 
            if (text != null) contactWindow.Get<TextBox>(aid).Enter(text);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public static ContactData GetRandom()
        {
            var faker = new Faker("en");
            return new ContactData() {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Company = faker.Company.CompanyName(),
                City = faker.Address.City(),
                Address = faker.Address.FullAddress()
            };
        }

        public bool Equals(ContactData other)
        {
            return
                FirstName == other.FirstName &&
                LastName == other.LastName &&
                Company == other.Company &&
                City == other.City &&
                Address == other.Address;
        }
    }
}
