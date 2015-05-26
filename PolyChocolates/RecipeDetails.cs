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
    public partial class RecipeDetails : UserControl
    {
        Home home;
        databaseDataContext db = new databaseDataContext();
        List<IngredientRow> recipeIngredientList = new List<IngredientRow>();
        List<StepRow> stepList = new List<StepRow>();
        Recipe recipe;
        RecipeControl parent;
        List<String> qualityTypes;
        public byte[] haccp = null;

        public RecipeDetails(Home home, String recipeName, RecipeControl parent)
        {
            InitializeComponent();
            this.home = home;
            this.parent = parent;
            var query =
                from recipes in db.Recipes
                where recipes.Name == recipeName && recipes.Enabled == "Y"
                select recipes;
            foreach (var r in query)
            {
                recipe = r;
            }
            var query2 =
                from qcs in db.QualityControls
                where qcs.Enabled == "Y"
                select qcs.Name;
            qualityControl.DataSource = query2;
            qualityTypes = new List<string>();
            foreach (var name in query2)
            {
                qualityTypes.Add(name);
            }
            loadValues();
            expectedWeight.Leave += new EventHandler(Library.onlyAllowFloats);

            loadHACCPIcon(null, null);
            haccpIcon.Click += new EventHandler(attachHAACPWindow);
        }

        private void attachHAACPWindow(object sender, EventArgs e)
        {
            HACCP haccp = new HACCP(this);
            haccp.ShowDialog();
            if (this.haccpIcon != null)
                haccpIcon.Image = InventoryControl.document;
            else
                haccpIcon.Image = InventoryControl.blankDocument;
        }

        private void loadHACCPIcon(object sender, EventArgs e)
        {
            if (this.haccp != null && this.haccp.Length > 0)
                haccpIcon.Image = InventoryControl.document;
            else
                haccpIcon.Image = InventoryControl.blankDocument;
        }

        private void loadValues()
        {
            recipeName.Text = recipe.Name;
            
            if ( "Y".Equals(recipe.EfficiencyRequired))
            {
                effeciencyRequired.SelectedIndex = 0;
                expectedWeight.Enabled = true;
            }
            else
            {
                effeciencyRequired.SelectedIndex = 1;
                expectedWeight.Enabled = false;
            }
            expectedWeight.Text = recipe.ExpectedWeight + "";
            if ("Y".Equals(recipe.TraceabilityRequired))
            {
                traceabilityRequired.SelectedIndex = 0;
            }
            else
            {
                traceabilityRequired.SelectedIndex = 1;
            }
            qualityControl.SelectedIndex = qualityTypes.IndexOf(recipe.QualityControl.Name);
            foreach (var rI in recipe.RecipeIngredients)
            {
                IngredientRow row = new IngredientRow(this, rI.Ingredient, rI.Amount + "", rI.Unit);
                recipeIngredientList.Add(row);
                recipeIngredients.Controls.Add(row.toRemove);
                recipeIngredients.Controls.Add(row.ingredient);
                recipeIngredients.Controls.Add(row.amount);
                recipeIngredients.Controls.Add(row.unit);
            }
            foreach (var rS in recipe.RecipeSteps)
            {
                StepRow row = new StepRow(this, rS.StepNumber + "", rS.StepInstructions + "");
                stepList.Add(row);
                recipeSteps.Controls.Add(row.toDelete);
                recipeSteps.Controls.Add(row.stepNo);
                recipeSteps.Controls.Add(row.instructions);
            }

            if (recipe.haccp != null)
                haccp = recipe.haccp.ToArray();
        }



        private void add_Click(object sender, EventArgs e)
        {
            IngredientRow row = new IngredientRow(this);
            recipeIngredientList.Add(row);
            recipeIngredients.Controls.Add(row.ingredient);
            recipeIngredients.Controls.Add(row.amount);
            recipeIngredients.Controls.Add(row.unit);
        }

        private class IngredientRow
        {
            public CheckBox toRemove = new CheckBox();
            public TextBox ingredient = new TextBox();
            public TextBox amount = new TextBox();
            public TextBox unit = new TextBox();

            public IngredientRow(RecipeDetails details) : this(details, "", "0", "") {}

            public IngredientRow(RecipeDetails details, String ingredient, String amount, String unit)
            {
                this.ingredient.Text = ingredient;
                this.ingredient.Padding = new Padding(3);
                this.ingredient.Dock = DockStyle.Fill;
                this.amount.Text = amount;
                this.amount.Dock = DockStyle.Fill;
                this.amount.Leave += new EventHandler(Library.onlyAllowFloats);
                this.unit.Text = unit;
                this.unit.Dock = DockStyle.Fill;
            }
        }

        private class StepRow
        {
            public CheckBox toDelete = new CheckBox();
            public Label stepNo = new Label();
            public TextBox instructions = new TextBox();

            public StepRow(RecipeDetails parent, String number) : this(parent, number, "") { }

            public StepRow(RecipeDetails parent, String number, String details)
            {
                this.stepNo.Text = number;
                this.stepNo.AutoSize = true;
                this.stepNo.Dock = DockStyle.Fill;
                this.stepNo.Margin = new Padding(0);
                this.stepNo.Padding = new Padding(3);
                this.stepNo.Font = new Font(this.stepNo.Font, FontStyle.Bold);
                this.instructions.Text = details;
                this.instructions.Multiline = true;
                this.instructions.AutoSize = true;
                this.instructions.Dock = DockStyle.Fill;
                this.instructions.TextChanged += new EventHandler(RecipeDetails.step_TextChanged);
            }
        }

        private void addIngredient_Click(object sender, EventArgs e)
        {
            IngredientRow row = new IngredientRow(this);
            recipeIngredientList.Add(row);
            recipeIngredients.Controls.Add(row.toRemove);
            recipeIngredients.Controls.Add(row.ingredient);
            recipeIngredients.Controls.Add(row.amount);
            recipeIngredients.Controls.Add(row.unit);
        }

        private void addStep_Click(object sender, EventArgs e)
        {

            StepRow row = new StepRow(this, stepList.Count() + 1 + "");
            stepList.Add(row);
            recipeSteps.Controls.Add(row.toDelete);
            recipeSteps.Controls.Add(row.stepNo);
            recipeSteps.Controls.Add(row.instructions);
        }

        private static void step_TextChanged(object sender, EventArgs e)
        {

            Size size = TextRenderer.MeasureText(((TextBox)sender).Text, ((TextBox)sender).Font);
            ((TextBox)sender).Width = size.Width;
            ((TextBox)sender).Height = Math.Max(size.Height + ((TextBox)sender).Margin.All * 2, ((TextBox)sender).PreferredHeight);
        }

        private void cancel_Click(object sender, EventArgs e)
        {

            parent.refreshDetails(recipe);
        }

        private void deleteStep_Click(object sender, EventArgs e)
        {
            List<StepRow> toDelete = new List<StepRow>();
            var rowNo = 1;
            foreach (var row in stepList)
            {
                if (row.toDelete.Checked)
                {
                    toDelete.Add(row);
                    recipeSteps.Controls.Remove(row.toDelete);
                    recipeSteps.Controls.Remove(row.stepNo);
                    recipeSteps.Controls.Remove(row.instructions);
                }
                else
                {
                    row.stepNo.Text = rowNo++ + "";
                }
            }
            foreach (var row in toDelete)
            {
                stepList.Remove(row);
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            recipe.Name = recipeName.Text;
            recipe.EfficiencyRequired = effeciencyRequired.Text.Substring(0, 1);
            recipe.TraceabilityRequired = traceabilityRequired.Text.Substring(0, 1);
            var query =
                from quality in db.QualityControls
                where quality.Name.Equals(qualityControl.Text)
                select quality;
            if (!expectedWeight.Enabled)
            {
                expectedWeight.Text = "0";
            }
            foreach (var q in query)
            {
                recipe.QualityControl = q;
                recipe.ExpectedWeight = Double.Parse(expectedWeight.Text);
            }
            recipe.haccp = this.haccp;

            db.SubmitChanges();
            submitRecipeIngredients();
            submitRecipeSteps();
            parent.refreshDetails(recipe);

            home.refreshProductEntry();
        }

        private void submitRecipeIngredients()
        {
            var query =
                from ing in db.RecipeIngredients
                where ing.Recipe == recipe
                select ing;
            db.RecipeIngredients.DeleteAllOnSubmit(query);
            db.SubmitChanges();
            foreach (var ing in recipeIngredientList)
            {
                var newRecipeIngredient = new RecipeIngredient
                {
                    Ingredient = ing.ingredient.Text,
                    Amount = Int32.Parse(ing.amount.Text),
                    Unit = ing.unit.Text,
                    Recipe = recipe,
                };
                db.RecipeIngredients.InsertOnSubmit(newRecipeIngredient);
            }
            db.SubmitChanges();
        }

        private void submitRecipeSteps()
        {
            var query =
                from step in db.RecipeSteps
                where step.Recipe == recipe
                select step;
            db.RecipeSteps.DeleteAllOnSubmit(query);
            db.SubmitChanges();
            foreach (var step in stepList)
            {
                var newStep = new RecipeStep
                {
                    Recipe = recipe,
                    StepNumber = Int32.Parse(step.stepNo.Text),
                    StepInstructions = step.instructions.Text
                };
                db.RecipeSteps.InsertOnSubmit(newStep);
            }
            db.SubmitChanges();
        }

        private void removeIngredient_Click(object sender, EventArgs e)
        {
            List<IngredientRow> toRemove = new List<IngredientRow>();
            foreach (var row in recipeIngredientList)
            {
                if (row.toRemove.Checked)
                {
                    recipeIngredients.Controls.Remove(row.toRemove);
                    recipeIngredients.Controls.Remove(row.ingredient);
                    recipeIngredients.Controls.Remove(row.amount);
                    recipeIngredients.Controls.Remove(row.unit);
                    toRemove.Add(row);
                }
            }
            foreach (var row in toRemove)
            {
                recipeIngredientList.Remove(row);
            }
        }

        private void requireEfficiency_Changed(object sender, EventArgs e)
        {

            expectedWeight.Enabled = effeciencyRequired.SelectedIndex == 0;
            if (expectedWeight.Enabled)
            {
                expectedWeight.Text = "0";
            }

        }
    }
}
