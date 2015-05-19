using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace PolyChocolates
{
    public partial class InventoryControl : UserControl
    {
        public static Image document = Image.FromFile("../../IconImages/document.png");
        public static Image blankDocument = Image.FromFile("../../IconImages/blankDocument.png");

        Home home;
        databaseDataContext db = new databaseDataContext();
        Dictionary<InventoryRow, Inventory> existingInventory = new Dictionary<InventoryRow, Inventory>();

        List<InventoryRow> rawMaterialsList = new List<InventoryRow>();
        List<InventoryRow> packagingMaterialsList = new List<InventoryRow>();
        List<InventoryRow> finishedProductsList = new List<InventoryRow>();

        public InventoryControl(Home home)
        {
            InitializeComponent();
            this.home = home;
            setupExistingInventory();
        }

        private void setupExistingInventory()
        {
            removeSelectedRawMaterials.Click += new EventHandler(updateRawMaterialsInventoryAssetsTotal);
            removeSelectedPackagingMaterials.Click += new EventHandler(updatePackagingMaterialsInventoryAssetsTotal);
            removeSelectedFinishedProducts.Click += new EventHandler(updateFinishedProductInventoryAssetsTotal);

            var query =
                from existing in db.Inventories
                where existing.SnapshotDate == null &&
                existing.Enabled == "Y"
                select existing;

            foreach (var dbObject in query)
            {
                InventoryRow existingRow = new InventoryRow();

                existingRow.item.Text = dbObject.Name;
                existingRow.supplier.Text = dbObject.Supplier;
                existingRow.lotCode.Text = dbObject.LotCode;
                existingRow.units.Text = dbObject.Unit;
                existingRow.pricePerUnit.Text = dbObject.PricePerUnit + "";
                existingRow.stock.Text = dbObject.Stock + "";
                existingRow.predictedUsage.Text = dbObject.PredictedUsage + "";
                existingRow.actualUsage.Text = dbObject.ActualUsage + "";
                existingRow.coa = dbObject.Certificate.ToArray();
                existingRow.type = dbObject.Type;
                existingRow.previousStock = (double) dbObject.PreviousStock;
                //if (dbObject.Type.ToLower() == "finished")
                //{
                //    existingRow.supplier.Text = "Cal Poly";
                //    existingRow.lotCode.Text = 
                //}

                existingInventory.Add(existingRow, dbObject);
            }

            foreach (InventoryRow inventory in existingInventory.Keys)
            {
                TableLayoutPanel correctTable;
                switch (inventory.type.ToLower())
                {
                    case "raw":
                        correctTable = rawMaterialsTable;
                        inventory.pricePerUnit.Leave += new EventHandler(updateRawMaterialsInventoryAssetsTotal);
                        inventory.stock.Leave += new EventHandler(updateRawMaterialsInventoryAssetsTotal);
                        break;
                    case "packaging":
                        correctTable = packagingMaterialsTable;
                        inventory.pricePerUnit.Leave += new EventHandler(updatePackagingMaterialsInventoryAssetsTotal);
                        inventory.stock.Leave += new EventHandler(updatePackagingMaterialsInventoryAssetsTotal);
                        break;
                    case "finished":
                        correctTable = finishedProductTable;
                        inventory.pricePerUnit.Leave += new EventHandler(updateFinishedProductInventoryAssetsTotal);
                        inventory.stock.Leave += new EventHandler(updateFinishedProductInventoryAssetsTotal);
                        break;
                    default:
                        correctTable = rawMaterialsTable;
                        inventory.pricePerUnit.Leave += new EventHandler(updateRawMaterialsInventoryAssetsTotal);
                        inventory.stock.Leave += new EventHandler(updateRawMaterialsInventoryAssetsTotal);
                        break;
                }
                inventory.updateAssets(null, null);
                correctTable.Controls.Add(inventory.checkBox);
                correctTable.Controls.Add(inventory.picBox);
                correctTable.Controls.Add(inventory.item);
                correctTable.Controls.Add(inventory.supplier);
                correctTable.Controls.Add(inventory.lotCode);
                correctTable.Controls.Add(inventory.units);
                correctTable.Controls.Add(inventory.pricePerUnit);
                correctTable.Controls.Add(inventory.stock);
                correctTable.Controls.Add(inventory.inventoryAsset);
                correctTable.Controls.Add(inventory.predictedUsage);
                correctTable.Controls.Add(inventory.actualUsage);
                correctTable.Controls.Add(inventory.difference);
            }
            updateRawMaterialsInventoryAssetsTotal(null, null);
            updatePackagingMaterialsInventoryAssetsTotal(null, null);
            updateFinishedProductInventoryAssetsTotal(null, null);
        }

        public class InventoryRow
        {
            public CheckBox checkBox = new CheckBox();
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
            public String type = "";
            public byte[] coa = null;
            public double previousStock;

            public InventoryRow()
            {
                picBox.Dock = DockStyle.Fill;
                picBox.Height = 20;
                picBox.Margin = new Padding(0, 5, 0, 0);
                if (coa != null)
                    picBox.Image = InventoryControl.document;
                else
                    picBox.Image = InventoryControl.blankDocument;
                picBox.Click += new EventHandler(attachCOAWindow);
                picBox.VisibleChanged += new EventHandler(loadCOAIcon);

                item.Dock = DockStyle.Fill;
                supplier.Dock = DockStyle.Fill;
                lotCode.Dock = DockStyle.Fill;
                units.Text = "lbs";
                units.Dock = DockStyle.Fill;
                pricePerUnit.Text = "0";
                pricePerUnit.Dock = DockStyle.Fill;
                pricePerUnit.Leave += new EventHandler(Library.formatMoney);
                pricePerUnit.Leave += new EventHandler(updateAssets);
                Library.formatMoney(pricePerUnit, null);
                stock.Text = "0";
                stock.Dock = DockStyle.Fill;
                stock.Leave += new EventHandler(Library.onlyAllowFloats);
                stock.Leave += new EventHandler(updateAssets);
                stock.Validated += new EventHandler(updateActual);
                inventoryAsset.Text = "0";
                inventoryAsset.Dock = DockStyle.Fill;
                inventoryAsset.ReadOnly = true;
                predictedUsage.Text = "0";
                predictedUsage.ReadOnly = true;
                predictedUsage.Dock = DockStyle.Fill;
                predictedUsage.Leave += new EventHandler(Library.onlyAllowFloats);
                predictedUsage.TextChanged += new EventHandler(updateDifference);
                actualUsage.Text = "0";
                actualUsage.Dock = DockStyle.Fill;
                actualUsage.Leave += new EventHandler(Library.onlyAllowFloats);
                actualUsage.TextChanged += new EventHandler(updateDifference);
                actualUsage.ReadOnly = true;
                difference.Text = "0";
                difference.Dock = DockStyle.Fill;
                difference.ReadOnly = true;
                previousStock = 0;
            }

            private void updateDifference(object sender, EventArgs args)
            {
                double predicted = Convert.ToDouble(predictedUsage.Text);
                double actual = Convert.ToDouble(actualUsage.Text);
                difference.Text = (actual - predicted) + "";
            }

            public void updateAssets(object sender, EventArgs args)
            {
                double price = Convert.ToDouble(pricePerUnit.Text);
                double stock = Convert.ToDouble(this.stock.Text);
                inventoryAsset.Text = (price * stock) + "";
            }

            private void updateActual(object sender, EventArgs e)
            {
                double stock = Double.Parse(this.stock.Text);
                actualUsage.Text = (stock - previousStock) + "";
            }

            private void updatePredicted(object sender, EventArgs e)
            {
                double difference = Double.Parse(this.stock.Text) - previousStock;
                if (difference > 0)
                {
                    double predicted = Double.Parse(this.predictedUsage.Text);
                    predictedUsage.Text = difference + predicted + "";
                }
            }

            private void attachCOAWindow(object sender, EventArgs e)
            {
                COA coa = new COA(this);
                coa.ShowDialog();
                if (this.coa != null && this.coa.Length > 0)
                    picBox.Image = InventoryControl.document;
                else
                    picBox.Image = InventoryControl.blankDocument;
            }
            private void loadCOAIcon(object sender, EventArgs e)
            {
                if (this.coa != null && this.coa.Length > 0)
                    picBox.Image = InventoryControl.document;
                else
                    picBox.Image = InventoryControl.blankDocument;
            }
        }

        private void rawMaterialsButton_Click(object sender, EventArgs e)
        {
            InitialStock initialStock = new InitialStock();
            initialStock.ShowDialog();
            if (initialStock.okayPressed)
            {
                InventoryRow row = new InventoryRow();
                rawMaterialsList.Add(row);
                rawMaterialsTable.Controls.Add(row.checkBox);
                rawMaterialsTable.Controls.Add(row.picBox);
                rawMaterialsTable.Controls.Add(row.item);
                rawMaterialsTable.Controls.Add(row.supplier);
                rawMaterialsTable.Controls.Add(row.lotCode);
                rawMaterialsTable.Controls.Add(row.units);
                rawMaterialsTable.Controls.Add(row.pricePerUnit);
                row.pricePerUnit.Leave += new EventHandler(updateRawMaterialsInventoryAssetsTotal);
                rawMaterialsTable.Controls.Add(row.stock);
                row.stock.Leave += new EventHandler(updateRawMaterialsInventoryAssetsTotal);
                row.stock.Text = initialStock.value;
                rawMaterialsTable.Controls.Add(row.inventoryAsset);
                rawMaterialsTable.Controls.Add(row.predictedUsage);
                row.predictedUsage.Text = initialStock.value;
                rawMaterialsTable.Controls.Add(row.actualUsage);
                row.actualUsage.Text = initialStock.value;
                rawMaterialsTable.Controls.Add(row.difference);
            }
        }
        
        private void updateRawMaterialsInventoryAssetsTotal(object sender, EventArgs args)
        {
            double total = 0;
            foreach (InventoryRow row in rawMaterialsList)
            {
                total += Convert.ToDouble(row.inventoryAsset.Text);
            }
            foreach (InventoryRow inventory in existingInventory.Keys)
            {
                if (inventory.type.ToLower() == "raw")
                    total += Convert.ToDouble(inventory.inventoryAsset.Text);
            }
            rawMaterialsTotalAssets.Text = "$" + total + "";
        }

        private void updatePackagingMaterialsInventoryAssetsTotal(object sender, EventArgs args)
        {
            double total = 0;
            foreach (InventoryRow row in packagingMaterialsList)
            {
                total += Convert.ToDouble(row.inventoryAsset.Text);
            }
            foreach (InventoryRow inventory in existingInventory.Keys)
            {
                if (inventory.type.ToLower() == "packaging")
                    total += Convert.ToDouble(inventory.inventoryAsset.Text);
            }
            packagingMaterialsTotalAssets.Text = "$" + total + "";
        }

        private void updateFinishedProductInventoryAssetsTotal(object sender, EventArgs args)
        {
            double total = 0;
            foreach (InventoryRow row in finishedProductsList)
            {
                total += Convert.ToDouble(row.inventoryAsset.Text);
            }
            foreach (InventoryRow inventory in existingInventory.Keys)
            {
                if (inventory.type.ToLower() == "finished")
                    total += Convert.ToDouble(inventory.inventoryAsset.Text);
            }
            finishedProductTotalAssets.Text = "$" + total + "";
        }

        private void packagingMaterialsButton_Click(object sender, EventArgs e)
        {
            InitialStock initialStock = new InitialStock();
            initialStock.ShowDialog();
            if (initialStock.okayPressed)
            {
                InventoryRow row = new InventoryRow();
                packagingMaterialsList.Add(row);
                packagingMaterialsTable.Controls.Add(row.checkBox);
                packagingMaterialsTable.Controls.Add(row.picBox);
                packagingMaterialsTable.Controls.Add(row.item);
                packagingMaterialsTable.Controls.Add(row.supplier);
                packagingMaterialsTable.Controls.Add(row.lotCode);
                packagingMaterialsTable.Controls.Add(row.units);
                packagingMaterialsTable.Controls.Add(row.pricePerUnit);
                row.pricePerUnit.Leave += new EventHandler(updatePackagingMaterialsInventoryAssetsTotal);
                row.stock.Text = initialStock.value;
                packagingMaterialsTable.Controls.Add(row.stock);
                row.stock.Leave += new EventHandler(updatePackagingMaterialsInventoryAssetsTotal);
                packagingMaterialsTable.Controls.Add(row.inventoryAsset);
                packagingMaterialsTable.Controls.Add(row.predictedUsage);
                row.predictedUsage.Text = initialStock.value;
                packagingMaterialsTable.Controls.Add(row.actualUsage);
                row.actualUsage.Text = initialStock.value;
                packagingMaterialsTable.Controls.Add(row.difference);
            }
        }

        private void finishedProductButton_Click(object sender, EventArgs e)
        {
            InitialStock initialStock = new InitialStock();
            initialStock.ShowDialog();
            if (initialStock.okayPressed)
            {
                InventoryRow row = new InventoryRow();
                finishedProductsList.Add(row);
                finishedProductTable.Controls.Add(row.checkBox);
                finishedProductTable.Controls.Add(row.picBox);
                finishedProductTable.Controls.Add(row.item);
                finishedProductTable.Controls.Add(row.supplier);
                finishedProductTable.Controls.Add(row.lotCode);
                finishedProductTable.Controls.Add(row.units);
                finishedProductTable.Controls.Add(row.pricePerUnit);
                row.pricePerUnit.Leave += new EventHandler(updateFinishedProductInventoryAssetsTotal);
                row.stock.Text = initialStock.value;
                finishedProductTable.Controls.Add(row.stock);
                row.stock.Leave += new EventHandler(updateFinishedProductInventoryAssetsTotal);
                finishedProductTable.Controls.Add(row.inventoryAsset);
                finishedProductTable.Controls.Add(row.predictedUsage);
                row.predictedUsage.Text = initialStock.value;
                finishedProductTable.Controls.Add(row.actualUsage);
                row.actualUsage.Text = initialStock.value;
                finishedProductTable.Controls.Add(row.difference);
            }
        }

        private void removeSelectedRawMaterials_Click(object sender, EventArgs e)
        {
            List<InventoryRow> removeList = new List<InventoryRow>();

            foreach (InventoryRow row in existingInventory.Keys)
            {
                if (row.type == "raw" && row.checkBox.Checked)
                {
                    removeList.Add(row);
                }
            }

            foreach (InventoryRow row in rawMaterialsList)
            {
                if (row.checkBox.Checked)
                {
                    removeList.Add(row);
                }
            }
            foreach (InventoryRow row in removeList)
            {
                rawMaterialsTable.Controls.Remove(row.checkBox);
                rawMaterialsTable.Controls.Remove(row.picBox);
                rawMaterialsTable.Controls.Remove(row.item);
                rawMaterialsTable.Controls.Remove(row.supplier);
                rawMaterialsTable.Controls.Remove(row.lotCode);
                rawMaterialsTable.Controls.Remove(row.units);
                rawMaterialsTable.Controls.Remove(row.pricePerUnit);
                rawMaterialsTable.Controls.Remove(row.stock);
                rawMaterialsTable.Controls.Remove(row.inventoryAsset);
                rawMaterialsTable.Controls.Remove(row.predictedUsage);
                rawMaterialsTable.Controls.Remove(row.actualUsage);
                rawMaterialsTable.Controls.Remove(row.difference);
                if (existingInventory.Keys.Contains(row))
                {
                    existingInventory[row].Enabled = "N";
                    existingInventory.Remove(row);
                }
                else
                {
                    rawMaterialsList.Remove(row);
                }
            }

            removeList.Clear();

            updateFinishedProductInventoryAssetsTotal(null, null);
        }

        private void removeSelectedPackagingMaterials_Click(object sender, EventArgs e)
        {
            List<InventoryRow> removeList = new List<InventoryRow>();

            foreach (InventoryRow row in existingInventory.Keys)
            {
                if (row.type == "packaging" && row.checkBox.Checked)
                {
                    removeList.Add(row);
                }
            }

            foreach (InventoryRow row in packagingMaterialsList)
            {
                if (row.checkBox.Checked)
                {
                    removeList.Add(row);
                }
            }
            foreach (InventoryRow row in removeList)
            {
                packagingMaterialsTable.Controls.Remove(row.checkBox);
                packagingMaterialsTable.Controls.Remove(row.picBox);
                packagingMaterialsTable.Controls.Remove(row.item);
                packagingMaterialsTable.Controls.Remove(row.supplier);
                packagingMaterialsTable.Controls.Remove(row.lotCode);
                packagingMaterialsTable.Controls.Remove(row.units);
                packagingMaterialsTable.Controls.Remove(row.pricePerUnit);
                packagingMaterialsTable.Controls.Remove(row.stock);
                packagingMaterialsTable.Controls.Remove(row.inventoryAsset);
                packagingMaterialsTable.Controls.Remove(row.predictedUsage);
                packagingMaterialsTable.Controls.Remove(row.actualUsage);
                packagingMaterialsTable.Controls.Remove(row.difference);
                if (existingInventory.Keys.Contains(row))
                {
                    existingInventory[row].Enabled = "N";
                    existingInventory.Remove(row);
                }
                else
                {
                    packagingMaterialsList.Remove(row);
                }
            }

            removeList.Clear();

            updateFinishedProductInventoryAssetsTotal(null, null);
        }

        private void removeSelectedFinishedProducts_Click(object sender, EventArgs e)
        {
            List<InventoryRow> removeList = new List<InventoryRow>();

            foreach (InventoryRow row in existingInventory.Keys)
            {
                if (row.type == "finished" && row.checkBox.Checked)
                {
                    removeList.Add(row);
                }
            }

            foreach (InventoryRow row in finishedProductsList)
            {
                if (row.checkBox.Checked)
                {
                    removeList.Add(row);
                }
            }
            foreach (InventoryRow row in removeList)
            {
                finishedProductTable.Controls.Remove(row.checkBox);
                finishedProductTable.Controls.Remove(row.picBox);
                finishedProductTable.Controls.Remove(row.item);
                finishedProductTable.Controls.Remove(row.supplier);
                finishedProductTable.Controls.Remove(row.lotCode);
                finishedProductTable.Controls.Remove(row.units);
                finishedProductTable.Controls.Remove(row.pricePerUnit);
                finishedProductTable.Controls.Remove(row.stock);
                finishedProductTable.Controls.Remove(row.inventoryAsset);
                finishedProductTable.Controls.Remove(row.predictedUsage);
                finishedProductTable.Controls.Remove(row.actualUsage);
                finishedProductTable.Controls.Remove(row.difference);
                if (existingInventory.Keys.Contains(row))
                {
                    existingInventory[row].Enabled = "N";
                    existingInventory.Remove(row);
                }
                else
                {
                    finishedProductsList.Remove(row);
                }
            }
            removeList.Clear();

            updateFinishedProductInventoryAssetsTotal(null, null);
        }

        private void submitSnapshotButton_Click(object sender, EventArgs e)
        {
            DateTime date = System.DateTime.Now;
            //System.Threading.Thread.Sleep(1000);

            SaveChanges_Click(null, null);

            foreach (InventoryRow row in existingInventory.Keys)
            {
                Inventory newEntry = new Inventory()
                {
                    Name = existingInventory[row].Name,
                    Supplier = existingInventory[row].Supplier,
                    LotCode = existingInventory[row].LotCode,
                    Unit = existingInventory[row].Unit,
                    PricePerUnit = existingInventory[row].PricePerUnit,
                    Stock = existingInventory[row].Stock,
                    PredictedUsage = existingInventory[row].PredictedUsage,
                    ActualUsage = existingInventory[row].ActualUsage,
                    Type = existingInventory[row].Type,
                    Certificate = existingInventory[row].Certificate,
                    SnapshotDate = date
                };
                db.Inventories.InsertOnSubmit(newEntry);
            }
            home.refreshPastInventory();
            if (sender != null)
                MessageBox.Show("A snapshot of the currently displayed inventory was successfully saved!");
            db.SubmitChanges();
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            foreach(KeyValuePair<InventoryRow, Inventory> row in existingInventory)
            {
                row.Value.Name = row.Key.item.Text;
                row.Value.Supplier = row.Key.supplier.Text;
                row.Value.LotCode = row.Key.lotCode.Text;
                row.Value.Unit = row.Key.units.Text;
                row.Value.PricePerUnit = Convert.ToDecimal(row.Key.pricePerUnit.Text);
                row.Value.Stock = Convert.ToDouble(row.Key.stock.Text);
                row.Value.PredictedUsage = Convert.ToDouble(row.Key.predictedUsage.Text);
                row.Value.ActualUsage = Convert.ToDouble(row.Key.actualUsage.Text);
                row.Value.Certificate = row.Key.coa;
                row.Value.PreviousStock = row.Key.previousStock;
            }

            foreach (InventoryRow row in rawMaterialsList)
            {
                Inventory newEntry = new Inventory()
                {
                    Enabled = "Y",
                    Name = row.item.Text,
                    Supplier = row.supplier.Text,
                    LotCode = row.lotCode.Text,
                    Unit = row.units.Text,
                    PricePerUnit = Convert.ToDecimal(row.pricePerUnit.Text),
                    Stock = Convert.ToDouble(row.stock.Text),
                    PredictedUsage = Convert.ToDouble(row.predictedUsage.Text),
                    ActualUsage = Convert.ToDouble(row.actualUsage.Text),
                    Type = "raw",
                    SnapshotDate = null,
                    Certificate = row.coa,
                    PreviousStock = row.previousStock
                };
                db.Inventories.InsertOnSubmit(newEntry);
                existingInventory.Add(row, newEntry);
            }
            foreach (InventoryRow row in packagingMaterialsList)
            {
                Inventory newEntry = new Inventory()
                {
                    Enabled = "Y",
                    Name = row.item.Text,
                    Supplier = row.supplier.Text,
                    LotCode = row.lotCode.Text,
                    Unit = row.units.Text,
                    PricePerUnit = Convert.ToDecimal(row.pricePerUnit.Text),
                    Stock = Convert.ToDouble(row.stock.Text),
                    PredictedUsage = Convert.ToDouble(row.predictedUsage.Text),
                    ActualUsage = Convert.ToDouble(row.actualUsage.Text),
                    Type = "packaging",
                    SnapshotDate = null,
                    Certificate = row.coa,
                    PreviousStock = row.previousStock
                };
                db.Inventories.InsertOnSubmit(newEntry);
                existingInventory.Add(row, newEntry);
            }
            foreach (InventoryRow row in finishedProductsList)
            {
                Inventory newEntry = new Inventory()
                {
                    Enabled = "Y",
                    Name = row.item.Text,
                    Supplier = row.supplier.Text,
                    LotCode = row.lotCode.Text,
                    Unit = row.units.Text,
                    PricePerUnit = Convert.ToDecimal(row.pricePerUnit.Text),
                    Stock = Convert.ToDouble(row.stock.Text),
                    PredictedUsage = Convert.ToDouble(row.predictedUsage.Text),
                    ActualUsage = Convert.ToDouble(row.actualUsage.Text),
                    Type = "finished",
                    SnapshotDate = null,
                    Certificate = row.coa,
                    PreviousStock = row.previousStock
                };
                db.Inventories.InsertOnSubmit(newEntry);
                existingInventory.Add(row, newEntry);
            }
            rawMaterialsList.Clear();
            packagingMaterialsList.Clear();
            finishedProductsList.Clear();

            db.SubmitChanges();
            home.refreshProductEntry();
            home.refreshInvoice();

            for (int row = 0; row < Home.traceabilityControls.Length; row++)
            {
                home.Controls.Remove(Home.traceabilityControls[row]);
                Home.traceabilityControls[row] = null;
            }

            if (sender != null)
            {
                MessageBox.Show("Your running inventory was succesfully updated!");
            }
        }

        private void rawClearPredicted_Click(object sender, EventArgs e)
        {
            foreach (InventoryRow row in existingInventory.Keys)
            {
                if (row.type == "raw" && row.checkBox.Checked)
                {
                    row.predictedUsage.Text = "0";
                    row.checkBox.Checked = false;
                }
            }

            foreach (InventoryRow row in rawMaterialsList)
            {
                if (row.checkBox.Checked)
                {
                    row.predictedUsage.Text = "0";
                    row.checkBox.Checked = false;
                }
            }
        }

        private void packagingClearPredicted_Click(object sender, EventArgs e)
        {
            foreach (InventoryRow row in existingInventory.Keys)
            {
                if (row.type == "packaging" && row.checkBox.Checked)
                {
                    row.predictedUsage.Text = "0";
                    row.checkBox.Checked = false;
                }
            }

            foreach (InventoryRow row in packagingMaterialsList)
            {
                if (row.checkBox.Checked)
                {
                    row.predictedUsage.Text = "0";
                    row.checkBox.Checked = false;
                }
            }
        }

        private void finishedClearPredicted_Click(object sender, EventArgs e)
        {
            foreach (InventoryRow row in existingInventory.Keys)
            {
                if (row.type == "finished" && row.checkBox.Checked)
                {
                    row.predictedUsage.Text = "0";
                    row.checkBox.Checked = false;
                }
            }

            foreach (InventoryRow row in finishedProductsList)
            {
                if (row.checkBox.Checked)
                {
                    row.predictedUsage.Text = "0";
                    row.checkBox.Checked = false;
                }
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You will lose any unsaved changes to your running inventory, would you like to proceed?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                home.refreshInventory();
            }
        }

        private void monthlyReport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are about to create an inventory report. Doing so will reset the predicted inventory. Would you like to proceed?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                submitSnapshotButton_Click(null, null);
                foreach (InventoryRow row in existingInventory.Keys)
                {
                    existingInventory[row].PreviousStock = existingInventory[row].Stock;
                    existingInventory[row].PredictedUsage = 0;
                    existingInventory[row].ActualUsage = 0;
                }
                db.SubmitChanges();
                home.refreshInventory();
            }
        }
    }
}