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
    public partial class SearchControl : UserControl
    {
        databaseDataContext db = new databaseDataContext();
        Home home;

        public SearchControl(Home home)
        {
            this.home = home;
            InitializeComponent();
            searchType.SelectedIndex = 0;
            clearTable();
        }

        public void clearTable()
        {
            Font bolded = new Font(label1.Font, FontStyle.Bold);

            Label LotCode = new Label();
            LotCode.AutoSize = true;
            LotCode.Font = bolded;
            LotCode.Text = "Code Date";
            Label Product = new Label();
            Product.AutoSize = true;
            Product.Font = bolded;
            Product.Text = "Product";
            Label Date = new Label();
            Date.AutoSize = true;
            Date.Font = bolded;
            Date.Text = "Date";
            Label Student = new Label();
            Student.AutoSize = true;
            Student.Font = bolded;
            Student.Text = "Student Manager";
            Label Manager = new Label();
            Manager.AutoSize = true;
            Manager.Font = bolded;
            Manager.Text = "Pilot Manager";

            searchResults.Controls.Clear();
            searchResults.Controls.Add(LotCode);
            searchResults.Controls.Add(Product);
            searchResults.Controls.Add(Date);
            searchResults.Controls.Add(Student);
            searchResults.Controls.Add(Manager);
        }

        private void search()
        {
            searchResults.Visible = false;
            clearTable();
            IQueryable<ProductEntry> query = null;
            switch (searchType.SelectedIndex)
            {
                case 0:
                    query =
                        from productEntries in db.ProductEntries
                        where SqlMethods.Like(productEntries.CodeDate, "%" + searchBox.Text + "%")
                        orderby productEntries.Date descending
                        select productEntries;
                    break;
                case 1:
                    query =
                        from productEntries in db.ProductEntries
                        where SqlMethods.Like(productEntries.Recipe.Name, "%" + searchBox.Text + "%")
                        orderby productEntries.Date descending
                        select productEntries;
                    break;
                case 2:
                    query =
                        from traces in db.Traceabilities
                        where SqlMethods.Like(traces.Inventory.LotCode, "%" + searchBox.Text + "%")
                        orderby traces.ProductEntry.Date descending
                        select traces.ProductEntry;
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
            foreach (var pe in query)
            {
                SearchRow search = new SearchRow(pe, this);
                search.codeDate.Click += new EventHandler(codedate_Click);
                searchResults.Controls.Add(search.codeDate);
                searchResults.Controls.Add(search.product);
                searchResults.Controls.Add(search.date);
                searchResults.Controls.Add(search.studentManager);
                searchResults.Controls.Add(search.plantManager);
            }
            searchResults.Controls.Add(new Label());
            searchResults.Visible = true;
        }

        private void codedate_Click(object sender, EventArgs e)
        {

            Label theLbl = (Label)sender;
            theLbl.ForeColor = Color.FromArgb(102, 51, 102);

            SearchEntry se = new SearchEntry(theLbl.Text);
            se.ShowDialog();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            search();
        }

        private class SearchRow
        {
            public Label codeDate = new Label();
            public Label product = new Label();
            public Label date = new Label();
            public Label studentManager = new Label();
            public Label plantManager = new Label();
            

            public SearchRow(ProductEntry entry, SearchControl s)
            {
                codeDate.AutoSize = true;
                codeDate.Font = new Font(s.searchResults.Font, FontStyle.Bold | FontStyle.Underline);
                codeDate.ForeColor = Color.FromArgb(6, 69, 173);
                codeDate.Cursor = Cursors.Hand;
                codeDate.Text = entry.CodeDate;
                product.AutoSize = true;
                product.Text = entry.Recipe.Name;
                date.AutoSize = true;
                date.Text = ((DateTime)entry.Date).ToShortDateString();
                studentManager.AutoSize = true;
                studentManager.Text = entry.StudentManager;
                plantManager.AutoSize = true;
                plantManager.Text = entry.PlantManager;
            }
        }
    }
}
