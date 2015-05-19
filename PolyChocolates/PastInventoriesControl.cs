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
    public partial class PastInventoriesControl : UserControl
    {
        Label currentSelected = null;
        databaseDataContext db = new databaseDataContext();
        Dictionary<Label, DateTime> dateMap = new Dictionary<Label, DateTime>();
        public PastInventoriesControl()
        {
            InitializeComponent();

            setupSnapshotList();
        }

        private void setupSnapshotList()
        {
            inventoriesList.Controls.Clear();


            var query =
               from dates in db.Inventories
               where dates.SnapshotDate != null
               orderby dates.SnapshotDate
               select dates.SnapshotDate;

            HashSet<String> set = new HashSet<String>();

            foreach (DateTime date in query)
            {
                if (set.Add(date.ToString()))
                {
                    Label l = new Label();
                    l.Text = date.ToString();
                    l.BackColor = Color.White;
                    l.Dock = DockStyle.Fill;
                    l.Click += new EventHandler(onClick);
                    inventoriesList.Controls.Add(l);
                    dateMap.Add(l, date);
                }
            }
            inventoriesList.Controls.Add(new Label());
        }

        public class InventoryRow
        {
            public PictureBox picBox = new PictureBox();
            public TextBox item = new TextBox();
            public TextBox supplier = new TextBox();
            public TextBox lotCode = new TextBox();
            public TextBox units = new TextBox();
            public TextBox pricePerUnit = new TextBox();
            public TextBox stock = new TextBox();
            public TextBox inventoryAsset = new TextBox();
            public TextBox predictedUsage = new TextBox();
            public TextBox actualUsage = new TextBox();
            public TextBox difference = new TextBox();
            public byte[] coa = null;

            public InventoryRow(String item, String supplier, String lotCode, String units, double pricePerUnit,
                double stock, double predictedUsage, double actualUsage, byte[] coa)
            {
                this.item.Text = item;
                this.supplier.Text = supplier;
                this.lotCode.Text = lotCode;
                this.units.Text = units;
                this.pricePerUnit.Text = pricePerUnit + "";
                this.stock.Text = stock + "";
                this.inventoryAsset.Text = (pricePerUnit * stock) + "";
                this.predictedUsage.Text = predictedUsage + "";
                this.actualUsage.Text = actualUsage + "";
                this.difference.Text = (predictedUsage - actualUsage) + "";
                this.coa = coa;

                picBox.Dock = DockStyle.Fill;
                picBox.Height = 20;
                picBox.Margin = new Padding(3, 3, 0, 0);
                if (coa.Length > 0)
                {
                    picBox.Image = InventoryControl.document;
                    picBox.Click += new EventHandler(attachCOAWindow);
                    }
                else
                    picBox.Image = InventoryControl.blankDocument;
                
                this.item.Dock = DockStyle.Fill;
                this.supplier.Dock = DockStyle.Fill;
                this.lotCode.Dock = DockStyle.Fill;
                this.units.Dock = DockStyle.Fill;
                this.pricePerUnit.Dock = DockStyle.Fill;
                this.stock.Dock = DockStyle.Fill;
                this.inventoryAsset.Dock = DockStyle.Fill;
                this.predictedUsage.Dock = DockStyle.Fill;
                this.actualUsage.Dock = DockStyle.Fill;
                this.difference.Dock = DockStyle.Fill;

                this.item.ReadOnly = true;
                this.supplier.ReadOnly = true;
                this.lotCode.ReadOnly = true;
                this.units.ReadOnly = true;
                this.pricePerUnit.ReadOnly = true;
                this.stock.ReadOnly = true;
                this.inventoryAsset.ReadOnly = true;
                this.predictedUsage.ReadOnly = true;
                this.actualUsage.ReadOnly = true;
                this.difference.ReadOnly = true;
            }
            private void attachCOAWindow(object sender, EventArgs e)
            {
                COA coa = new COA(this);
                coa.ShowDialog();
            }
        }


        private void setupPastInventoryView(DateTime date)
        {
            rawMaterialsTable.Controls.Clear();
            packagingMaterialsTable.Controls.Clear();
            finishedProductTable.Controls.Clear();

            var query =
                from inventories in db.Inventories
                where SqlMethods.DateDiffSecond(inventories.SnapshotDate, date) == 0
                orderby inventories.Name
                select inventories;

            double rawTotalAssets = 0;
            double packagingTotalAssets = 0;
            double finishedTotalAssets = 0;

            foreach (var inventory in query)
            {
                InventoryRow row = new InventoryRow(inventory.Name, inventory.Supplier, inventory.LotCode, inventory.Unit, Convert.ToDouble(inventory.PricePerUnit), (Double) inventory.Stock, (Double) inventory.PredictedUsage, (Double) inventory.ActualUsage, inventory.Certificate.ToArray());

                TableLayoutPanel correctTable;
                switch (inventory.Type.ToLower())
                {
                    case "raw":
                        correctTable = rawMaterialsTable;
                        rawTotalAssets += Convert.ToDouble(row.inventoryAsset.Text);
                        break;
                    case "packaging":
                        correctTable = packagingMaterialsTable;
                        packagingTotalAssets += Convert.ToDouble(row.inventoryAsset.Text);
                        break;
                    case "finished":
                        correctTable = finishedProductTable;
                        finishedTotalAssets += Convert.ToDouble(row.inventoryAsset.Text);
                        break;
                    default:
                        correctTable = rawMaterialsTable;
                        rawTotalAssets += Convert.ToDouble(row.inventoryAsset.Text);
                        break;
                }
                correctTable.Controls.Add(row.picBox);
                correctTable.Controls.Add(row.item);
                correctTable.Controls.Add(row.supplier);
                correctTable.Controls.Add(row.lotCode);
                correctTable.Controls.Add(row.units);
                correctTable.Controls.Add(row.pricePerUnit);
                correctTable.Controls.Add(row.stock);
                correctTable.Controls.Add(row.inventoryAsset);
                correctTable.Controls.Add(row.predictedUsage);
                correctTable.Controls.Add(row.actualUsage);
                correctTable.Controls.Add(row.difference);
            }
            rawMaterialsTotalAssets.Text = rawTotalAssets + "";
            packagingMaterialsTotalAssets.Text = packagingTotalAssets + "";
            finishedProductTotalAssets.Text = finishedTotalAssets + ""; 
        }

        private void onClick(object sender, EventArgs args)
        {
            if (currentSelected != null)
                currentSelected.BackColor = Color.White;

            ((Label)sender).BackColor = Color.Gainsboro;
            currentSelected = (Label)sender;
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            if (currentSelected != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you would like to delete this Inventory Snapshot? This cannot be undone.",
                    "Delete Confirmation", MessageBoxButtons.YesNo);

                if (result.Equals(DialogResult.Yes))
                {
                    inventoriesList.Controls.Remove(currentSelected);

                    var query =
                        from inventory in db.Inventories
                        where SqlMethods.DateDiffSecond(inventory.SnapshotDate, dateMap[currentSelected]) == 0
                        select inventory;
                    db.Inventories.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                    currentSelected = null;
                }
            }
            rawMaterialsTable.Controls.Clear();
            packagingMaterialsTable.Controls.Clear();
            finishedProductTable.Controls.Clear();
            
        }

        private void viewSelectedButton_Click(object sender, EventArgs e)
        {
            container.Visible = false;
            if (currentSelected != null)
                setupPastInventoryView(dateMap[currentSelected]);
            container.Visible = true;
        }

        private void saveDocumentButton_Click(object sender, EventArgs e)
        {
            if (currentSelected != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = "inventory_" + currentSelected.Text.Replace("/", ".").Replace(":", "");// Default file name
                dialog.DefaultExt = ".jpg";// Default file extension
                dialog.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //int previousWindowHeight = this.Height;
                    //int previousContainerHeight = container.Height;
                    //this.Height = ResultsTable.PreferredSize.Height;
                    //container.Height = ResultsTable.PreferredSize.Height;

                    Bitmap bmp = new Bitmap(this.container.Width, this.container.Height);
                    this.container.DrawToBitmap(bmp, new Rectangle(0, 0, this.container.Width, this.container.Height));

                    bmp.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                    //this.Height = previousWindowHeight;
                    //container.Height = previousContainerHeight;
                }
            }
        }
    }
}
