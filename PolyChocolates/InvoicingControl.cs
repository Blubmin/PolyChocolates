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
    public partial class InvoicingControl : UserControl
    {
        databaseDataContext db = new databaseDataContext();
        List<InvoiceRowEntry> entryList = new List<InvoiceRowEntry>();
        Home home;
        public InvoicingControl(Home home)
        {
            InitializeComponent();
            totalOwed.TextChanged += new EventHandler(Library.formatMoney);
            this.home = home;

            var query =
                from cust in db.Customers
                where cust.Type == "Current" && cust.Enabled == "Y"
                select cust.Name;

            customer.DataSource = query;
            customer.SelectedItem = null;
            customer.SelectedValueChanged += new EventHandler(updateAccountNumber);
            customer.SelectedValueChanged += new EventHandler(updateSubmitEnabled);
            invoice.TextChanged += new EventHandler(updateSubmitEnabled);
        }

        private void updateAccountNumber(object sender, EventArgs e)
        {
            var query =
                from cust in db.Customers
                where cust.Name == customer.SelectedItem
                select cust.AccountNumber;
            accountNumber.Text = query.First();
        }

        private void updateSubmitEnabled(object sender, EventArgs e)
        {
            bool enable = true;
            if (customer.SelectedItem == null || invoice.Text.Length == 0)
                enable = false;
            foreach (InvoiceRowEntry row in entryList)
            {
                if (row.product.SelectedItem == null || row.codeDate.SelectedItem == null || row.creditAccount.Text.Length == 0)
                    enable = false;
            }
            submit.Enabled = enable;
        }

        public class InvoiceRowEntry
        {
            databaseDataContext db = new databaseDataContext();
            public CheckBox check = new CheckBox();
            public ComboBox product = new ComboBox();
            public ComboBox codeDate = new ComboBox();
            public TextBox quantity = new TextBox();
            public TextBox ratePer = new TextBox();
            public TextBox price = new TextBox();
            public TextBox creditAccount = new TextBox();

            public InvoiceRowEntry()
            {
                check.Dock = DockStyle.Fill;

                product.Dock = DockStyle.Fill;
                product.DropDownStyle = ComboBoxStyle.DropDownList;

                HashSet<String> products = new HashSet<String>();
                var query =
                    from finishedProduct in db.Inventories
                    where finishedProduct.Enabled == "Y" && finishedProduct.Type == "finished"
                    select finishedProduct.Name;
                foreach (String s in query)
                {
                    products.Add(s);
                }
                product.DataSource = products.ToArray();
                product.SelectedValueChanged += new EventHandler(updateCodeDateList);               
                codeDate.Dock = DockStyle.Fill;
                codeDate.DropDownStyle = ComboBoxStyle.DropDownList;
                codeDate.SelectedValueChanged += new EventHandler(checkQuantityTotal);
                codeDate.SelectedValueChanged += new EventHandler(updatePricePer);              
                quantity.Dock = DockStyle.Fill;
                quantity.TextAlign = HorizontalAlignment.Center;
                quantity.Text = "0";
                quantity.Leave += new EventHandler(Library.onlyAllowNumerics);
                quantity.Leave += new EventHandler(updatePrice);
                quantity.Leave += new EventHandler(checkQuantityTotal);
                ratePer.Dock = DockStyle.Fill;
                ratePer.TextAlign = HorizontalAlignment.Center;
                ratePer.Leave += new EventHandler(Library.formatMoney);
                ratePer.Leave += new EventHandler(updatePrice);
                price.Dock = DockStyle.Fill;
                price.Text = "0.00";
                price.TextAlign = HorizontalAlignment.Center;
                price.ReadOnly = true;
                price.TextChanged += new EventHandler(Library.formatMoney);
                creditAccount.Dock = DockStyle.Fill;
                creditAccount.TextAlign = HorizontalAlignment.Center;
            }

            private void checkQuantityTotal(object sender, EventArgs e)
            {
                var query =
                    from quant in db.Inventories
                    where quant.Name == product.SelectedItem && quant.LotCode == codeDate.SelectedItem && quant.Enabled == "Y" && quant.Type == "finished"
                    select quant.Stock;
                
                if (query.Count() > 0 && query.First() < Double.Parse(quantity.Text))
                    MessageBox.Show("Only have " + query.First() + " available!");
            }

            public void removeHandlers()
            {
                quantity.Leave -= new EventHandler(updatePrice);
                ratePer.Leave -= new EventHandler(updatePrice);
                codeDate.SelectedValueChanged -= new EventHandler(updatePricePer);
            }

            private void updateCodeDateList(object sender, EventArgs e)
            {
                var query =
                    from finishedProducts in db.Inventories
                    where finishedProducts.Enabled == "Y" && finishedProducts.Name == product.SelectedItem && finishedProducts.Type == "finished"
                    select finishedProducts.LotCode;
                codeDate.DataSource = query;
            }

            private void updatePricePer(object sender, EventArgs e)
            {
                var query =
                    from quant in db.Inventories
                    where quant.Name == product.SelectedItem && quant.LotCode == codeDate.SelectedItem && quant.Enabled == "Y" && quant.Type == "finished"
                    select quant.PricePerUnit;
                if (query.Count() > 0)
                    ratePer.Text = query.First() + "";
                Library.formatMoney(ratePer, null);
            }

            public void updatePrice(object sender, EventArgs e)
            {
                price.Text = "" + Convert.ToDecimal(quantity.Text) * Convert.ToDecimal(ratePer.Text);
            }
        }


        private void updatePricePer(InvoiceRowEntry row)
        {
            var query =
                from quant in db.Inventories
                where quant.Name == row.product.SelectedItem && quant.LotCode == row.codeDate.SelectedItem && quant.Enabled == "Y" && quant.Type == "finished"
                select quant.PricePerUnit;
            if (query.Count() > 0)
                row.ratePer.Text = query.First() + "";
        }

        private void updateTotal(object sender, EventArgs e)
        {
            double total = 0;
            foreach (InvoiceRowEntry row in entryList)
            {
                total += Convert.ToDouble(row.price.Text);
            }

            totalOwed.Text = total + "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            InvoiceRowEntry row = new InvoiceRowEntry();
            entryList.Add(row);
            table.Controls.Add(row.check);
            row.product.SelectedIndexChanged += new EventHandler(updateSubmitEnabled);
            table.Controls.Add(row.product);
            row.codeDate.SelectedIndexChanged += new EventHandler(updateSubmitEnabled);
            table.Controls.Add(row.codeDate);
            row.quantity.Validated += new EventHandler(updateTotal);
            table.Controls.Add(row.quantity);
            row.ratePer.Validated += new EventHandler(updateTotal);
            table.Controls.Add(row.ratePer);
            table.Controls.Add(row.price);
            row.creditAccount.TextChanged += new EventHandler(updateSubmitEnabled);
            table.Controls.Add(row.creditAccount);
            submit.Enabled = false;
            updatePricePer(row);
            Library.formatMoney(row.ratePer, null);
            row.updatePrice(null, null);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            List<InvoiceRowEntry> remove = new List<InvoiceRowEntry>();

            foreach (InvoiceRowEntry row in entryList)
            {
                if (row.check.Checked)
                    remove.Add(row);
            }

            foreach (InvoiceRowEntry row in remove)
            {
                table.Controls.Remove(row.check);
                table.Controls.Remove(row.product);
                table.Controls.Remove(row.codeDate);
                table.Controls.Remove(row.quantity);
                table.Controls.Remove(row.ratePer);
                table.Controls.Remove(row.price);
                table.Controls.Remove(row.creditAccount);

                entryList.Remove(row);
            }

            updateTotal(null, null);
            updateSubmitEnabled(null, null);
        }

        private void submit_Click(object sender, EventArgs e)
        {
            Invoice invoiceOrder = new Invoice();
            invoiceOrder.InvoiceNumber = invoice.Text;
            invoiceOrder.Date = Convert.ToDateTime(date.Text);
            invoiceOrder.Total = Convert.ToDecimal(totalOwed.Text);
            invoiceOrder.Status = "N";

            var query =
                from cust in db.Customers
                where cust.Name == customer.SelectedItem
                select cust;

            foreach (var customer in query)
            {
                invoiceOrder.Customer = customer;
            }
            db.Invoices.InsertOnSubmit(invoiceOrder);
            foreach (InvoiceRowEntry row in entryList)
            {
                InvoiceRow newEntry = new InvoiceRow();
                newEntry.Product = row.product.Text;
                newEntry.CodeDate = row.codeDate.Text;
                newEntry.Quantity = Double.Parse(row.quantity.Text);
                newEntry.RatePer = Convert.ToDecimal(row.ratePer.Text);
                newEntry.CreditAccount = row.creditAccount.Text;
                newEntry.Invoice = invoiceOrder;
                db.InvoiceRows.InsertOnSubmit(newEntry);
            }

            db.SubmitChanges();
            MessageBox.Show("Succesfully submitted invoice.");
            home.refreshInventory();
            home.refreshInvoice();
            home.newInvoiceToolStripMenuItem_Click(null, null);
        }

    }
}
