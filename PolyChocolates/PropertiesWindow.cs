

using System;
using System.Windows.Forms;

namespace PolyChocolates
{
    public partial class PropertiesWindow : Form
    {
        private Home home;


        public PropertiesWindow(Home home)
        {
            InitializeComponent();

            this.home = home;

            InvoiceHeader.Text = Home.invoiceHeader;

            PreviousPassword.PasswordChar = '*';

            PreviousPassword.MaxLength = 13;

            NewPassword.PasswordChar = '*';

            NewPassword.MaxLength = 13;

            RepeatPassword.PasswordChar = '*';

            RepeatPassword.MaxLength = 13;
        }


        private void ApplyChanges_Click(object sender, EventArgs e)
        {
            var modifyOccured = ModifyInvoiceHeader();

            var passwordChangeOccured = CheckPasswordChange();

            if (modifyOccured || passwordChangeOccured)
            {
                Home.overwritePreferencesFile();

                Dispose();
            }
        }


        private bool ModifyInvoiceHeader()
        {
            if (InvoiceHeader.Text.Contains("-") || InvoiceHeader.Text.Contains(":"))
            {
                MessageBox.Show("Cannot use a ':' or '-' in this header.");

                return false;
            }

            if (InvoiceHeader.TextLength > 0 && InvoiceHeader.Text != Home.invoiceHeader)
            {
                Home.invoiceHeader = InvoiceHeader.Text;
                Home.invoiceControl.label12.Text = Home.invoiceHeader;
                return true;
            }

            return false;
        }


        private bool CheckPasswordChange()
        {
            if (!(PreviousPassword.Text.Length == 0 && NewPassword.Text.Length == 0 && RepeatPassword.Text.Length == 0))
            {
                if (NewPassword.Text.Contains("-") || NewPassword.Text.Contains(":"))
                {
                    MessageBox.Show("Cannot use a ':' or '-' the new password.");

                    return false;
                }

                if (PreviousPassword.Text == Home.realPassword)
                {
                    if (NewPassword.Text.Length > 0 && NewPassword.Text == RepeatPassword.Text)
                    {
                        Home.realPassword = NewPassword.Text;

                        return true;
                    }

                    MessageBox.Show("Enter the same password into New Password and Repeat New to change your password!");
                }

                else
                {
                    MessageBox.Show("Your password entry does not match what is stored.");
                }
            }

            return false;
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}


