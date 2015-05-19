using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyChocolates
{
    public partial class PasswordProtectWindow : Form
    {
        private String realPassword = "FSNproduction";

        public PasswordProtectWindow()
        {
            InitializeComponent();
            setupWindow();
            this.Text = "Password";
            passwordEntry.Select();
        }

        private void setupWindow()
        {
            passwordEntry.PasswordChar = '*';
            passwordEntry.MaxLength = 13;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (passwordEntry.Text != realPassword)
            {
                result.Text = "Incorrect";
                passwordEntry.Clear();
                passwordEntry.Select();
            }
            else
            {
                Home.changeViewToRecipes();
                this.Dispose();
            }
        }

        private void passwordEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submit_Click(null, null);
            }
        }
    }
}
