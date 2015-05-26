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
        List<SearchRow> _searchRows = new List<SearchRow>();
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
            foreach (var row in _searchRows)
            {
                searchResults.Controls.Remove(row.viewButton);
                searchResults.Controls.Remove(row.codeDate);
                searchResults.Controls.Remove(row.date);
                searchResults.Controls.Remove(row.product);
                searchResults.Controls.Remove(row.studentManager);
                searchResults.Controls.Remove(row.plantManager);
                searchResults.Controls.Remove(row.Status);
            }
        }

        private void search()
        {
            searchResults.Visible = false;
            clearTable();
            IOrderedEnumerable<ProductEntry> query = null;
            switch (searchType.SelectedIndex)
            {
                case 0:
                    query =
                       (from productEntries in db.ProductEntries
                        where SqlMethods.Like(productEntries.CodeDate, "%" + searchBox.Text + "%")
                        group productEntries by productEntries.ProductEntryId into entries
                        select entries.OrderByDescending(x => x.ProductEntryVersion).First()).ToList().OrderBy(x => x.Date);
                    break;
                case 1:
                    query =
                        (from productEntries in db.ProductEntries
                        where SqlMethods.Like(productEntries.Recipe.Name, "%" + searchBox.Text + "%")
                        group productEntries by productEntries.ProductEntryId into entries
                        select entries.OrderByDescending(x => x.ProductEntryVersion).First()).ToList().OrderBy(x => x.Date);
                    break;
                case 2:
                    query =
                        (from traces in db.Traceabilities
                        where SqlMethods.Like(traces.Inventory.LotCode, "%" + searchBox.Text + "%")
                        group traces.ProductEntry by traces.ProductEntry.ProductEntryId into entries
                        select entries.OrderByDescending(x => x.ProductEntryVersion).First()).ToList().OrderBy(x => x.Date);
                    break;
                case 3:
                    query =
                        (from productEntries in db.ProductEntries
                        where SqlMethods.Like(productEntries.Complete, "%N%")
                        group productEntries by productEntries.ProductEntryId into entries
                        select entries.OrderByDescending(x => x.ProductEntryVersion).First()).ToList().OrderBy(x => x.Date);
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
                _searchRows.Add(search);
                searchResults.Controls.Add(search.viewButton);
                searchResults.Controls.Add(search.codeDate);
                searchResults.Controls.Add(search.product);
                searchResults.Controls.Add(search.date);
                searchResults.Controls.Add(search.studentManager);
                searchResults.Controls.Add(search.plantManager);
                searchResults.Controls.Add(search.Status);
                Library.CenterPictureBox(search.Status);
                search.Status.Dock = DockStyle.Left;
            }
            searchResults.Visible = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            search();
        }

        private class SearchRow
        {
            public ProductEntry ProductEntry= null;
            public Button viewButton = new Button();
            public Label codeDate = new Label();
            public Label product = new Label();
            public Label date = new Label();
            public Label studentManager = new Label();
            public Label plantManager = new Label();        
            public PictureBox Status = new PictureBox();

            public SearchRow(ProductEntry entry, SearchControl s)
            {
                ProductEntry = entry;
                viewButton.Text = "View";
                viewButton.Click += View_Click;
                viewButton.UseVisualStyleBackColor = true;
                codeDate.AutoSize = true;
                codeDate.Text = entry.CodeDate;
                product.AutoSize = true;
                product.Text = entry.Recipe.Name;
                date.AutoSize = true;
                date.Text = ((DateTime)entry.Date).ToShortDateString();
                studentManager.AutoSize = true;
                studentManager.Text = entry.StudentManager;
                plantManager.AutoSize = true;
                plantManager.Text = entry.PlantManager;
                Status.Image = entry.Complete == "Y" ? Home.CheckMark : Home.XMark;
            }

            public void View_Click(object sender, EventArgs e)
            {
                Home.ChangeMainViewControl(new EditExistingProductEntryControl(ProductEntry.ProductEntryId));
                ((EditExistingProductEntryControl) Home.mainPanel).SelectedProductEntry.LoadSelectedRecipe();
            }
        }

        private void searchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchBox.Enabled = searchType.SelectedIndex != 3;
        }
    }
}
