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

        private List<ProductRow> _productRows;

        public DynamicProductEntryControl()
        {
            InitializeComponent();

            _productRows = new List<ProductRow>();
            AddNewProductRow();
        }

        public DynamicProductEntryControl(ProductEntry productEntry)
        {
            InitializeComponent();

            databaseDataContext db = new databaseDataContext();

        }

        private void AddNewProductRow()
        {
            ProductRow row = new ProductRow();
            _productRows.Add(row);
            AddProductRowToTable(row);
            Library.CenterPictureBox(row.HaacpPic);
            Library.CenterPictureBox(row.Status);
        }

        private void AddProductRowToTable(ProductRow row)
        {
            ProductionSummaryTable.Controls.AddRange(row.Controls);
        }

        public class ProductRow
        {
            public Control[] Controls = new Control[11];
            public CheckBox CheckBox = new CheckBox();
            public ComboBox Product = new ComboBox();
            public TextBox CodeDate = new TextBox();
            public TextBox NumPackaged = new TextBox();
            public TextBox NumProduced = new TextBox();
            public TextBox Downtime = new TextBox();
            public PictureBox HaacpPic = new PictureBox();
            public byte[] HaacpBytes = null;
            public Button QualityButton = new Button();
            public UserControl ChocolateQualityControl = null;
            public UserControl GenericQualityControl = null;
            public Button TraceabilityButton = new Button();
            public UserControl TraceabilityControl = null;
            public Button EfficiencyButton = new Button();
            public UserControl EfficiencyControl = null;
            public PictureBox Status = new PictureBox();

            public ProductRow()
            {
                Init();
            }

            private void Init()
            {
                Controls[0] = CheckBox;
                Controls[1] = Product;
                Controls[2] = CodeDate;
                Controls[3] = NumPackaged;
                Controls[4] = NumProduced;
                Controls[5] = Downtime;
                Controls[6] = HaacpPic;
                Controls[7] = QualityButton;
                Controls[8] = TraceabilityButton;
                Controls[9] = EfficiencyButton;
                Controls[10] = Status;

                // Sets all table controls to fill
                foreach (var control in Controls)
                    control.Dock = DockStyle.Fill;

                // Product Dropdown Init
                databaseDataContext db = new databaseDataContext();
                var recipes = 
                    from recipe in db.Recipes 
                    select recipe;
                Product.DataSource = recipes;
                Product.DisplayMember = "Name";
                Product.Width = 215;
                Product.SelectedIndexChanged += ProductChanged;

                // Haacp Init
                HaacpPic.Image = Home.BlankDocument;
                HaacpPic.Click += AttachHaacpWindow;
                HaacpPic.VisibleChanged += LoadCoaIcon;

                // Quality Button Init
                QualityButton.Text = "Quality";
                QualityButton.Enabled = false;
                QualityButton.UseVisualStyleBackColor = true;
                QualityButton.Click += QuialityButton_Click;

                // Traceability Button Init
                TraceabilityButton.Text = "Traceability";
                TraceabilityButton.Enabled = false;
                TraceabilityButton.UseVisualStyleBackColor = true;
                TraceabilityButton.Click += TraceabilityButton_Click;

                // Efficiency Button Init
                EfficiencyButton.Text = "Efficiency";
                EfficiencyButton.Enabled = false;
                EfficiencyButton.UseVisualStyleBackColor = true;
                EfficiencyButton.Click += EfficiencyButton_Click;

                // Status Icon Init
                Status.Image = Home.XMark;
            }

            private void QuialityButton_Click(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe) Product.SelectedItem;
                if (selectedRecipe.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    if (ChocolateQualityControl == null)
                    {
                        ChocolateQualityControl = new ChocolateQualityControl();
                        ChocolateQualityControl.Location = Home.ControlStartingPoint;
                    }
                    Home.ChangeMainViewControl(ChocolateQualityControl);
                }
                else
                {
                    if (GenericQualityControl == null)
                    {
                        GenericQualityControl = new GenericQualityControl(selectedRecipe);
                        GenericQualityControl.Location = Home.ControlStartingPoint;
                    }
                    Home.ChangeMainViewControl(GenericQualityControl);
                }
            }

            private void TraceabilityButton_Click(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe)Product.SelectedItem;
                if (TraceabilityButton.Enabled && TraceabilityControl == null)
                {
                    TraceabilityControl = new TraceabilityControl();
                    TraceabilityControl.Location = Home.ControlStartingPoint;
                }
                Home.ChangeMainViewControl(TraceabilityControl);
            }

            private void EfficiencyButton_Click(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe)Product.SelectedItem;
                if (EfficiencyControl == null)
                {
                    EfficiencyControl = new GenericEfficiencyControl(selectedRecipe);
                    EfficiencyControl.Location = Home.ControlStartingPoint;
                }
                Home.ChangeMainViewControl(EfficiencyControl);
            }

            private void ProductChanged(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe) Product.SelectedItem;
                QualityButton.Enabled = selectedRecipe.QualityControlId > Library.CHOCOLATE_QUALITY_CONTROL;
                TraceabilityButton.Enabled = selectedRecipe.TraceabilityRequired == "Y";
                EfficiencyButton.Enabled = selectedRecipe.EfficiencyRequired == "Y";
            }

            private void AttachHaacpWindow(object sender, EventArgs e)
            {
                HACCP haacp = new HACCP(this);
                haacp.ShowDialog();
                HaacpPic.Image = HaacpBytes != null ? Home.Document : Home.BlankDocument;
            }

            private void LoadCoaIcon(object sender, EventArgs e)
            {
                if (HaacpBytes != null && HaacpBytes.Length > 0)
                    HaacpPic.Image = Home.Document;
                else
                    HaacpPic.Image = Home.BlankDocument;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ProductionSummaryTable.Visible = false;
            AddNewProductRow();
            ProductionSummaryTable.Visible = true;
        }

        private void DeleteRowsButton_Click(object sender, EventArgs e)
        {
            ProductionSummaryTable.Visible = false;
            List<ProductRow> toDelete = new List<ProductRow>();

            foreach (var row in _productRows)
            {
                if (row.CheckBox.Checked)
                    toDelete.Add(row);
            }

            foreach (var row in toDelete)
            {
                _productRows.Remove(row);
                foreach (var control in row.Controls)
                    ProductionSummaryTable.Controls.Remove(control);
            }
            ProductionSummaryTable.Refresh();
            ProductionSummaryTable.Visible = true;
        }
    }
}
