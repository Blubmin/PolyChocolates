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
            GotFocus += CheckToSeeIfComplete;
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
            public ChocolateQualityControl ChocolateQualityControl = null;
            public GenericQualityControl GenericQualityControl = null;
            public Button TraceabilityButton = new Button();
            public TraceabilityControl TraceabilityControl = null;
            public Button EfficiencyButton = new Button();
            public GenericEfficiencyControl EfficiencyControl = null;
            public PictureBox Status = new PictureBox();
            public bool IsComplete = false;

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
                    where recipe.Enabled == "Y"
                    select recipe;
                Product.DataSource = recipes;
                Product.DisplayMember = "Name";
                Product.Width = 215;
                Product.SelectedIndexChanged += ProductChanged;

                // #Packaged Init
                NumPackaged.Text = "0";
                NumPackaged.Leave += Library.onlyAllowNumerics;

                // #Produced Init
                NumProduced.Text = "0";
                NumProduced.Leave += Library.onlyAllowNumerics;

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
                Status.VisibleChanged += CheckToSeeIfComplete;
            }

            private void QuialityButton_Click(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe) Product.SelectedItem;
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
                Home.ChangeMainViewControl(EfficiencyControl);
            }

            private void ProductChanged(object sender, EventArgs e)
            {
                Recipe selectedRecipe = (Recipe) Product.SelectedItem;
                QualityButton.Enabled = selectedRecipe.QualityControlId >= Library.CHOCOLATE_QUALITY_CONTROL;
                if (QualityButton.Enabled && selectedRecipe.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    ChocolateQualityControl = new ChocolateQualityControl();
                }
                else if (QualityButton.Enabled)
                {
                    GenericQualityControl = new GenericQualityControl(selectedRecipe);
                }
                TraceabilityButton.Enabled = selectedRecipe.TraceabilityRequired == "Y";
                EfficiencyButton.Enabled = selectedRecipe.EfficiencyRequired == "Y";
                if (EfficiencyButton.Enabled && EfficiencyControl == null)
                {
                    EfficiencyControl = new GenericEfficiencyControl(selectedRecipe);
                    EfficiencyControl.Location = Home.ControlStartingPoint;
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

            private void CheckToSeeIfComplete(object sender, EventArgs e)
            {
                Recipe recipe = (Recipe)Product.SelectedItem;

                // Checks to see if the row is complete
                IsComplete = recipe.QualityControlId > 1;
                if (IsComplete)
                    IsComplete = IsComplete && recipe.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL
                    ? ChocolateQualityControl.IsComplete
                    : GenericQualityControl.IsComplete;
                IsComplete &= recipe.TraceabilityRequired == "Y" && TraceabilityControl != null &&
                              TraceabilityControl.IsComplete;
                IsComplete &= recipe.EfficiencyRequired == "Y" && EfficiencyControl != null &&
                              EfficiencyControl.IsComplete;

                Status.Image = IsComplete ? Home.CheckMark : Home.XMark;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddNewProductRow();
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

        private void CheckToSeeIfComplete(object sender, EventArgs e)
        {
            foreach (var row in _productRows)
            {
                Recipe recipe = (Recipe) row.Product.SelectedItem;

                // Checks to see if the row is complete
                row.IsComplete = recipe.QualityControlId > 1;
                row.IsComplete &= row.IsComplete && recipe.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL
                    ? row.ChocolateQualityControl.IsComplete
                    : row.GenericQualityControl.IsComplete;
                row.IsComplete &= recipe.TraceabilityRequired == "Y" && row.TraceabilityControl != null &&
                              row.TraceabilityControl.IsComplete;
                row.IsComplete &= recipe.EfficiencyRequired == "Y" && row.EfficiencyControl != null &&
                              row.EfficiencyControl.IsComplete;

                row.Status.Image = row.IsComplete ? Home.CheckMark : Home.XMark;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            databaseDataContext db = new databaseDataContext();

            foreach (var row in _productRows)
            {
                var recipe = 
                    from recipes in db.Recipes
                    where recipes == ((Recipe)row.Product.SelectedItem)
                    select recipes;

                #region Product Entry Submit

                var query = from pe in db.ProductEntries orderby pe.ProductEntryId descending select pe.ProductEntryId;
                ProductEntry newProductEntry = 
                    new ProductEntry
                    {
                        ProductEntryId = query.Any() ? query.Max() + 1 : 1,
                        ProductEntryVersion = 1,
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
                            SustainTakeAction = (String) qualRow.sustainTakeAction.SelectedItem
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
                        if (row.IsComplete)
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
                if (row.IsComplete)
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
            }
            db.SubmitChanges();
            MessageBox.Show("Production Summary submitted.");
            Home.Instance.Controls.Remove(this);
            Home._dynamicProductEntryControl = new DynamicProductEntryControl();
            Home.ChangeMainViewControl(Home._dynamicProductEntryControl);
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
