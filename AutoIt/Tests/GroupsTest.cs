using UITests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Helpers;

namespace UITests.Tests
{
    public class GroupsTest : BaseTest
    {
        [Test]
        public void GroupCreate()
        {
            var group = GroupData.GetRandom();
            appManager.ContactsController.PressNew()
                      .GroupsController.AddGroup(group)
                      .GroupsController.GetGroups(out var groups);
            Assert.IsTrue(groups.Contains(group));
        }

        [Test]
        public void GroupRemove()
        {
            appManager.ContactsController.PressNew()
                      .GroupsController.GetGroups(out var groups);
            GroupData group;
            if (groups.Count() == 0)
            {
                group = GroupData.GetRandom();
                appManager.GroupsController.AddGroup(group);
            }
            else
            {
                group = groups.Random();
            }
            appManager.GroupsController.RemoveGroup(group)
                      .GroupsController.GetGroups(out groups);
            Assert.IsFalse(groups.Contains(group));
        }
    }
}
