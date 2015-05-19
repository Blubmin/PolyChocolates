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
    public partial class QualityWindow : Form
    {
        private databaseDataContext db = new databaseDataContext();
        private List<QualityRow> qualityList;
        private Label selectedForm = null;
        private Home home;

        public QualityWindow(Home home)
        {
            InitializeComponent();
            this.home = home;
            loadList();
        }

        private class QualityRow
        {
            public QualityControl control;
            public CheckBox toRemove = new CheckBox();
            public Label name = new Label();

            public QualityRow(QualityControl control)
            {
                this.control = control;
                toRemove.Text = "";
                name.Text = control.Name;
                name.Dock = DockStyle.Fill;
                name.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void loadList()
        {
            qualityList = new List<QualityRow>();
            qualityTable.Controls.Clear();
            var query =
                from qc in db.QualityControls
                where qc.Enabled == "Y" &&
                qc.QualityControlId > Library.CHOCOLATE_QUALITY_CONTROL
                orderby qc.Name
                select qc;

            foreach (var qc in query)
            {
                QualityRow row = new QualityRow(qc);
                qualityTable.Controls.Add(row.toRemove);
                qualityTable.Controls.Add(row.name);
                row.name.Click += new EventHandler(selectForm);
                qualityList.Add(row);
            }
            qualityTable.Controls.Add(new Label());
        }

        private void selectForm(object sender, EventArgs e)
        {
            if (selectedForm != null)
                selectedForm.BackColor = Color.White;
            selectedForm = ((Label) sender);
            selectedForm.BackColor = Color.Gainsboro;
            qualityPanel.Controls.Clear();
            qualityPanel.Controls.Add(new GenericQualityControl(selectedForm.Text));
        }

        private void newQualityButton_Click(object sender, EventArgs e)
        {
            qualityPanel.Controls.Clear();
            qualityPanel.Controls.Add(new GenericQualityControl());
        }

        private void refreshList(object sender, EventArgs e)
        {
            loadList();
            qualityPanel.BackColor = Color.Gainsboro;
            home.refreshProductEntry();
        }

        private void removeSelected_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This cannot be undone, are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (var row in qualityList)
                {
                    if (row.toRemove.Checked)
                    {
                        row.control.Enabled = "N";
                        qualityTable.Controls.Remove(row.toRemove);
                        qualityTable.Controls.Remove(row.name);
                        foreach (var recipe in row.control.Recipes)
                        {
                            recipe.QualityControlId = 1;
                        }
                    }
                }
                db.SubmitChanges();
                home.refreshProductEntry();
                qualityPanel.Controls.Clear();
                home.refreshRecipeControl();
            }
        }
    }
}
