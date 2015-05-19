using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyChocolates
{
    public partial class SearchEntry : Form
    {
        databaseDataContext db = new databaseDataContext();
        ProductEntry productEntry = null;
        String codeDate = "";

        public SearchEntry(String codeDate)
        {
            InitializeComponent();

            this.Resize += new EventHandler(resized);

            this.codeDate = codeDate;

            this.Text = codeDate;

            var query =
                from entries in db.ProductEntries
                where entries.CodeDate == codeDate
                select entries;

            foreach (var p in query)
            {
                productEntry = p;
            }

            setupViewableForms();
        }


        private void resized(object sender, EventArgs e)
        {
            container.Height = this.Height - 60;
            ResultsTable.Height = container.Height;
        }

        private void setupViewableForms()
        {
            addControl(new SearchProductEntryControl(productEntry));

            if (productEntry.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL)
                addControl(new ChocolateQualityControl(productEntry));
            else if (productEntry.QualityControlId > Library.CHOCOLATE_QUALITY_CONTROL)
                addControl(new GenericQualityControl(productEntry));

            if (productEntry.Traceabilities.Count() > 0)
                addControl(new TraceabilityControl(productEntry));

            if (productEntry.Efficiencies.Count() > 0)
                addControl(new GenericEfficiencyControl(productEntry));


            // If there are checklists associated with this code date
            showChecklists();


        }

        private void showChecklists()
        {
            var query =
                from checklist in db.Checklists
                where checklist.CodeDate == codeDate
                select checklist;


            foreach (var checklist in query)
            {
                switch (checklist.Type)
                {
                    case ("chocolatesetup"):
                        addControl(new ChocolateSetupControl(checklist));
                        break;
                    case ("chocolateshutdown"):
                        addControl(new ChocolateShutdownControl(checklist));
                        break;
                    case ("bbqsetup"):
                        addControl(new BBQSetupControl(checklist));
                        break;
                    case ("bbqshutdown"):
                        addControl(new BBQShutdownControl(checklist));
                        break;
                    case ("jamsetup"):
                        addControl(new JamSetupControl(checklist));
                        break;
                    case ("jamshutdown"):
                        addControl(new JamShutdownControl(checklist));
                        break;
                    default:
                        break;
                }
            }
        }

        private void addControl(UserControl control)
        {
            List<Control> buttons = new List<Control>();

            foreach (Control c in control.Controls)
            {
                if (c is TableLayoutPanel)
                {
                    foreach (Control inner in ((TableLayoutPanel)c).Controls)
                    {
                        if (inner is TextBox)
                            ((TextBox)inner).ReadOnly = true;
                    }
                }
                else
                {
                    if (c is TextBox)
                        ((TextBox)c).ReadOnly = true;
                    else if (c is RichTextBox)
                        ((RichTextBox)c).ReadOnly = true;
                }
                if (c is Button)
                {
                    buttons.Add(c);
                }
            }

            foreach (Control c in buttons)
            {
                control.Controls.Remove(c);
            }

            ResultsTable.Controls.Add(control);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Result";// Default file name
            dialog.DefaultExt = ".jpg";// Default file extension
            dialog.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //int previousWindowHeight = this.Height;
                //int previousContainerHeight = container.Height;
                //this.Height = ResultsTable.PreferredSize.Height;
                //container.Height = ResultsTable.PreferredSize.Height;

                Bitmap bmp = new Bitmap(this.ResultsTable.Width, this.ResultsTable.Height);
                this.ResultsTable.DrawToBitmap(bmp, new Rectangle(0, 0, this.ResultsTable.Width, this.ResultsTable.Height));

                bmp.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                //this.Height = previousWindowHeight;
                //container.Height = previousContainerHeight;
            }
        }
    }
}
