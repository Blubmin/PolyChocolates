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
    public partial class ChocolateQualityControl : UserControl
    {
        public List<WeightRow> weightsList;
        public bool IsComplete = false;

        public ChocolateQualityControl(ProductEntry entry)
        {
            InitializeComponent();
            weightsList = new List<WeightRow>();
            ChocolateQuality qual = entry.ChocolateQualities.First();
            performedBy.Text = entry.QualityPerformer;
            milkMachine1.Text = qual.MilkMachine1;
            milkMachine2.Text = qual.MilkMachine2;
            DarkMachine.Text = qual.DarkMachine;
            weight1.Text = qual.Weight1;
            weight2.Text = qual.Weight2;
            weight3.Text = qual.Weight3;
            temper.Text = qual.Temper;
            appearance.Text = qual.Appearance;
            flavor.Text = qual.Flavor;
            tasteTest.SelectedValue = qual.TasteTest;
            foreach (var row in qual.ChocolateBarWeights)
            {
                WeightRow newRow = new WeightRow(row);
                barWeightTable.Controls.Add(newRow.toRemove);
                barWeightTable.Controls.Add(newRow.bar1);
                barWeightTable.Controls.Add(newRow.bar2);
                barWeightTable.Controls.Add(newRow.bar3);
                barWeightTable.Controls.Add(newRow.bar4);
                barWeightTable.Controls.Add(newRow.bar5);
            }
        }

        public ChocolateQualityControl()
        {
            InitializeComponent();
            weightsList = new List<WeightRow>();
        }

        public class WeightRow
        {
            public CheckBox toRemove = new CheckBox();
            public TextBox bar1 = new TextBox();
            public TextBox bar2 = new TextBox();
            public TextBox bar3 = new TextBox();
            public TextBox bar4 = new TextBox();
            public TextBox bar5 = new TextBox();

            public WeightRow(ChocolateBarWeight row) : this()
            {
                bar1.Text = row.Bar1;
                bar2.Text = row.Bar2;
                bar3.Text = row.Bar3;
                bar4.Text = row.Bar4;
                bar5.Text = row.Bar5;
            }

            public WeightRow()
            {
                bar1.Dock = DockStyle.Fill;
                bar2.Dock = DockStyle.Fill;
                bar3.Dock = DockStyle.Fill;
                bar4.Dock = DockStyle.Fill;
                bar5.Dock = DockStyle.Fill;
            }
        }

        private void addRow_Click(object sender, EventArgs e)
        {
            WeightRow newRow = new WeightRow();
            barWeightTable.Controls.Add(newRow.toRemove);
            barWeightTable.Controls.Add(newRow.bar1);
            barWeightTable.Controls.Add(newRow.bar2);
            barWeightTable.Controls.Add(newRow.bar3);
            barWeightTable.Controls.Add(newRow.bar4);
            barWeightTable.Controls.Add(newRow.bar5);
            weightsList.Add(newRow);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            List<WeightRow> toRemove = new List<WeightRow>();
            foreach (var row in weightsList)
            {
                if (row.toRemove.Checked)
                {
                    toRemove.Add(row);
                }
            }
            foreach (var row in toRemove)
            {
                barWeightTable.Controls.Remove(row.toRemove);
                barWeightTable.Controls.Remove(row.bar1);
                barWeightTable.Controls.Remove(row.bar2);
                barWeightTable.Controls.Remove(row.bar3);
                barWeightTable.Controls.Remove(row.bar4);
                barWeightTable.Controls.Remove(row.bar5);
                weightsList.Remove(row);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            IsComplete = false;
            Home.ChangeToPreviousControl();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            IsComplete = true;
            Home.ChangeToPreviousControl();
        }
    }
}
