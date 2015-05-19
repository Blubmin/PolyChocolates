using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyChocolates
{
    public partial class ChocolateSetupControl : UserControl
    {
        Home home;
        databaseDataContext db = new databaseDataContext();

        public ChocolateSetupControl(Home home)
        {
            InitializeComponent();
            this.home = home;
            setupHandlers();
        }

        public ChocolateSetupControl(Checklist checklist)
        {
            InitializeComponent();

            List<Control> removeList = new List<Control>();

            foreach (Control c in Table.Controls)
            {
                if (c is TextBox)
                {
                    removeList.Add(c);
                }
            }

            foreach(Control c in removeList)
            {
                Table.Controls.Remove(c);
            }

            Library.setupCheckListTable(Table, checklist.Initials, checklist.Complete);
            notesTextBox.Text = checklist.Notes;
            lotCodeTextField.Text = checklist.CodeDate;
        }

        private void setupHandlers()
        {
            foreach (Control c in this.Controls)
            {
                c.TextChanged += new EventHandler(this.submitButtonEnableCheck);
            }
            foreach (Control c in Table.Controls)
            {
                if (c is TextBox)
                {
                    c.TextChanged += new EventHandler(this.submitButtonEnableCheck);
                    c.Leave += new EventHandler(Library.onlyAllowAlphabetics);
                }
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }
            }
        }


        private void submitButtonEnableCheck(Object o, EventArgs a)
        {
            submitChocolateSetupButton.Enabled = true;

            foreach (Control c in Table.Controls)
            {
                if (c.Text.Length == 0)
                    submitChocolateSetupButton.Enabled = false;
            }

            if (lotCodeTextField.Text.Length == 0)
                submitChocolateSetupButton.Enabled = false;
        }

        private void submitChocolateSetupButton_Click(object sender, EventArgs e)
        {
            Checklist checklist = new Checklist();
            checklist.Type = "chocolatesetup";
            checklist.Initials = Library.traverseTableForInitials(Table);
            checklist.Complete = Library.traverseTableForYesNoNA(Table);
            checklist.Notes = notesTextBox.Text;
            checklist.CodeDate = lotCodeTextField.Text;

            db.Checklists.InsertOnSubmit(checklist);
            db.SubmitChanges();

            DialogResult result = MessageBox.Show("Would you like to submit this checklist for Code Date: " + lotCodeTextField.Text, "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                home.refreshChecklist(this, "chocolatesetup");
                Home.changeViewToHome();
            }
        }
    }
}
