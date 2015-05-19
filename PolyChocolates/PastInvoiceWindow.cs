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
    public partial class PastInvoiceWindow : Form
    {
        databaseDataContext db = new databaseDataContext();

        public PastInvoiceWindow(String invoice)
        {
            InitializeComponent();

            this.Text = invoice;

            var query =
                from invoiceRow in db.Invoices
                where invoiceRow.InvoiceNumber == invoice
                select invoiceRow;


            foreach (var inv in query)
            {
                date.Text = inv.Date.ToString().Replace("12:00:00 AM", "");
                date.ReadOnly = true;
                invoiceNumber.Text = inv.InvoiceNumber;
                invoiceNumber.ReadOnly = true;
                customer.Text = inv.Customer.Name;
                customer.Enabled = false;
                accountNumber.Text = inv.Customer.AccountNumber;
                accountNumber.ReadOnly = true;
                Total.Text = inv.Total + "";
            }

            foreach (var inv in query)
            {
                foreach (var invoiceRow in inv.InvoiceRows)
                {
                    InvoicingControl.InvoiceRowEntry row = new InvoicingControl.InvoiceRowEntry();

                    // remove event handlers
                    row.removeHandlers();

                    row.product.Text = invoiceRow.Product;
                    row.product.Enabled = false;
                    row.codeDate.Text = invoiceRow.CodeDate;
                    row.codeDate.Enabled = false;
                    row.quantity.Text = invoiceRow.Quantity.ToString();
                    row.quantity.ReadOnly = true;
                    row.ratePer.Text = Convert.ToDouble(invoiceRow.RatePer) + "";
                    row.ratePer.ReadOnly = true;
                    double rowPrice = invoiceRow.Quantity * Convert.ToDouble(invoiceRow.RatePer);
                    row.price.Text = rowPrice + "";
                    row.price.ReadOnly = true;
                    row.creditAccount.Text = invoiceRow.CreditAccount;
                    row.creditAccount.ReadOnly = true;

                    table.Controls.Add(row.product);
                    table.Controls.Add(row.codeDate);
                    table.Controls.Add(row.quantity);
                    table.Controls.Add(row.ratePer);
                    table.Controls.Add(row.price);
                    table.Controls.Add(row.creditAccount);
                }
            }

            foreach (Control c in this.Controls)
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
                }
            }

            panel3.Height = container.Height;
            toSave.Height = container.Height + panel1.Height + 270;
            InvoiceSpielControl spiel = new InvoiceSpielControl();
            spiel.Location = new Point(0, container.Bottom);
            toSave.Controls.Add(spiel);
        }

        private void saveDocumentButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Result";// Default file name
            dialog.DefaultExt = ".Jpg";// Default file extension
            dialog.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int previousWindowHeight = this.Height;
                int previousContainerHeight = container.Height;
                this.Height = table.PreferredSize.Height;
                container.Height = table.PreferredSize.Height;

                Bitmap bmp = new Bitmap(this.container.Width, this.container.Height);
                this.container.DrawToBitmap(bmp, new Rectangle(0, 0, this.container.Width, this.container.Height));

                bmp.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                this.Height = previousWindowHeight;
                container.Height = previousContainerHeight;
            }
        }

        private void saveDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDocumentButton_Click(null, null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "invoice_" + invoiceNumber.Text;// Default file name
            dialog.DefaultExt = ".jpg";// Default file extension
            dialog.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                Bitmap bmp = new Bitmap(this.toSave.Width, this.toSave.Height);
                this.toSave.DrawToBitmap(bmp, new Rectangle(0, 0, this.toSave.Width, this.toSave.Height));

                bmp.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}
