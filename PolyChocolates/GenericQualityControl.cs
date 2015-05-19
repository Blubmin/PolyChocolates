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
    public partial class GenericQualityControl : UserControl
    {
        private Recipe recipe;
        private QualityControl control;
        public List<QualitativeRow> qualList;
        public List<QuantitativeRow> quantList;
        public List<QualitativeRow> newQualList;
        public List<QuantitativeRow> newQuantList;
        private int view;
        private databaseDataContext db =  new databaseDataContext();
        HashSet<String> names;

        public GenericQualityControl()
        {
            control = new QualityControl()
            {
                Enabled = "Y",                
            };
            db.QualityControls.InsertOnSubmit(control);
            setupCreation();
        }

        public GenericQualityControl(String name)
        {
            var query =
                from qc in db.QualityControls
                where qc.Name == name
                select qc;
            this.control = query.First();
            setupCreation();
        }

        private void setupCreation()
        {
            InitializeComponent();
            names = new HashSet<string>();
            var query =
                from qc in db.QualityControls
                where qc.Enabled == "Y"
                select qc.Name;
            foreach (var name in query)
            {
                names.Add(name);
            }
            titleTextBox.Text = control.Name;
            qualList = new List<QualitativeRow>();
            quantList = new List<QuantitativeRow>();
            newQualList = new List<QualitativeRow>();
            newQuantList = new List<QuantitativeRow>();
            foreach (var row in control.QualityLabelQuals)
            {
                if (row.Enabled == "Y")
                {
                    QualitativeRow newRow = new QualitativeRow(row, false);
                    qualitativeTable.Controls.Add(newRow.toRemove);
                    qualitativeTable.Controls.Add(newRow.attribute);
                    qualitativeTable.Controls.Add(newRow.sustainTakeAction);
                    qualitativeTable.Controls.Add(newRow.comments);
                    qualList.Add(newRow);
                }
            }
            foreach (var row in control.QualityLabelQuants)
            {
                if (row.Enabled == "Y")
                {
                    QuantitativeRow newRow = new QuantitativeRow(row, false);
                    quantitativeTable.Controls.Add(newRow.toRemove);
                    quantitativeTable.Controls.Add(newRow.test);
                    quantitativeTable.Controls.Add(newRow.unit);
                    quantitativeTable.Controls.Add(newRow.value);
                    quantitativeTable.Controls.Add(newRow.aim);
                    quantitativeTable.Controls.Add(newRow.sustain);
                    quantitativeTable.Controls.Add(newRow.takeAction);
                    quantitativeTable.Controls.Add(newRow.abort);
                    quantitativeTable.Controls.Add(newRow.action);
                    quantList.Add(newRow);
                }
            }
            backButton.Visible = false;
            performedBy.Visible = false;
            label11.Visible = false;
            submitButton.Click += new EventHandler(this.creation_Save);
        }

        public GenericQualityControl(ProductEntry entry)
        {
            InitializeComponent();
            TitleLabel.Text = entry.Recipe.Name + " " + TitleLabel.Text;
            performedBy.Text = entry.QualityPerformer;
            foreach (var row in entry.ProductQualityEntryQuals)
            {
                QualitativeRow newRow = new QualitativeRow(row);
                qualitativeTable.Controls.Add(new Label());
                qualitativeTable.Controls.Add(newRow.attribute);
                qualitativeTable.Controls.Add(newRow.sustainTakeAction);
                qualitativeTable.Controls.Add(newRow.comments);
            }
            foreach (var row in entry.ProductQualityEntryQuants)
            {
                QuantitativeRow newRow = new QuantitativeRow(row);
                quantitativeTable.Controls.Add(new Label());
                quantitativeTable.Controls.Add(newRow.test);
                quantitativeTable.Controls.Add(newRow.unit);
                quantitativeTable.Controls.Add(newRow.value);
                quantitativeTable.Controls.Add(newRow.aim);
                quantitativeTable.Controls.Add(newRow.sustain);
                quantitativeTable.Controls.Add(newRow.takeAction);
                quantitativeTable.Controls.Add(newRow.abort);
                quantitativeTable.Controls.Add(newRow.action);
            }
            titleTextBox.Visible = false;
            addQuantRow.Visible = false;
            addQualRow.Visible = false;
            removeQual.Visible = false;
            removeQuant.Visible = false;
            qualitativeTable.ColumnStyles[0].Width = 1;
            quantitativeTable.ColumnStyles[0].Width = 1;
        }

        public GenericQualityControl(Recipe recipe, int view)
        {
            InitializeComponent();
            this.recipe = recipe;
            this.view = view;
            titleTextBox.Visible = false;
            addQualRow.Visible = false;
            addQuantRow.Visible = false;
            removeQual.Visible = false;
            removeQuant.Visible = false;
            TitleLabel.Text = recipe.QualityControl.Name + " " + TitleLabel.Text;
            submitButton.Click += new System.EventHandler(this.submitButton_Click);
            loadRows();
            qualitativeTable.ColumnStyles[0].Width = 1;
            quantitativeTable.ColumnStyles[0].Width = 1;
        }

        private void loadRows()
        {
            qualList = new List<QualitativeRow>();
            quantList = new List<QuantitativeRow>();
            foreach (var row in recipe.QualityControl.QualityLabelQuals)
            {
                if (row.Enabled == "Y")
                {
                    QualitativeRow newRow = new QualitativeRow(row, true);
                    qualitativeTable.Controls.Add(new Label());
                    qualitativeTable.Controls.Add(newRow.attribute);
                    qualitativeTable.Controls.Add(newRow.sustainTakeAction);
                    qualitativeTable.Controls.Add(newRow.comments);
                    qualList.Add(newRow);
                }
            }
            foreach (var row in recipe.QualityControl.QualityLabelQuants)
            {
                if (row.Enabled == "Y")
                {
                    QuantitativeRow newRow = new QuantitativeRow(row, true);
                    quantitativeTable.Controls.Add(new Label());
                    quantitativeTable.Controls.Add(newRow.test);
                    quantitativeTable.Controls.Add(newRow.unit);
                    quantitativeTable.Controls.Add(newRow.value);
                    quantitativeTable.Controls.Add(newRow.aim);
                    quantitativeTable.Controls.Add(newRow.sustain);
                    quantitativeTable.Controls.Add(newRow.takeAction);
                    quantitativeTable.Controls.Add(newRow.abort);
                    quantitativeTable.Controls.Add(newRow.action);
                    quantList.Add(newRow);
                }
            }
        }

        public class QualitativeRow
        {
            public QualityLabelQual labels;
            public CheckBox toRemove = new CheckBox();
            public TextBox attribute = new TextBox();
            public ComboBox sustainTakeAction = new ComboBox();
            public TextBox comments = new TextBox();

            public QualitativeRow(ProductQualityEntryQual entry)
                : this(entry.QualityLabelQual, true)
            {
                sustainTakeAction.SelectedValue = entry.SustainTakeAction;
                sustainTakeAction.Enabled = false;
                comments.Text = entry.Comments;
                comments.ReadOnly = true;
            }

            public QualitativeRow(QualityLabelQual row, Boolean isEnabled)
            {
                labels = row;
                attribute.Text = row.AttributeTesting;
                attribute.ReadOnly = isEnabled;
                attribute.Dock = DockStyle.Fill;
                sustainTakeAction.DataSource = new String[] { "Sustain", "Take Action" };
                sustainTakeAction.DropDownStyle = ComboBoxStyle.DropDownList;
                sustainTakeAction.Dock = DockStyle.Fill;
                sustainTakeAction.Enabled = isEnabled;
                comments.Dock = DockStyle.Fill;
                comments.ReadOnly = !isEnabled;
            }
        }


        public class QuantitativeRow
        {
            public QualityLabelQuant labels;
            public CheckBox toRemove = new CheckBox();
            public TextBox test = new TextBox();
            public TextBox unit = new TextBox();
            public TextBox value = new TextBox();
            public TextBox aim = new TextBox();
            public TextBox sustain = new TextBox();
            public TextBox takeAction = new TextBox();
            public TextBox abort = new TextBox();
            public TextBox action = new TextBox();

            public QuantitativeRow(ProductQualityEntryQuant entry)
                : this(entry.QualityLabelQuant, true)
            {
                value.Text = entry.Value;
                value.ReadOnly = true;
                action.Text = entry.Action;
                action.ReadOnly = true;
            }

            public QuantitativeRow(QualityLabelQuant row, Boolean isEnabled)
            {
                labels = row;
                test.Text = row.Test;
                test.ReadOnly = isEnabled;
                test.Dock = DockStyle.Fill;
                unit.Text = row.Unit;
                unit.ReadOnly = isEnabled;
                unit.Dock = DockStyle.Fill;
                value.Dock = DockStyle.Fill;
                value.ReadOnly = !isEnabled;
                aim.Text = row.Aim;
                aim.ReadOnly = isEnabled;
                aim.Dock = DockStyle.Fill;
                sustain.Text = row.Sustain;
                sustain.ReadOnly = isEnabled;
                sustain.Dock = DockStyle.Fill;
                takeAction.Text = row.TakeAction;
                takeAction.ReadOnly = isEnabled;
                takeAction.Dock = DockStyle.Fill;
                abort.Text = row.Abort;
                abort.ReadOnly = isEnabled;
                abort.Dock = DockStyle.Fill;
                action.Dock = DockStyle.Fill;
                action.ReadOnly = !isEnabled;
            }
        }

        private void creation_Save(object sender, EventArgs e)
        {
            control.Name = titleTextBox.Text;
            foreach (var row in qualList)
            {
                row.labels.Enabled = "Y";
                row.labels.AttributeTesting = row.attribute.Text;
                row.labels.QualityControl = control;
            }
            foreach (var row in quantList)
            {
                row.labels.Enabled = "Y";
                row.labels.Test = row.test.Text;
                row.labels.Unit = row.unit.Text;
                row.labels.Aim = row.aim.Text;
                row.labels.Sustain = row.sustain.Text;
                row.labels.TakeAction = row.takeAction.Text;
                row.labels.Abort = row.abort.Text;
                row.labels.QualityControl = control;
            }
            foreach (var row in newQualList)
            {
                QualityLabelQual qual = new QualityLabelQual()
                {
                    Enabled = "Y",
                    AttributeTesting = row.attribute.Text,
                    QualityControl = control
                };
                db.QualityLabelQuals.InsertOnSubmit(qual);
            }
            foreach (var row in newQuantList)
            {
                QualityLabelQuant quant = new QualityLabelQuant()
                {
                    Enabled = "Y",
                    Test = row.test.Text,
                    Unit = row.unit.Text,
                    Aim = row.aim.Text,
                    Sustain = row.sustain.Text,
                    TakeAction = row.takeAction.Text,
                    Abort = row.abort.Text,
                    QualityControl = control
                };
                db.QualityLabelQuants.InsertOnSubmit(quant);
            }
            db.SubmitChanges();
            Parent.BackColor = Color.White;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            ProductEntryControl.qcComplete[view] = true;
            Home.changeViewToProductEntry();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Home.changeViewToProductEntry();
        }

        private void addQualRow_Click(object sender, EventArgs e)
        {
            QualitativeRow newRow = new QualitativeRow(new QualityLabelQual(), false);
            qualitativeTable.Controls.Add(newRow.toRemove);
            qualitativeTable.Controls.Add(newRow.attribute);
            qualitativeTable.Controls.Add(newRow.sustainTakeAction);
            qualitativeTable.Controls.Add(newRow.comments);
            newQualList.Add(newRow);
        }

        private void addQuantRow_Click(object sender, EventArgs e)
        {
            QuantitativeRow newRow = new QuantitativeRow(new QualityLabelQuant(), false);
            quantitativeTable.Controls.Add(newRow.toRemove);
            quantitativeTable.Controls.Add(newRow.test);
            quantitativeTable.Controls.Add(newRow.unit);
            quantitativeTable.Controls.Add(newRow.value);
            quantitativeTable.Controls.Add(newRow.aim);
            quantitativeTable.Controls.Add(newRow.sustain);
            quantitativeTable.Controls.Add(newRow.takeAction);
            quantitativeTable.Controls.Add(newRow.abort);
            quantitativeTable.Controls.Add(newRow.action);
            newQuantList.Add(newRow);
        }

        private void removeQual_Click(object sender, EventArgs e)
        {
            List<QualitativeRow> toRemoveList = new List<QualitativeRow>();
            List<QualitativeRow> toRemoveNewList = new List<QualitativeRow>();
            foreach (var row in qualList)
            {
                if (row.toRemove.Checked)
                {
                    toRemoveList.Add(row);
                }
            }
            foreach (var row in newQualList)
            {
                if (row.toRemove.Checked)
                {
                    toRemoveNewList.Add(row);
                }
            }
            foreach (var row in toRemoveList)
            {
                qualList.Remove(row);
                qualitativeTable.Controls.Remove(row.toRemove);
                qualitativeTable.Controls.Remove(row.attribute);
                qualitativeTable.Controls.Remove(row.sustainTakeAction);
                qualitativeTable.Controls.Remove(row.comments);
                row.labels.Enabled = "N";
            }
            foreach (var row in toRemoveNewList)
            {
                newQualList.Remove(row);
                qualitativeTable.Controls.Remove(row.toRemove);
                qualitativeTable.Controls.Remove(row.attribute);
                qualitativeTable.Controls.Remove(row.sustainTakeAction);
                qualitativeTable.Controls.Remove(row.comments);
            }
        }

        private void removeQuant_Click(object sender, EventArgs e)
        {
            List<QuantitativeRow> toRemoveList = new List<QuantitativeRow>();
            List<QuantitativeRow> toRemoveNewList = new List<QuantitativeRow>();
            foreach (var row in quantList)
            {
                if (row.toRemove.Checked)
                {
                    toRemoveList.Add(row);
                }
            }
            foreach (var row in newQuantList)
            {
                if (row.toRemove.Checked)
                {
                    toRemoveNewList.Add(row);
                }
            }
            foreach (var row in toRemoveList)
            {
                quantList.Remove(row);
                quantitativeTable.Controls.Remove(row.toRemove);
                quantitativeTable.Controls.Remove(row.test);
                quantitativeTable.Controls.Remove(row.unit);
                quantitativeTable.Controls.Remove(row.value);
                quantitativeTable.Controls.Remove(row.aim);
                quantitativeTable.Controls.Remove(row.sustain);
                quantitativeTable.Controls.Remove(row.takeAction);
                quantitativeTable.Controls.Remove(row.abort);
                quantitativeTable.Controls.Remove(row.action);
                row.labels.Enabled = "N";
            }
            foreach (var row in toRemoveNewList)
            {
                newQuantList.Remove(row);
                quantitativeTable.Controls.Remove(row.toRemove);
                quantitativeTable.Controls.Remove(row.test);
                quantitativeTable.Controls.Remove(row.unit);
                quantitativeTable.Controls.Remove(row.value);
                quantitativeTable.Controls.Remove(row.aim);
                quantitativeTable.Controls.Remove(row.sustain);
                quantitativeTable.Controls.Remove(row.takeAction);
                quantitativeTable.Controls.Remove(row.abort);
                quantitativeTable.Controls.Remove(row.action);
            }
        }

        private void nameValidation(object sender, CancelEventArgs e)
        {
            if (!names.Add(((TextBox)sender).Text))
            {
                MessageBox.Show("This name already exists. Please choose another.");
                ((TextBox)sender).Text = "";
                ((TextBox)sender).Select();
            }
        }

        private void removeExisting(object sender, EventArgs e)
        {
            names.Remove(((TextBox)sender).Text);
        }
    }
}
