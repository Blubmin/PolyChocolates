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
    public partial class TraceabilityControl : UserControl
    {
        private databaseDataContext db = new databaseDataContext();
        public bool IsComplete = false;
        private List<InventoryRow> inventoryList;
        public List<TraceabilityRow> traceabilityList;
        
        public TraceabilityControl()
        {
            InitializeComponent();
            loadValues();
        }

        public TraceabilityControl(ProductEntry productEntry)
        {
            InitializeComponent();
            foreach (var row in productEntry.Traceabilities)
            {
                TraceabilityRow newRow = new TraceabilityRow(row.Inventory.Name, row.Inventory.Supplier, row.Inventory.LotCode + "", row.Inventory.Unit, row.AmountUsed + "");
                traceabilityTable.Controls.Add(newRow.toRemove);
                traceabilityTable.Controls.Add(newRow.item);
                traceabilityTable.Controls.Add(newRow.supplier);
                traceabilityTable.Controls.Add(newRow.lotCode);
                traceabilityTable.Controls.Add(newRow.unit);
                traceabilityTable.Controls.Add(newRow.amountUsed);
            }
        }

        public TraceabilityControl(ProductEntry productEntry, bool editable)
        {
            InitializeComponent();
            loadValues();
            int i = 0;
            IOrderedEnumerable<Traceability> traceabilities = productEntry.Traceabilities.OrderBy(x => x.Inventory.Name);
            foreach (var row in inventoryList)
            {
                if (i < traceabilities.Count() && row.inv.InventoryId == traceabilities.ElementAt(i).Inventory.InventoryId)
                {
                    row.toAdd.Checked = true;
                    i++;
                }
            }
            addButton.PerformClick();    
            i = 0;
            foreach (var row in traceabilityList)
            {
                row.amountUsed.Text = traceabilities.ElementAt(i).AmountUsed.ToString();
                i++;
            }
        }

        private void loadValues()
        {
            traceabilityList = new List<TraceabilityRow>();
            inventoryList = new List<InventoryRow>();
            var query =
                from inv in db.Inventories
                orderby inv.Name
                where inv.Stock > 0 
                && inv.SnapshotDate == null 
                && inv.Enabled == "Y"
                && inv.Type == "raw"
                select inv;
            foreach (var inv in query)
            {
                InventoryRow row = new InventoryRow(inv);
                inventoryList.Add(row);
                inventoryTable.Controls.Add(row.toAdd);
                inventoryTable.Controls.Add(row.name);
                inventoryTable.Controls.Add(row.supplier);
                inventoryTable.Controls.Add(row.lotCode);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            IsComplete = false;
            Home.ChangeToPreviousControl();
        }

        private void submitTraceabilityButton_Click(object sender, EventArgs e)
        {
            IsComplete = true;
            Home.ChangeToPreviousControl();
        }

        public class InventoryRow
        {
            public Inventory inv;
            public CheckBox toAdd = new CheckBox();
            public Label name = new Label();
            public Label supplier = new Label();
            public Label lotCode = new Label();

            public InventoryRow(Inventory inv) : this(inv, inv.Name, inv.Supplier, inv.LotCode + "") { }

            public InventoryRow(TraceabilityRow row) : this(row.inv, row.item.Text, row.supplier.Text, row.lotCode.Text) { }

            private InventoryRow(Inventory inv, String name, String supplier, String lotCode)
            {
                this.inv = inv;
                this.toAdd.AutoSize = true;
                this.toAdd.Text = "";
                this.name.AutoSize = true;
                this.name.Text = name;
                this.name.Dock = DockStyle.Fill;
                this.name.Padding = new Padding(3);
                this.supplier.AutoSize = true;
                this.supplier.Text = supplier;
                this.supplier.Dock = DockStyle.Fill;
                this.supplier.Padding = new Padding(3);
                this.lotCode.AutoSize = true;
                this.lotCode.Text = lotCode;
                this.lotCode.Dock = DockStyle.Fill;
                this.lotCode.Padding = new Padding(3);
            }
        }

        public class TraceabilityRow
        {
            public Inventory inv;
            public CheckBox toRemove = new CheckBox();
            public Label item = new Label();
            public Label supplier = new Label();
            public Label lotCode = new Label();
            public Label unit = new Label();
            public TextBox amountUsed = new TextBox();

            public TraceabilityRow(InventoryRow row)
            {
                inv = row.inv;
                this.toRemove.AutoSize = true;
                this.toRemove.Text = "";
                this.item = row.name;
                this.lotCode = row.lotCode;
                this.supplier = row.supplier;
                this.unit.AutoSize = true;
                this.unit.Text = inv.Unit;
                this.unit.Dock = DockStyle.Fill;
                this.amountUsed.Text = "0";
                this.amountUsed.Dock = DockStyle.Fill;
                this.amountUsed.Leave += new EventHandler(Library.onlyAllowFloats);
            }

            public TraceabilityRow(String item, String supplier, String lotCode, String units, String amountUsed)
            {
                this.item.Text = item;
                this.supplier.Text = supplier;
                this.lotCode.Text = lotCode;
                this.unit.Text = units;
                this.amountUsed.Text = amountUsed;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            List<InventoryRow> toRemove = new List<InventoryRow>();
            foreach (var row in inventoryList)
            {
                if (row.toAdd.Checked)
                {
                    TraceabilityRow newRow = new TraceabilityRow(row);
                    traceabilityList.Add(newRow);
                    traceabilityTable.Controls.Add(newRow.toRemove);
                    traceabilityTable.Controls.Add(newRow.item);
                    traceabilityTable.Controls.Add(newRow.supplier);
                    traceabilityTable.Controls.Add(newRow.lotCode);
                    traceabilityTable.Controls.Add(newRow.unit);
                    traceabilityTable.Controls.Add(newRow.amountUsed);
                    toRemove.Add(row);

                    TableLayoutRowStyleCollection styles = traceabilityTable.RowStyles;
                    foreach (RowStyle style in styles)
                    {
                        style.SizeType = SizeType.Absolute;
                        style.Height = 15;
                    }
                }
            }


            foreach (var row in toRemove)
            {
                inventoryTable.Controls.Remove(row.toAdd);
                inventoryList.Remove(row);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            List<TraceabilityRow> toRemove = new List<TraceabilityRow>();
            foreach (var row in traceabilityList)
            {
                if (row.toRemove.Checked)
                {
                    InventoryRow newRow = new InventoryRow(row);
                    inventoryTable.Controls.Add(newRow.toAdd);
                    inventoryTable.Controls.Add(newRow.name);
                    inventoryTable.Controls.Add(newRow.supplier);
                    inventoryTable.Controls.Add(newRow.lotCode);
                    inventoryList.Add(newRow);
                    toRemove.Add(row);
                }
            }
            foreach (var row in toRemove)
            {
                traceabilityTable.Controls.Remove(row.toRemove);
                traceabilityTable.Controls.Remove(row.item);
                traceabilityTable.Controls.Remove(row.supplier);
                traceabilityTable.Controls.Remove(row.lotCode);
                traceabilityTable.Controls.Remove(row.unit);
                traceabilityTable.Controls.Remove(row.amountUsed);
                traceabilityList.Remove(row);
            }
        }

        public void reset()
        {
            foreach(var row in traceabilityList)
            {
                row.toRemove.Checked = true;
            }
            removeButton_Click(null, null);
        }
    }
}