using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.SqlClient;

namespace PolyChocolates
{
    public partial class InvoiceSearch : UserControl
    {
        databaseDataContext db = new databaseDataContext();
        Home home;

        public InvoiceSearch(Home home)
        {
            InitializeComponent();
            this.home = home;
            searchType.SelectedIndex = 0;
            clearTable();
        }

        public void clearTable()
        {
            Font bolded = new Font(label1.Font, FontStyle.Bold);

            Label Status = new Label();
            Status.AutoSize = true;
            Status.Font = bolded;
            Status.Text = "";
            Label InvoiceNo = new Label();
            InvoiceNo.AutoSize = true;
            InvoiceNo.Font = bolded;
            InvoiceNo.Text = "Invoice Number";
            Label Customer = new Label();
            Customer.AutoSize = true;
            Customer.Font = bolded;
            Customer.Text = "Customer";
            Label AccountNo = new Label();
            AccountNo.AutoSize = true;
            AccountNo.Font = bolded;
            AccountNo.Text = "Account Number";
            Label Date = new Label();
            Date.AutoSize = true;
            Date.Font = bolded;
            Date.Text = "Date";
            Label Total = new Label();
            Total.AutoSize = true;
            Total.Font = bolded;
            Total.Text = "Total Amount";

            searchResults.Controls.Clear();
            searchResults.Controls.Add(Status);
            searchResults.Controls.Add(InvoiceNo);
            searchResults.Controls.Add(Customer);
            searchResults.Controls.Add(AccountNo);
            searchResults.Controls.Add(Date);
            searchResults.Controls.Add(Total);
        }

        private void search()
        {
            searchResults.Visible = false;
            clearTable();
            IQueryable<Invoice> query = null;
            switch (searchType.SelectedIndex)
            {
                case 0:
                    query =
                        from invoices in db.Invoices
                        where SqlMethods.Like(invoices.InvoiceNumber, "%" + searchBox.Text + "%")
                        orderby invoices.Status
                        orderby invoices.Date descending
                        select invoices;
                    break;
                case 1:
                    query =
                        from invoices in db.Invoices
                        where SqlMethods.Like(invoices.Customer.Name, "%" + searchBox.Text + "%")
                        orderby invoices.Status
                        orderby invoices.Date descending
                        select invoices;
                    break;
                case 2:
                    query =
                        from invoiceRows in db.InvoiceRows
                        where SqlMethods.Like(invoiceRows.CodeDate, "%" + searchBox.Text + "%")
                        orderby invoiceRows.Invoice.Status
                        orderby invoiceRows.Invoice.Date descending
                        select invoiceRows.Invoice;
                    break;
                default:
                    break;
            }

            if (query.Count() > 0)
            {
                String plural = query.Count() == 1 ? "" : "s";
                ResultsLabel.ForeColor = Color.Black;
                ResultsLabel.Text = query.Count() + " result" + plural + " found.";
            }
            else
            {
                ResultsLabel.ForeColor = Color.Red;
                ResultsLabel.Text = "No results found.";
            }
            foreach (var invoice in query)
            {
                SearchRow search = new SearchRow(invoice, this);
                search.invoiceNo.Click += new EventHandler(invoice_Click);
                searchResults.Controls.Add(search.status);
                searchResults.Controls.Add(search.invoiceNo);
                searchResults.Controls.Add(search.customer);
                searchResults.Controls.Add(search.accountNo);
                searchResults.Controls.Add(search.date);
                searchResults.Controls.Add(search.amount);
            }
            searchResults.Controls.Add(new Label());
            searchResults.Visible = true;
        }

        private void invoice_Click(object sender, EventArgs e)
        {

            Label theLbl = (Label)sender;
            theLbl.ForeColor = Color.FromArgb(102, 51, 102);

            PastInvoiceWindow pI = new PastInvoiceWindow(theLbl.Text);
            pI.ShowDialog();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            search();
        }

        private class SearchRow
        {
            databaseDataContext db = new databaseDataContext();
            private int id;
            private Image progress = Image.FromFile("../../IconImages/in_progress.png");
            private Image checkMark = Image.FromFile("../../IconImages/small_check.png");
            public PictureBox status = new PictureBox();
            public Label invoiceNo = new Label();
            public Label customer = new Label();
            public Label accountNo = new Label();
            public Label date = new Label();
            public Label amount = new Label();
            ContextMenu rightClick = new ContextMenu();
            MenuItem complete = new MenuItem();
            MenuItem inProgress = new MenuItem();

            public SearchRow(Invoice invoice, InvoiceSearch s)
            {
                id = invoice.InvoiceId;
                complete.Text = "Mark as complete";
                complete.Click += new EventHandler(enable);
                inProgress.Text = "Mark as incomplete";
                inProgress.Click += new EventHandler(disable);
                status.SizeMode = PictureBoxSizeMode.AutoSize;
                status.Image = (invoice.Status == "Y" ? checkMark : progress);
                rightClick.MenuItems.Add((invoice.Status == "Y" ? inProgress : complete));
                status.ContextMenu = rightClick;
                invoiceNo.AutoSize = true;
                invoiceNo.Font = new Font(s.searchResults.Font, FontStyle.Bold | FontStyle.Underline);
                invoiceNo.ForeColor = Color.FromArgb(6, 69, 173);
                invoiceNo.Cursor = Cursors.Hand;
                invoiceNo.Text = invoice.InvoiceNumber;
                customer.AutoSize = true;
                customer.Text = invoice.Customer.Name;
                accountNo.AutoSize = true;
                accountNo.Text = invoice.Customer.AccountNumber;
                date.AutoSize = true;
                date.Text = ((DateTime)invoice.Date).ToShortDateString();
                amount.AutoSize = true;
                amount.TextChanged += new EventHandler(Library.formatMoney);
                amount.Text = invoice.Total +"";
            }

            private void enable(object sender, EventArgs e)
            {
                status.Image = checkMark;
                rightClick.MenuItems.Remove(complete);
                rightClick.MenuItems.Add(inProgress);

                var query =
                    from invoice in db.Invoices
                    where invoice.InvoiceId == id
                    select invoice;
                query.First().Status = "Y";
                db.SubmitChanges();
            }

            private void disable(object sender, EventArgs e)
            {
                status.Image = progress;
                rightClick.MenuItems.Add(complete);
                rightClick.MenuItems.Remove(inProgress);

                var query =
                    from invoice in db.Invoices
                    where invoice.InvoiceId == id
                    select invoice;
                query.First().Status = "N";
                db.SubmitChanges();
            }
        }
    }
}
