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
    public partial class NewRecipe : Form
    {
        private databaseDataContext db = new databaseDataContext();

        public NewRecipe()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            var newRecipe = new Recipe
            {
                Name = textBox1.Text,
                QualityControlId = 1,
                Enabled = "Y"
            };
            db.Recipes.InsertOnSubmit(newRecipe);
            db.SubmitChanges();
            this.Dispose();
        }
    }
}
