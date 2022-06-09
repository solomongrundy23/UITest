using UITests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;

namespace UITests.AppManager
{
    public class GroupsController : BaseController
    {
        private string groupsTitle = "Group editor";
        private string deleteGroupTitle = "Delete group";
        private string AIdGroupButton = "groupButton";
        private string AIdCloseButton = "uxCloseAddressButton";
        private string AIdNewButton = "uxNewAddressButton";
        private string AIdDeleteButton = "uxDeleteAddressButton";
        private string AIdTree = "uxAddressTreeView";
        private string AIdSelectorDeleteAll = "uxDeleteAllRadioButton";
        private string AIdDeleteOk = "uxOKAddressButton";
        internal GroupsController(ApplicationManager applicationManager) : base(applicationManager) { }

        public ApplicationManager AddGroup(GroupData groupData)
        {
            var dialog = OpenGroupsDialog();
            manager.mainWindow.Get<Button>(AIdNewButton).Click();
            var textBox = (TextBox) dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(groupData.Name);
            Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dialog);
            return manager;
        }

        public ApplicationManager GetGroups(out List<GroupData> groups)
        {
            var dialog = OpenGroupsDialog();
            var tree = dialog.Get<Tree>(AIdTree);
            var rootNode = tree.Nodes[0];
            groups = rootNode.Nodes.Select(x => new GroupData(x.Text)).ToList();
            CloseGroupsDialog(dialog);
            return manager;
        }

        public Window OpenGroupsDialog()
        {
            manager.ContactsController.GetWindow(out var contactWindow);
            contactWindow.Get<Button>(AIdGroupButton).Click();
            return contactWindow.ModalWindow(groupsTitle);
        }

        public void CloseGroupsDialog(Window groupDialog)
        {
            groupDialog.Get<Button>(AIdCloseButton).Click();            
        }

        public ApplicationManager RemoveGroup(GroupData groupData)
        {
            var dialog = OpenGroupsDialog();
            var tree = dialog.Get<Tree>(AIdTree);
            var rootNode = tree.Nodes[0];
            rootNode.Nodes.Where(x => x.Text == groupData.Name).FirstOrDefault().Click();
            dialog.Get<Button>(AIdDeleteButton).Click();
            var deleteDialog = dialog.ModalWindow(deleteGroupTitle);
            deleteDialog.Get<RadioButton>(AIdSelectorDeleteAll).Click();
            dialog.Get<Button>(AIdDeleteOk).Click();
            CloseGroupsDialog(dialog);
            return manager;
        }
    }
}