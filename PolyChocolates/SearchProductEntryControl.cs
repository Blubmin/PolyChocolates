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
    public partial class SearchProductEntryControl : UserControl
    {
        byte[] image = null;
        public SearchProductEntryControl(ProductEntry productEntry)
        {
            InitializeComponent();

            productBox.Text = productEntry.Recipe.Name;
            CodeDate.Text = productEntry.CodeDate;
            date.Text = productEntry.Date.ToString().Replace("12:00:00 AM", "");
            AmountProducedTextField.Text = productEntry.AmountProduced + "";
            AmountPackagedTextField1.Text = productEntry.AmountPackaged + "";
            productionNotesSummaryTextBox.Text = productEntry.ProductionNotes;
            StudentManagerNameTextField.Text = productEntry.StudentManager;
            image = productEntry.haacp.ToArray();
            if (productEntry.haacp.Length > 0)
            {
                haacp.Image = InventoryControl.document;
                haacp.Click += new EventHandler(attachHACCP);
            }
            else
                haacp.Image = InventoryControl.blankDocument;
            pilotPlantManagerTextBox.Text = productEntry.PlantManager;
        }

        private void attachHACCP(object sender, EventArgs e)
        {
            HACCP window = new HACCP(image);
            window.ShowDialog();
        }
    }
}
