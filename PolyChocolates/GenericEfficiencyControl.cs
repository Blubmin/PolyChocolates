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
    public partial class GenericEfficiencyControl : UserControl
    {

        public List<EfficiencyRow> wasteList = new List<EfficiencyRow>();
        public bool IsComplete = false;
        Recipe recipe;

        public GenericEfficiencyControl(ProductEntry entry)
        {
            InitializeComponent();
            RecipeWeightTextField.Text = entry.Recipe.ExpectedWeight + "";
            ItemWeightTextField.TextChanged += new EventHandler(updateExpected);
            ItemWeightTextField.Text = entry.Efficiencies.First().ItemWeight + "";
            ActualYieldTextField.TextChanged += new EventHandler(updateEfficiency);
            ActualYieldTextField.Text = entry.Efficiencies.First().ActualYield + "";
            foreach (var waste in entry.Efficiencies.First().EfficiencyWastes)
            {
                EfficiencyRow newRow = new EfficiencyRow(waste);
                newRow.amount.TextChanged += new EventHandler(this.updateTotal);
                newRow.amount.Text = waste.Amount + "";
                wasteTable.Controls.Add(newRow.toRemove);
                wasteTable.Controls.Add(newRow.weight);
                wasteTable.Controls.Add(newRow.amount);
                wasteList.Add(newRow);
            }
        }

        public GenericEfficiencyControl(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            wasteList = new List<EfficiencyRow>();
            RecipeWeightTextField.Text = recipe.ExpectedWeight + "";
            ItemWeightTextField.Leave += new EventHandler(Library.onlyAllowFloats);
            ItemWeightTextField.Validated += new EventHandler(updateExpected);
            ActualYieldTextField.Leave += new EventHandler(Library.onlyAllowFloats);
            ActualYieldTextField.Validated += new EventHandler(updateEfficiency);
        }

        public class EfficiencyRow
        {
            public CheckBox toRemove = new CheckBox();
            public TextBox weight = new TextBox();
            public TextBox amount = new TextBox();

            public EfficiencyRow(EfficiencyWaste waste)
            {
                toRemove.Dock = DockStyle.Fill;
                weight.Dock = DockStyle.Fill;
                weight.Text = waste.WasteType;
                amount.Dock = DockStyle.Fill;
            }

            public EfficiencyRow()
            {
                toRemove.Dock = DockStyle.Fill;
                weight.Dock = DockStyle.Fill;
                amount.Text = "0";
                amount.Dock = DockStyle.Fill;
                amount.Leave += new EventHandler(Library.onlyAllowFloats);
            }
        }

        private void addRow_Click(object sender, EventArgs e)
        {
            EfficiencyRow newRow = new EfficiencyRow();
            wasteTable.Controls.Add(newRow.toRemove);
            wasteTable.Controls.Add(newRow.weight);
            wasteTable.Controls.Add(newRow.amount);
            newRow.amount.Validated += new EventHandler(this.updateTotal);
            wasteList.Add(newRow);
        }

        private void updateTotal(object sender, EventArgs e) 
        {
            double value = Double.Parse(TotalWasteTextField.Text);
            value += Double.Parse(((TextBox)sender).Text);
            TotalWasteTextField.Text = value + "";
        }

        private void updateExpected(object sender, EventArgs e)
        {
            ExpectedItemsTextField.Text = Double.Parse(RecipeWeightTextField.Text) / Double.Parse(ItemWeightTextField.Text) + "";
        }

        private void updateEfficiency(object sender, EventArgs e)
        {
            EfficiencyPercentTextField.Text = String.Format("{0:P2}", Double.Parse(ActualYieldTextField.Text) / Double.Parse(ExpectedItemsTextField.Text));
        }

        private void removeRows_Click(object sender, EventArgs e)
        {
            List<EfficiencyRow> toRemove = new List<EfficiencyRow>();
            foreach (var row in wasteList)
            {
                if (row.toRemove.Checked)
                {
                    toRemove.Add(row);
                }
            }
            foreach (var row in toRemove)
            {
                wasteTable.Controls.Remove(row.toRemove);
                wasteTable.Controls.Remove(row.weight);
                wasteTable.Controls.Remove(row.amount);
                wasteList.Remove(row);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            IsComplete = false;
            Home.ChangeToPreviousControl();
        }

        private void submitEfficiencyButton_Click(object sender, EventArgs e)
        {
            IsComplete = true;
            Home.ChangeToPreviousControl();
        }
    }
}
