using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PolyChocolates.Properties;

namespace PolyChocolates
{
    public partial class DynamicProductEntryControl : UserControl
    {

        private databaseDataContext _db;
        private List<ProductRow> _productRows;
        private List<ProductRow> _selectedRows; 

        public DynamicProductEntryControl()
        {
            InitializeComponent();

            _db = new databaseDataContext();
            _productRows = new List<ProductRow>();
            _productRows.Add(new ProductRow());
            AddProductRowToTable(_productRows.First());
            _selectedRows = new List<ProductRow>();
        }

        private void AddProductRowToTable(ProductRow row)
        {
            ProductionSummaryTable.Controls.Add(row.CheckBox);
            ProductionSummaryTable.Controls.Add(row.Product);
            ProductionSummaryTable.Controls.Add(row.CodeDate);
            ProductionSummaryTable.Controls.Add(row.NumPackaged);
            ProductionSummaryTable.Controls.Add(row.NumProduced);
            ProductionSummaryTable.Controls.Add(row.Downtime);
            ProductionSummaryTable.Controls.Add(row.Haacp);
            ProductionSummaryTable.Controls.Add(row.Quality);
            ProductionSummaryTable.Controls.Add(row.Traceability);
            ProductionSummaryTable.Controls.Add(row.Efficiency);
            ProductionSummaryTable.Controls.Add(row.Status);
        }

        private class ProductRow
        {
            public CheckBox CheckBox = new CheckBox();
            public ComboBox Product = new ComboBox();
            public TextBox CodeDate = new TextBox();
            public TextBox NumPackaged = new TextBox();
            public TextBox NumProduced = new TextBox();
            public TextBox Downtime = new TextBox();
            public PictureBox Haacp = new PictureBox();
            public Button Quality = new Button();
            public Button Traceability = new Button();
            public Button Efficiency = new Button();
            public PictureBox Status = new PictureBox();

            public ProductRow()
            {
                Haacp.Image = Home.BlankDocument;
                Quality.Text = "Quality";
                Traceability.Text = "Traceability";
                Efficiency.Text = "Efficiency";
                Status.Image = Home.XMark;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ProductRow row = new ProductRow();
            _productRows.Add(row);
            AddProductRowToTable(row);
        }
    }
}
