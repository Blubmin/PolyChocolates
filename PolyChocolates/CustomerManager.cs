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
    public partial class CustomerManager : Form
    {
        List<CustomerRow> existingCustomers;
        List<CustomerRow> newCustomers;
        databaseDataContext db = new databaseDataContext();

        private static String[] stateList = {"AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA", "GU", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MH", "MI", "MN", "MO", "MS", "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "PR", "PW", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VI", "VT", "WA", "WI", "WV", "WY"};

        public CustomerManager()
        {
            loadCustomers();
        }

        private void loadCustomers()
        {
            InitializeComponent();
            existingCustomers = new List<CustomerRow>();
            newCustomers = new List<CustomerRow>();
            var query =
                from cust in db.Customers
                where cust.Enabled == "Y"
                orderby cust.Name
                select cust;
            foreach (var customer in query)
            {
                CustomerRow newRow = new CustomerRow(customer);
                existingCustomers.Add(newRow);
                switch (customer.Type)
                {
                    case "Current":
                        currentCustomerTable.Controls.Add(newRow.toRemove);
                        currentCustomerTable.Controls.Add(newRow.name);
                        currentCustomerTable.Controls.Add(newRow.account);
                        currentCustomerTable.Controls.Add(newRow.address);
                        currentCustomerTable.Controls.Add(newRow.city);
                        currentCustomerTable.Controls.Add(newRow.state);
                        currentCustomerTable.Controls.Add(newRow.zip);
                        currentCustomerTable.Controls.Add(newRow.phone);
                        currentCustomerTable.Controls.Add(newRow.type);
                        break;
                    case "Prospective":
                        prospectiveCustomerTable.Controls.Add(newRow.toRemove);
                        prospectiveCustomerTable.Controls.Add(newRow.name);
                        prospectiveCustomerTable.Controls.Add(newRow.account);
                        prospectiveCustomerTable.Controls.Add(newRow.address);
                        prospectiveCustomerTable.Controls.Add(newRow.city);
                        prospectiveCustomerTable.Controls.Add(newRow.state);
                        prospectiveCustomerTable.Controls.Add(newRow.zip);
                        prospectiveCustomerTable.Controls.Add(newRow.phone);
                        prospectiveCustomerTable.Controls.Add(newRow.type);
                        break;
                    case "Past":
                        pastCustomerTable.Controls.Add(newRow.toRemove);
                        pastCustomerTable.Controls.Add(newRow.name);
                        pastCustomerTable.Controls.Add(newRow.account);
                        pastCustomerTable.Controls.Add(newRow.address);
                        pastCustomerTable.Controls.Add(newRow.city);
                        pastCustomerTable.Controls.Add(newRow.state);
                        pastCustomerTable.Controls.Add(newRow.zip);
                        pastCustomerTable.Controls.Add(newRow.phone);
                        pastCustomerTable.Controls.Add(newRow.type);
                        break;
                    default:
                        break;
                }
            }
        }

        private class CustomerRow
        {
            public Customer customer;
            public CheckBox toRemove = new CheckBox();
            public TextBox name = new TextBox();
            public TextBox account = new TextBox();
            public TextBox address = new TextBox();
            public TextBox city = new TextBox();
            public ComboBox state = new ComboBox();
            public TextBox zip = new TextBox();
            public TextBox phone = new TextBox();
            public ComboBox type = new ComboBox();

            public CustomerRow(Customer customer)
            {
                this.customer = customer;
                name.Dock = DockStyle.Fill;
                name.Validated += new EventHandler(refreshCustomer);
                name.Text = customer.Name;
                name.Name = "name";

                account.Dock = DockStyle.Fill;
                account.Validated += new EventHandler(refreshCustomer);
                account.Text = customer.AccountNumber;
                account.Name = "account";

                address.Dock = DockStyle.Fill;
                address.Validated += new EventHandler(refreshCustomer);
                address.Text = customer.Address;
                address.Name = "address";

                city.Dock = DockStyle.Fill;
                city.Validated += new EventHandler(refreshCustomer);
                city.Text = customer.City;
                city.Name = "city";

                state.Items.AddRange(CustomerManager.stateList);
                state.Width = 50;
                state.DropDownStyle = ComboBoxStyle.DropDownList;
                state.SelectedItem = customer.State;
                state.SelectedIndexChanged += new EventHandler(refreshCustomer);
                state.Name = "state";

                zip.Dock = DockStyle.Fill;
                zip.Validated += new EventHandler(refreshCustomer);
                zip.Text = customer.ZipCode;
                zip.Name = "zip";

                phone.Dock = DockStyle.Fill;
                phone.Validated += new EventHandler(refreshCustomer);
                phone.Text = customer.PhoneNumber;
                phone.Name = "phone";

                type.Items.Add("Current");
                type.Items.Add("Prospective");
                type.Items.Add("Past");
                type.Dock = DockStyle.Fill;
                type.DropDownStyle = ComboBoxStyle.DropDownList;
                type.SelectedIndexChanged += new EventHandler(refreshCustomer);
                type.SelectedItem = customer.Type;
                type.Name = "type";
            }

            private void refreshCustomer(object sender, EventArgs e)
            {
                switch (((Control)sender).Name)
                {
                    case "name":
                        customer.Name = name.Text;
                        break;
                    case "account":
                        customer.AccountNumber = account.Text;
                        break;
                    case "address":
                        customer.Address = address.Text;
                        break;
                    case "city":
                        customer.City = city.Text;
                        break;
                    case "state":
                        customer.State = (string)state.SelectedItem;
                        break;
                    case "zip":
                        customer.ZipCode = zip.Text;
                        break;
                    case "phone":
                        customer.PhoneNumber = phone.Text;
                        break;
                    case "type":
                        customer.Type = (string)type.SelectedItem;
                        break;
                    default:
                        break;
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer() { Type = "Current", Enabled = "Y" };
            CustomerRow newRow = new CustomerRow(newCustomer);
            newCustomers.Add(newRow);
            String text = ((Button)sender).Name;
            text = text.Replace("add", "");
            switch (text)
            {
                case "Current":
                    currentCustomerTable.Controls.Add(newRow.toRemove);
                    currentCustomerTable.Controls.Add(newRow.name);
                    currentCustomerTable.Controls.Add(newRow.account);
                    currentCustomerTable.Controls.Add(newRow.address);
                    currentCustomerTable.Controls.Add(newRow.city);
                    currentCustomerTable.Controls.Add(newRow.state);
                    currentCustomerTable.Controls.Add(newRow.zip);
                    currentCustomerTable.Controls.Add(newRow.phone);
                    currentCustomerTable.Controls.Add(newRow.type);
                    newRow.state.SelectedIndex = 0;
                    newRow.type.SelectedIndex = 0;
                    break;
                case "Prospective":
                    prospectiveCustomerTable.Controls.Add(newRow.toRemove);
                    prospectiveCustomerTable.Controls.Add(newRow.name);
                    prospectiveCustomerTable.Controls.Add(newRow.account);
                    prospectiveCustomerTable.Controls.Add(newRow.address);
                    prospectiveCustomerTable.Controls.Add(newRow.city);
                    prospectiveCustomerTable.Controls.Add(newRow.state);
                    prospectiveCustomerTable.Controls.Add(newRow.zip);
                    prospectiveCustomerTable.Controls.Add(newRow.phone);
                    prospectiveCustomerTable.Controls.Add(newRow.type);
                    newRow.state.SelectedIndex = 0;
                    newRow.type.SelectedIndex = 1;
                    break;
                case "Past":
                    pastCustomerTable.Controls.Add(newRow.toRemove);
                    pastCustomerTable.Controls.Add(newRow.name);
                    pastCustomerTable.Controls.Add(newRow.account);
                    pastCustomerTable.Controls.Add(newRow.address);
                    pastCustomerTable.Controls.Add(newRow.city);
                    pastCustomerTable.Controls.Add(newRow.state);
                    pastCustomerTable.Controls.Add(newRow.zip);
                    pastCustomerTable.Controls.Add(newRow.phone);
                    pastCustomerTable.Controls.Add(newRow.type);
                    newRow.state.SelectedIndex = 0;
                    newRow.type.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete these customers?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<CustomerRow> existingRemove = new List<CustomerRow>();

                foreach (var row in existingCustomers)
                {
                    if (row.toRemove.Checked)
                    {
                        existingRemove.Add(row);
                        row.customer.Enabled = "N";
                    }
                }
                foreach (var row in existingRemove)
                {
                    existingCustomers.Remove(row);
                    switch (row.type.Text)
                    {
                        case "Current":
                            currentCustomerTable.Controls.Remove(row.toRemove);
                            currentCustomerTable.Controls.Remove(row.name);
                            currentCustomerTable.Controls.Remove(row.account);
                            currentCustomerTable.Controls.Remove(row.address);
                            currentCustomerTable.Controls.Remove(row.city);
                            currentCustomerTable.Controls.Remove(row.state);
                            currentCustomerTable.Controls.Remove(row.zip);
                            currentCustomerTable.Controls.Remove(row.phone);
                            currentCustomerTable.Controls.Remove(row.type);
                            break;
                        case "Prospective":
                            prospectiveCustomerTable.Controls.Remove(row.toRemove);
                            prospectiveCustomerTable.Controls.Remove(row.name);
                            prospectiveCustomerTable.Controls.Remove(row.account);
                            prospectiveCustomerTable.Controls.Remove(row.address);
                            prospectiveCustomerTable.Controls.Remove(row.city);
                            prospectiveCustomerTable.Controls.Remove(row.state);
                            prospectiveCustomerTable.Controls.Remove(row.zip);
                            prospectiveCustomerTable.Controls.Remove(row.phone);
                            prospectiveCustomerTable.Controls.Remove(row.type);
                            break;
                        case "Past":
                            pastCustomerTable.Controls.Remove(row.toRemove);
                            pastCustomerTable.Controls.Remove(row.name);
                            pastCustomerTable.Controls.Remove(row.account);
                            pastCustomerTable.Controls.Remove(row.address);
                            pastCustomerTable.Controls.Remove(row.city);
                            pastCustomerTable.Controls.Remove(row.state);
                            pastCustomerTable.Controls.Remove(row.zip);
                            pastCustomerTable.Controls.Remove(row.phone);
                            pastCustomerTable.Controls.Remove(row.type);
                            break;
                        default:
                            break;
                    }
                }

                List<CustomerRow> newRemove = new List<CustomerRow>();

                foreach (var row in newCustomers)
                {
                    if (row.toRemove.Checked)
                    {
                        newRemove.Add(row);
                        row.customer.Enabled = "N";
                    }
                }
                foreach (var row in newRemove)
                {
                    newCustomers.Remove(row);
                    switch (row.type.Text)
                    {
                        case "Current":
                            currentCustomerTable.Controls.Remove(row.toRemove);
                            currentCustomerTable.Controls.Remove(row.name);
                            currentCustomerTable.Controls.Remove(row.account);
                            currentCustomerTable.Controls.Remove(row.address);
                            currentCustomerTable.Controls.Remove(row.city);
                            currentCustomerTable.Controls.Remove(row.state);
                            currentCustomerTable.Controls.Remove(row.zip);
                            currentCustomerTable.Controls.Remove(row.phone);
                            currentCustomerTable.Controls.Remove(row.type);
                            break;
                        case "Prospective":
                            prospectiveCustomerTable.Controls.Remove(row.toRemove);
                            prospectiveCustomerTable.Controls.Remove(row.name);
                            prospectiveCustomerTable.Controls.Remove(row.account);
                            prospectiveCustomerTable.Controls.Remove(row.address);
                            prospectiveCustomerTable.Controls.Remove(row.city);
                            prospectiveCustomerTable.Controls.Remove(row.state);
                            prospectiveCustomerTable.Controls.Remove(row.zip);
                            prospectiveCustomerTable.Controls.Remove(row.phone);
                            prospectiveCustomerTable.Controls.Remove(row.type);
                            break;
                        case "Past":
                            pastCustomerTable.Controls.Remove(row.toRemove);
                            pastCustomerTable.Controls.Remove(row.name);
                            pastCustomerTable.Controls.Remove(row.account);
                            pastCustomerTable.Controls.Remove(row.address);
                            pastCustomerTable.Controls.Remove(row.city);
                            pastCustomerTable.Controls.Remove(row.state);
                            pastCustomerTable.Controls.Remove(row.zip);
                            pastCustomerTable.Controls.Remove(row.phone);
                            pastCustomerTable.Controls.Remove(row.type);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            foreach (var row in newCustomers)
            {
                db.Customers.InsertOnSubmit(row.customer);
            }
            db.SubmitChanges();
            this.Controls.Clear();
            loadCustomers();
        }
    }
}
