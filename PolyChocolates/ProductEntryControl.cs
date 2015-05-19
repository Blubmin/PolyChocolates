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

namespace PolyChocolates
{
    public partial class ProductEntryControl : UserControl
    {
        private Home home;

        public static bool[] qcComplete = new bool[] { false, false, false, false };
        public static bool[] traceabilityComplete = new bool[] { false, false, false, false };
        public static bool[] efficiencyComplete = new bool[] { false, false, false, false };
        private ProductRow[] productRows = new ProductRow[4];

        private HashSet<String> existingCodeDates;
        private databaseDataContext db = new databaseDataContext();

        public ProductEntryControl(Home home)
        {
            this.home = home;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            var query =
                from codes in db.ProductEntries
                select codes.CodeDate;

            existingCodeDates = new HashSet<String>();

            foreach (String s in query)
            {
                existingCodeDates.Add(s);
            }


            BindComboBoxes();
            ProductDropDown1.DropDownStyle = ComboBoxStyle.DropDownList;
            ProductDropDown1.SelectedIndex = 0;
            ProductDropDown2.DropDownStyle = ComboBoxStyle.DropDownList;
            ProductDropDown2.SelectedIndex = 0;
            ProductDropDown3.DropDownStyle = ComboBoxStyle.DropDownList;
            ProductDropDown3.SelectedIndex = 0;
            ProductDropDown4.DropDownStyle = ComboBoxStyle.DropDownList;
            ProductDropDown4.SelectedIndex = 0;
            StudentApprovalStatus.SelectedIndex = 1;
            ManagerApprovalStatus.SelectedIndex = 1;
            InitializeRows();

            LotCodeTextField1.Enter += new EventHandler(onEnterCodeDate);
            LotCodeTextField1.Leave += new EventHandler(updateEachRowStatus);
            LotCodeTextField1.Leave += new EventHandler(ensureUniqueCodeDate);
            AmountPackagedTextField1.Leave += new EventHandler(Library.onlyAllowNumerics);
            AmountPackagedTextField1.Leave += new EventHandler(updateEachRowStatus);
            AmountProducedTextField1.Leave += new EventHandler(Library.onlyAllowNumerics);
            AmountProducedTextField1.Leave += new EventHandler(updateEachRowStatus);

            LotCodeTextField2.Enter += new EventHandler(onEnterCodeDate);
            LotCodeTextField2.Leave += new EventHandler(updateEachRowStatus);
            LotCodeTextField2.Leave += new EventHandler(ensureUniqueCodeDate);
            AmountPackagedTextField2.Leave += new EventHandler(Library.onlyAllowNumerics);
            AmountPackagedTextField2.Leave += new EventHandler(updateEachRowStatus);
            AmountProducedTextField2.Leave += new EventHandler(Library.onlyAllowNumerics);
            AmountProducedTextField2.Leave += new EventHandler(updateEachRowStatus);

            LotCodeTextField3.Enter += new EventHandler(onEnterCodeDate);
            LotCodeTextField3.Leave += new EventHandler(updateEachRowStatus);
            LotCodeTextField3.Leave += new EventHandler(ensureUniqueCodeDate);
            AmountPackagedTextField3.Leave += new EventHandler(Library.onlyAllowNumerics);
            AmountPackagedTextField3.Leave += new EventHandler(updateEachRowStatus);
            AmountProducedTextField3.Leave += new EventHandler(Library.onlyAllowNumerics);
            AmountProducedTextField3.Leave += new EventHandler(updateEachRowStatus);

            LotCodeTextField4.Enter += new EventHandler(onEnterCodeDate);
            LotCodeTextField4.Leave += new EventHandler(updateEachRowStatus);
            LotCodeTextField4.Leave += new EventHandler(ensureUniqueCodeDate);
            AmountPackagedTextField4.Leave += new EventHandler(Library.onlyAllowNumerics);
            AmountPackagedTextField4.Leave += new EventHandler(updateEachRowStatus);
            AmountProducedTextField4.Leave += new EventHandler(Library.onlyAllowNumerics);
            AmountProducedTextField4.Leave += new EventHandler(updateEachRowStatus);

            foreach (var row in productRows)
            {
                row.LotCode.Text = "";
                row.Packaged.Text = "";
                row.Produced.Text = "";
                row.QualityButton.Enabled = false;
                row.EfficiencyButton.Enabled = false;
                row.TraceabilityButton.Enabled = false;
            }
            productionNotesSummaryTextBox.Text = "";
            StudentManagerNameTextField.Text = "";
            pilotPlantManagerTextBox.Text = "";
        }

        private void ensureUniqueCodeDate(object sender, EventArgs e)
        {
            if (existingCodeDates.Contains(((TextBox)sender).Text))
            {
                MessageBox.Show("This Code Date isn't unique!");
                ((TextBox)sender).Text = "";
                ((TextBox)sender).Select();
            }
            else if (((TextBox)sender).Text.Length > 0)
            {
                existingCodeDates.Add(((TextBox)sender).Text);
            }
        }

        private void onEnterCodeDate(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length > 0)
            {
                existingCodeDates.Remove(((TextBox)sender).Text);
            }
        }

        private void ProductDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEachRowStatus(null, null);
            for (int row = 0; row < productRows.Length; row++)
            {
                if (productRows[row].Product == sender)
                {
                    var query =
                        from recipe in db.Recipes
                        where recipe.Name == productRows[row].Product.SelectedItem
                        select recipe;
                    Recipe rec = query.First();
                    productRows[row].Recipe = rec;
                    productRows[row].QualityButton.Enabled = rec.QualityControlId >= Library.CHOCOLATE_QUALITY_CONTROL;
                    productRows[row].TraceabilityButton.Enabled = rec.TraceabilityRequired.Equals("Y");
                    productRows[row].EfficiencyButton.Enabled = rec.EfficiencyRequired.Equals("Y");
                    if (Home.traceabilityControls[row] != null)
                        Home.traceabilityControls[row].reset();
                    Home.productChanged(home, rec, row);
                }
            }
        }
        private void traceabilityButton_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < productRows.Length; row++)
            {
                if (productRows[row].TraceabilityButton == sender)
                {
                    if (Home.traceabilityControls[row] == null)
                    {
                        Home.traceabilityControls[row] = new TraceabilityControl(row);
                        Home.traceabilityControls[row].Location = Home.controlStartingPoint;
                        Home.traceabilityControls[row].Visible = false;
                        home.Controls.Add(Home.traceabilityControls[row]);
                    }
                    ProductEntryControl.traceabilityComplete[row] = false;
                    Home.changeViewToTraceability(row);
                }
            }


        }
        private void efficiencyButton_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < productRows.Length; row++)
            {
                if (productRows[row].EfficiencyButton == sender)
                {
                    ProductEntryControl.efficiencyComplete[row] = false;
                    Home.changeViewToEfficiency(row);
                }
            }
        }

        /**
         * Updates the checkmark/x-mark for each row status.
         * */
        public void updateEachRowStatus(object sender, EventArgs args)
        {
            int i = 0;
            foreach (var row in productRows)
            {
                if (row.Recipe.RecipeId != 1 && row.LotCode.Text.Length > 0
                && row.Packaged.Text.Length > 0 && row.Produced.Text.Length > 0
                && (qcComplete[i] || row.Recipe.QualityControlId == 1) 
                && (traceabilityComplete[i] || row.Recipe.TraceabilityRequired.Equals("N"))
                && (efficiencyComplete[i] || row.Recipe.EfficiencyRequired.Equals("N")))
                {
                    row.Check.Image = Home.CheckMark;
                    row.Complete = true;
                }
                else
                {
                    row.Check.Image = Home.XMark;
                    row.Complete = false;
                }
                i++;
            }
        }

        public void ProductEntryControl_VisibilityChanged(object sender, EventArgs e)
        {
            updateEachRowStatus(null, null);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.recipeTableAdapter.Fill(this.databaseDataSet.Recipe);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void InitializeRows()
        {
            var query =
                from recipe in db.Recipes
                where recipe.Name == ProductDropDown1.SelectedValue
                select recipe;
            productRows[0] = new ProductRow(query.First(), ProductDropDown1, LotCodeTextField1, AmountProducedTextField1, AmountPackagedTextField1, haccp1, qcButton1, traceabilityButton1, efficiencyButton1, row1_status);
            productRows[1] = new ProductRow(query.First(), ProductDropDown2, LotCodeTextField2, AmountProducedTextField2, AmountPackagedTextField2, haccp2, qcButton2, traceabilityButton2, efficiencyButton2, row2_status);
            productRows[2] = new ProductRow(query.First(), ProductDropDown3, LotCodeTextField3, AmountProducedTextField3, AmountPackagedTextField3, haccp3, qcButton3, traceabilityButton3, efficiencyButton3, row3_status);
            productRows[3] = new ProductRow(query.First(), ProductDropDown4, LotCodeTextField4, AmountProducedTextField4, AmountPackagedTextField4, haccp4, qcButton4, traceabilityButton4, efficiencyButton4, row4_status);
        }

        private void BindComboBoxes()
        {
            var names =
                from recipe in db.Recipes
                select recipe.Name;
            ProductDropDown1.DataSource = names.ToArray();
            ProductDropDown2.DataSource = names.ToArray();
            ProductDropDown3.DataSource = names.ToArray();
            ProductDropDown4.DataSource = names.ToArray();
        }

        private void AdjustWidthComboBox_DropDown(object sender, System.EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < ProductionSummaryTable.RowCount - 1; row++)
            {
                if (productRows[row].Complete)
                {
                    String recipeName = (String)productRows[row].Product.SelectedItem;
                    var recipeQuery =
                        from recipe in db.Recipes
                        where recipe.Name == recipeName
                        select recipe;
                    Recipe rcp = null;
                    foreach (var rec in recipeQuery)
                    {
                        rcp = rec;
                    }
                    ProductEntry pe = new ProductEntry()
                    {
                        Recipe = rcp,
                        QualityControlId = rcp.QualityControlId,
                        CodeDate = productRows[row].LotCode.Text,
                        Date = Convert.ToDateTime(date.Text),
                        AmountPackaged = Int32.Parse(productRows[row].Packaged.Text),
                        AmountProduced = Int32.Parse(productRows[row].Produced.Text),
                        haacp = productRows[row].haacp,
                        ProductionNotes = productionNotesSummaryTextBox.Text,
                        StudentManager = StudentManagerNameTextField.Text,
                        PlantManager = pilotPlantManagerTextBox.Text
                    };
                    db.ProductEntries.InsertOnSubmit(pe);
                    if (rcp.TraceabilityRequired.Equals("Y"))
                    {
                        foreach (var traceable in Home.traceabilityControls[row].traceabilityList)
                        {
                            Traceability newTraceability = new Traceability()
                            {
                                AmountUsed = Double.Parse(traceable.amountUsed.Text),
                                ProductEntry = pe,
                                InventoryId = traceable.inv.InventoryId
                            };
                            var temp =
                                from inv in db.Inventories
                                where inv == traceable.inv
                                select inv;
                            temp.First().PredictedUsage -= Double.Parse(traceable.amountUsed.Text);
                            db.Traceabilities.InsertOnSubmit(newTraceability);
                        }
                    }
                    if (rcp.EfficiencyRequired.Equals("Y"))
                    {
                        GenericEfficiencyControl data = Home.efficiencyControls[row];
                        Efficiency newEfficiency = new Efficiency()
                        {
                            ProductEntry = pe,
                            ItemWeight = Double.Parse(data.ItemWeightTextField.Text),
                            ActualYield = Double.Parse(data.ActualYieldTextField.Text),
                        };
                        db.Efficiencies.InsertOnSubmit(newEfficiency);
                        foreach (var waste in data.wasteList)
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
                    if (rcp.QualityControlId > Library.CHOCOLATE_QUALITY_CONTROL)
                    {
                        foreach (var qual in ((GenericQualityControl)Home.qcControls[row]).qualList)
                        {
                            ProductQualityEntryQual newQualRow = new ProductQualityEntryQual()
                            {
                                ProductEntry = pe,
                                QualityLabelQual = qual.labels,
                                SustainTakeAction = qual.sustainTakeAction.Text,
                                Comments = qual.comments.Text
                            };
                            db.ProductQualityEntryQuals.InsertOnSubmit(newQualRow);
                        }
                        foreach (var quant in ((GenericQualityControl) Home.qcControls[row]).quantList)
                        {
                            ProductQualityEntryQuant newQuantRow = new ProductQualityEntryQuant()
                            {
                                ProductEntry = pe,
                                QualityLabelQuant = quant.labels,
                                Value = quant.value.Text,
                                Action = quant.action.Text
                            };
                            db.ProductQualityEntryQuants.InsertOnSubmit(newQuantRow);
                        }
                        pe.QualityPerformer = ((GenericQualityControl)Home.qcControls[row]).performedBy.Text;
                    }
                    else if (rcp.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL)
                    {
                        ChocolateQualityControl data = (ChocolateQualityControl) Home.qcControls[row];
                        ChocolateQuality chocQual = new ChocolateQuality()
                        {
                            ProductEntry = pe,
                            MilkMachine1 = data.milkMachine1.Text,
                            MilkMachine2 = data.milkMachine2.Text,
                            DarkMachine = data.DarkMachine.Text,
                            Weight1 = data.weight1.Text,
                            Weight2 = data.weight2.Text,
                            Weight3 = data.weight3.Text,
                            Temper = data.temper.Text,
                            Appearance = data.appearance.Text,
                            Flavor = data.flavor.Text,
                            TasteTest = data.tasteTest.SelectedText
                        };
                        db.ChocolateQualities.InsertOnSubmit(chocQual);
                        foreach (var weight in data.weightsList)
                        {
                            ChocolateBarWeight newWeights = new ChocolateBarWeight()
                            {
                                ChocolateQuality = chocQual,
                                Bar1 = weight.bar1.Text,
                                Bar2 = weight.bar2.Text,
                                Bar3 = weight.bar3.Text,
                                Bar4 = weight.bar4.Text,
                                Bar5 = weight.bar5.Text
                            };
                            db.ChocolateBarWeights.InsertOnSubmit(newWeights);
                        }
                        pe.QualityPerformer = ((ChocolateQualityControl)Home.qcControls[row]).performedBy.Text;
                    }
                    if (double.Parse(productRows[row].Packaged.Text) > 0)
                    {
                        Inventory newFinished = new Inventory()
                        {
                            LotCode = productRows[row].LotCode.Text,
                            PreviousStock = 0,
                            Stock = double.Parse(productRows[row].Packaged.Text),
                            PredictedUsage = double.Parse(productRows[row].Packaged.Text),
                            Type = "finished",
                            Enabled = "Y",
                            ActualUsage = double.Parse(productRows[row].Packaged.Text),
                            Certificate = new byte[0],
                            Name = (string)productRows[row].Product.SelectedValue,
                            Unit = "Items",
                            PricePerUnit = 0,
                            Supplier = date.Text
                        };
                        db.Inventories.InsertOnSubmit(newFinished);
                    }
                }
                db.SubmitChanges();
                ProductEntryControl.qcComplete[row] = false;
                ProductEntryControl.traceabilityComplete[row] = false;
                ProductEntryControl.efficiencyComplete[row] = false;
            }
            MessageBox.Show("Any Product Entry row that is checked was submitted!");
            home.refreshProductEntry();
            home.refreshInventory();
            home.refreshInvoice();
            Home.changeViewToHome();
        }

        public class ProductRow
        {
            public Recipe Recipe;
            public ComboBox Product;
            public TextBox LotCode;
            public TextBox Produced;
            public TextBox Packaged;
            public PictureBox picBox;
            public Button QualityButton;
            public Button TraceabilityButton;
            public Button EfficiencyButton;
            public PictureBox Check;
            public bool Complete;
            public byte[] haacp = null;

            public ProductRow(Recipe recipe, ComboBox product, TextBox lotCode, TextBox produced, 
                TextBox packaged, PictureBox picBox, Button qualityButton, Button traceabilityButton, 
                Button efficiencyButton, PictureBox check)
            {
                this.picBox = picBox;
                picBox.Height = 20;
                picBox.Margin = new Padding(25, 10, 0, 0);
                if (haacp != null)
                    picBox.Image = InventoryControl.document;
                else
                    picBox.Image = InventoryControl.blankDocument;
                picBox.Click += new EventHandler(attachHAACPWindow);
                picBox.VisibleChanged += new EventHandler(loadCOAIcon);
                Recipe = recipe;
                Product = product;
                LotCode = lotCode;
                Produced = produced;
                Packaged = packaged;
                QualityButton = qualityButton;
                TraceabilityButton = traceabilityButton;
                EfficiencyButton = efficiencyButton;
                Check = check;
                Complete = false;
            }

            private void attachHAACPWindow(object sender, EventArgs e)
            {
                HACCP haacp = new HACCP(this);
                haacp.ShowDialog();
                if (this.haacp != null)
                    picBox.Image = Home.Document;
                else
                    picBox.Image = Home.BlankDocument;
            }
            private void loadCOAIcon(object sender, EventArgs e)
            {
                if (this.haacp != null && this.haacp.Length > 0)
                    picBox.Image = Home.Document;
                else
                    picBox.Image = Home.BlankDocument;
            }
        }

        private void enableDisableSubmit()
        {
            try
            {
                if (StudentApprovalStatus.SelectedItem.Equals("Approved") && ManagerApprovalStatus.SelectedItem.Equals("Approved"))
                {
                    SubmitButton.Enabled = true;
                }
                else
                {
                    SubmitButton.Enabled = false;
                }
            }
            catch (Exception e)
            {
                SubmitButton.Enabled = false;
            }
        }

        private void StudentApprovalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableSubmit();
        }

        private void ManagerApprovalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableSubmit();
        }

        private void qcButton_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < productRows.Count(); row++)
            {
                if (productRows[row].QualityButton == sender)
                {
                    qcComplete[row] = false;
                    Home.changeViewToQualityRow(row);
                }
            }
        }
    }
}
