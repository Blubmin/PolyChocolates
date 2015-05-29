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
    public partial class EditExistingProductEntryControl : UserControl
    {
        private VersionRow _selectedVersionRow = null;
        private List<VersionRow> _versionRows = new List<VersionRow>();
        public ProductRow SelectedProductEntry = null;
        private int _newVersion;

        public EditExistingProductEntryControl(int productEntryId)
        {
            InitializeComponent();

            databaseDataContext db = new databaseDataContext();

            var query = 
                from pe in db.ProductEntries 
                where pe.ProductEntryId == productEntryId 
                orderby pe.ProductEntryVersion descending 
                select pe;

            _newVersion = query.First().ProductEntryVersion + 1;

            foreach (var version in query)
            {
                VersionRow row = new VersionRow(version, this);
                AddVersionRowToTable(row);
            }

            _selectedVersionRow = _versionRows.First();
            _selectedVersionRow.SelectButton.PerformClick();
        }

        public EditExistingProductEntryControl(ProductEntry pe)
        {
            InitializeComponent();

            BackButton.Visible = false;
            FullReportButton.Visible = false;
            VersionRow row = new VersionRow(pe, this);
            AddVersionRowToTable(row);
            _selectedVersionRow = _versionRows.First();
            _selectedVersionRow.SelectButton.PerformClick();
        }

        private void RefreshVersion()
        {
            MessageBox.Show("Revision submitted.");
            Home.ChangeMainViewControl(new EditExistingProductEntryControl(SelectedProductEntry.ProductEntry.ProductEntryId));
        }

        private void AddVersionRowToTable(VersionRow row)
        {
            _versionRows.Add(row);

            ProductEntryVersionTable.Controls.Add(row.SelectButton);
            ProductEntryVersionTable.Controls.Add(row.VersionNumber);
            ProductEntryVersionTable.Controls.Add(row.Date);
            ProductEntryVersionTable.Controls.Add(row.Product);
            ProductEntryVersionTable.Controls.Add(row.CodeDate);
            ProductEntryVersionTable.Controls.Add(row.Status);
            Library.CenterPictureBox(row.Status);
            row.Status.Dock = DockStyle.Left;
        }

        private void SelectVersion(ProductEntry version)
        {
            if (SelectedProductEntry != null)
                RemoveProductRowFromTable(SelectedProductEntry);
            ProductRow row = new ProductRow(version);
            AddProductRowToTable(row);
            row.LoadSelectedRecipe();
            SelectedProductEntry = row;
            Library.CenterPictureBox(row.HaacpPic);
            Library.CenterPictureBox(row.Status);
            StudentManagerNameTextField.Text = version.StudentManager;
            pilotPlantManagerTextBox.Text = version.PlantManager;
            productionNotesSummaryTextBox.Text = version.ProductionNotes;
            
        }

        private void RemoveProductRowFromTable(ProductRow row)
        {
            foreach (var control in row.Controls)
            {
                ProductionSummaryTable.Controls.Remove(control);
            }
        }

        private void AddProductRowToTable(ProductRow row)
        {
            ProductionSummaryTable.Controls.AddRange(row.Controls);
        }

        public class VersionRow
        {
            private EditExistingProductEntryControl ParentEditExistingProductEntryControl = null;
            public ProductEntry ProductEntry = null;
            public RadioButton SelectButton = new RadioButton();
            public Label VersionNumber = new Label();
            public Label Date = new Label();
            public Label Product = new Label();
            public Label CodeDate = new Label();
            public PictureBox Status = new PictureBox();

            public VersionRow(ProductEntry productEntry, EditExistingProductEntryControl parentEditExistingProductEntryControl)
            {
                ProductEntry = productEntry;
                ParentEditExistingProductEntryControl = parentEditExistingProductEntryControl;

                SelectButton.Anchor = AnchorStyles.Top;
                SelectButton.Click += SelectButton_Click;

                VersionNumber.AutoSize = true;
                VersionNumber.Font = new Font(VersionNumber.Font.FontFamily, 12);
                VersionNumber.Text = productEntry.ProductEntryVersion.ToString();

                Date.AutoSize = true;
                Date.Font = new Font(Date.Font.FontFamily, 12);
                Date.Text = Convert.ToDateTime(productEntry.Date.ToString()).ToShortDateString();

                Product.AutoSize = true;
                Product.Font = new Font(Product.Font.FontFamily, 12);
                Product.Text = productEntry.Recipe.Name;

                CodeDate.AutoSize = true;
                CodeDate.Font = new Font(CodeDate.Font.FontFamily, 12);
                CodeDate.Text = productEntry.CodeDate.ToString();

                Status.Image = productEntry.Complete == "Y" ? Home.CheckMark : Home.XMark;
            }

            public void SelectButton_Click(object sender, EventArgs e)
            {
                ParentEditExistingProductEntryControl._selectedVersionRow.SelectButton.Checked = false;
                ParentEditExistingProductEntryControl._selectedVersionRow = this;
                ParentEditExistingProductEntryControl._selectedVersionRow.SelectButton.Checked = true;
                ParentEditExistingProductEntryControl.SelectVersion(ProductEntry);
            }
        }

        public class ProductRow
        {
            public ProductEntry ProductEntry = null;
            public Recipe Recipe;
            public Control[] Controls = new Control[10];
            public ComboBox Product = new ComboBox();
            public TextBox CodeDate = new TextBox();
            public TextBox NumPackaged = new TextBox();
            public TextBox NumProduced = new TextBox();
            public TextBox Downtime = new TextBox();
            public PictureBox HaacpPic = new PictureBox();
            public byte[] HaacpBytes = null;
            public Button QualityButton = new Button();
            public ChocolateQualityControl ChocolateQualityControl = null;
            public GenericQualityControl GenericQualityControl = null;
            public Button TraceabilityButton = new Button();
            public TraceabilityControl TraceabilityControl = null;
            public Button EfficiencyButton = new Button();
            public GenericEfficiencyControl EfficiencyControl = null;
            public PictureBox Status = new PictureBox();
            public bool IsComplete = false;

            public ProductRow(ProductEntry productEntry)
            {
                Init(productEntry);
            }

            private void Init(ProductEntry productEntry)
            {
                ProductEntry = productEntry;

                Controls[0] = Product;
                Controls[1] = CodeDate;
                Controls[2] = NumPackaged;
                Controls[3] = NumProduced;
                Controls[4] = Downtime;
                Controls[5] = HaacpPic;
                Controls[6] = QualityButton;
                Controls[7] = TraceabilityButton;
                Controls[8] = EfficiencyButton;
                Controls[9] = Status;

                // Sets all table controls to fill
                foreach (var control in Controls)
                    control.Dock = DockStyle.Fill;

                // Product Dropdown Init
                databaseDataContext db = new databaseDataContext();
                var recipes =
                    from recipe in db.Recipes
                    where recipe.Enabled == "Y" || recipe == ProductEntry.Recipe
                    select recipe;

                Recipe = (from reci in db.Recipes where reci == productEntry.Recipe select reci).First();
                Product.DataSource = recipes;
                Product.DisplayMember = "Name";
                Product.Width = 215;
                Product.SelectedIndexChanged += ProductChanged;

                if (!recipes.Contains(Recipe))
                {
                    Product.SelectedText = Recipe.Name;
                }

                // Code Date Init
                CodeDate.Text = ProductEntry.CodeDate;

                // #Packaged Init
                NumPackaged.Text = ProductEntry.AmountPackaged.ToString();
                NumPackaged.Leave += Library.onlyAllowNumerics;

                // #Produced Init
                NumProduced.Text = ProductEntry.AmountProduced.ToString();
                NumProduced.Leave += Library.onlyAllowNumerics;

                // Downtime Init
                Downtime.Text = ProductEntry.Downtime;

                // Haacp Init
                if (productEntry.haacp != null)
                    HaacpBytes = productEntry.haacp.ToArray();
                HaacpPic.Image = HaacpBytes != null ? Home.Document : Home.BlankDocument;
                HaacpPic.Click += AttachHaacpWindow;
                HaacpPic.VisibleChanged += LoadCoaIcon;

                // Quality Button Init
                QualityButton.Text = "Quality";
                QualityButton.Enabled = ProductEntry.Recipe.QualityControlId >= Library.CHOCOLATE_QUALITY_CONTROL;
                QualityButton.UseVisualStyleBackColor = true;
                QualityButton.Click += QuialityButton_Click;

                if (ProductEntry.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    ChocolateQualityControl = new ChocolateQualityControl(ProductEntry);
                }
                else if (ProductEntry.QualityControlId >= Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    GenericQualityControl = new GenericQualityControl(ProductEntry, false);
                }

                // Traceability Button Init
                TraceabilityButton.Text = "Traceability";
                TraceabilityButton.Enabled = ProductEntry.Recipe.TraceabilityRequired == "Y";
                TraceabilityButton.UseVisualStyleBackColor = true;
                TraceabilityButton.Click += TraceabilityButton_Click;

                if (TraceabilityButton.Enabled)
                {
                    TraceabilityControl = new TraceabilityControl(ProductEntry, false);
                }

                // Efficiency Button Init
                EfficiencyButton.Text = "Efficiency";
                EfficiencyButton.Enabled = ProductEntry.Recipe.EfficiencyRequired == "Y"; ;
                EfficiencyButton.UseVisualStyleBackColor = true;
                EfficiencyButton.Click += EfficiencyButton_Click;

                if (EfficiencyButton.Enabled)
                {
                    EfficiencyControl = new GenericEfficiencyControl(ProductEntry);
                }

                // Status Icon Init
                Status.Image = productEntry.Complete == "Y" ? Home.CheckMark : Home.XMark;
                Status.VisibleChanged += CheckToSeeIfComplete;
            }

            private void QuialityButton_Click(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe)Product.SelectedItem;
                if (selectedRecipe.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    Home.ChangeMainViewControl(ChocolateQualityControl);
                }
                else if (selectedRecipe.QualityControlId > Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    Home.ChangeMainViewControl(GenericQualityControl);
                }
            }

            private void TraceabilityButton_Click(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe)Product.SelectedItem;
                
                Home.ChangeMainViewControl(TraceabilityControl);
            }

            private void EfficiencyButton_Click(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe)Product.SelectedItem;
                
                Home.ChangeMainViewControl(EfficiencyControl);
            }

            private void ProductChanged(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe)Product.SelectedItem;
                QualityButton.Enabled = selectedRecipe.QualityControlId >= Library.CHOCOLATE_QUALITY_CONTROL;
                if (selectedRecipe.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    ChocolateQualityControl = new ChocolateQualityControl(ProductEntry);
                }
                else if (selectedRecipe.QualityControlId > Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    GenericQualityControl = new GenericQualityControl(ProductEntry);
                }
                TraceabilityButton.Enabled = selectedRecipe.TraceabilityRequired == "Y";
                if (TraceabilityButton.Enabled)
                {
                    TraceabilityControl = new TraceabilityControl(ProductEntry, true);
                }
                EfficiencyButton.Enabled = selectedRecipe.EfficiencyRequired == "Y";
                if (EfficiencyButton.Enabled)
                {
                    EfficiencyControl = new GenericEfficiencyControl(ProductEntry);
                }
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

            public void LoadSelectedRecipe()
            {

                Product.SelectedItem = Recipe;
            }

            private void CheckToSeeIfComplete(object sender, EventArgs e)
            {
                Recipe recipe = (Recipe)Product.SelectedItem;

                // Checks to see if the row is complete
                IsComplete = recipe.QualityControlId > 1;
                if (IsComplete)
                    IsComplete &= IsComplete && recipe.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL
                    ? ChocolateQualityControl.IsComplete
                    : GenericQualityControl.IsComplete;
                IsComplete &= recipe.TraceabilityRequired == "Y" && TraceabilityControl != null &&
                              TraceabilityControl.IsComplete;
                IsComplete &= recipe.EfficiencyRequired == "Y" && EfficiencyControl != null &&
                              EfficiencyControl.IsComplete;

                Status.Image = IsComplete ? Home.CheckMark : Home.XMark;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Home.ChangeToPreviousControl();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            databaseDataContext db = new databaseDataContext();

            var row = SelectedProductEntry;

            var recipe =
                from recipes in db.Recipes
                where recipes == ((Recipe)row.Product.SelectedItem)
                select recipes;

            #region Product Entry Submit

            ProductEntry newProductEntry =
                new ProductEntry
                {
                    ProductEntryId = row.ProductEntry.ProductEntryId,
                    ProductEntryVersion = _newVersion,
                    Date = Convert.ToDateTime(date.Text),
                    Recipe = recipe.First(),
                    QualityControlId = recipe.First().QualityControlId,
                    CodeDate = row.CodeDate.Text,
                    AmountPackaged = Int32.Parse(row.NumPackaged.Text),
                    AmountProduced = Int32.Parse(row.NumProduced.Text),
                    Downtime = row.Downtime.Text,
                    haacp = row.HaacpBytes,
                    Complete = row.IsComplete ? "Y" : "N",
                    ProductionNotes = productionNotesSummaryTextBox.Text,
                    StudentManager = StudentManagerNameTextField.Text,
                    PlantManager = pilotPlantManagerTextBox.Text
                };
            db.ProductEntries.InsertOnSubmit(newProductEntry);
            newProductEntry.ProductEntryId = row.ProductEntry.ProductEntryId;
            #endregion
            #region Chocolate Quality Submit
            if (newProductEntry.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL && row.ChocolateQualityControl != null)
            {
                newProductEntry.QualityPerformer = row.ChocolateQualityControl.performedBy.Text;

                ChocolateQuality newChocolateQuality = new ChocolateQuality
                {
                    ProductEntry = newProductEntry,
                    Appearance = row.ChocolateQualityControl.appearance.Text,
                    DarkMachine = row.ChocolateQualityControl.DarkMachine.Text,
                    Flavor = row.ChocolateQualityControl.flavor.Text,
                    MilkMachine1 = row.ChocolateQualityControl.milkMachine1.Text,
                    MilkMachine2 = row.ChocolateQualityControl.milkMachine2.Text,
                    TasteTest = row.ChocolateQualityControl.tasteTest.Text,
                    Temper = row.ChocolateQualityControl.temper.Text,
                    Weight1 = row.ChocolateQualityControl.weight1.Text,
                    Weight2 = row.ChocolateQualityControl.weight2.Text,
                    Weight3 = row.ChocolateQualityControl.weight3.Text,
                };
                db.ChocolateQualities.InsertOnSubmit(newChocolateQuality);

                foreach (var weightRow in row.ChocolateQualityControl.weightsList)
                {
                    ChocolateBarWeight newBarWeight = new ChocolateBarWeight
                    {
                        Bar1 = weightRow.bar1.Text,
                        Bar2 = weightRow.bar2.Text,
                        Bar3 = weightRow.bar3.Text,
                        Bar4 = weightRow.bar4.Text,
                        Bar5 = weightRow.bar5.Text,
                        ChocolateQuality = newChocolateQuality
                    };
                    db.ChocolateBarWeights.InsertOnSubmit(newBarWeight);
                }
            }
            #endregion
            #region Generic Quality Submit
            else if (row.GenericQualityControl != null)
            {
                newProductEntry.QualityPerformer = row.GenericQualityControl.performedBy.Text;

                foreach (var qualRow in row.GenericQualityControl.qualList)
                {
                    ProductQualityEntryQual newQual = new ProductQualityEntryQual
                    {
                        ProductEntry = newProductEntry,
                        Comments = qualRow.comments.Text,
                        QualityLabelQual = (from labels in db.QualityLabelQuals where labels == qualRow.labels select labels).First(),
                        SustainTakeAction = qualRow.sustainTakeAction.SelectedText
                    };
                    db.ProductQualityEntryQuals.InsertOnSubmit(newQual);
                }

                foreach (var quantRow in row.GenericQualityControl.quantList)
                {
                    ProductQualityEntryQuant newQuant = new ProductQualityEntryQuant
                    {
                        ProductEntry = newProductEntry,
                        Action = quantRow.action.Text,
                        Value = quantRow.value.Text,
                        QualityLabelQuant = (from labels in db.QualityLabelQuants where labels == quantRow.labels select labels).First()
                    };
                    db.ProductQualityEntryQuants.InsertOnSubmit(newQuant);
                }
            }
            #endregion
            #region Traceability Submit
            if (newProductEntry.Recipe.TraceabilityRequired == "Y" && row.TraceabilityControl != null)
            {
                foreach (var traceabilityRow in row.TraceabilityControl.traceabilityList)
                {
                    Traceability newTrace = new Traceability
                    {
                        AmountUsed = Double.Parse(traceabilityRow.amountUsed.Text),
                        Inventory = traceabilityRow.inv,
                        ProductEntry = newProductEntry,
                    };
                    db.Traceabilities.InsertOnSubmit(newTrace);
                    if (row.ProductEntry.Complete != "Y" && row.IsComplete)
                    {
                        var inv =
                            from inventories in db.Inventories
                            where inventories == traceabilityRow.inv
                            select inventories;

                        inv.First().PredictedUsage -= newTrace.AmountUsed;
                    }
                }
            }
            #endregion
            #region Efficiency Submit
            if (newProductEntry.Recipe.EfficiencyRequired == "Y" && row.EfficiencyControl != null)
            {
                Efficiency newEfficiency = new Efficiency()
                {
                    ProductEntry = newProductEntry,
                    ItemWeight = Double.Parse(row.EfficiencyControl.ItemWeightTextField.Text),
                    ActualYield = Double.Parse(row.EfficiencyControl.ActualYieldTextField.Text),
                };
                db.Efficiencies.InsertOnSubmit(newEfficiency);
                foreach (var waste in row.EfficiencyControl.wasteList)
                {
                    EfficiencyWaste newWaste = new EfficiencyWaste()
                    {
                        Efficiency = newEfficiency,
                        WasteType = waste.weight.Text,
                        Amount = Double.Parse(waste.amount.Text)
                    };
                    db.EfficiencyWastes.InsertOnSubmit(newWaste);
                }
            }
            #endregion
            #region Add Finished Product to Inventory
            if (row.ProductEntry.Complete != "Y" && row.IsComplete)
            {
                if (newProductEntry.AmountPackaged > 0)
                {
                    Inventory newFinished = new Inventory()
                    {
                        LotCode = newProductEntry.CodeDate,
                        PreviousStock = 0,
                        Stock = newProductEntry.AmountPackaged,
                        PredictedUsage = newProductEntry.AmountPackaged,
                        Type = "finished",
                        Enabled = "Y",
                        ActualUsage = newProductEntry.AmountPackaged,
                        Certificate = new byte[0],
                        Name = newProductEntry.Recipe.Name,
                        Unit = "Items",
                        PricePerUnit = 0,
                        Supplier = date.Text
                    };
                    db.Inventories.InsertOnSubmit(newFinished);
                }
            }
            #endregion
            db.SubmitChanges();

            RefreshVersion();
        }

        private void StudentManagerNameTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void FullReportButton_Click(object sender, EventArgs e)
        {
            SearchEntry entry = new SearchEntry(SelectedProductEntry.ProductEntry);
            entry.Visible = true;
        }
    }
}
