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
    public partial class RecipeControl : UserControl
    {
        databaseDataContext db = new databaseDataContext();
        List<Panel> recipeNames = new List<Panel>();
        Label selectedRecipe = null;
        Home home;

        public RecipeControl(Home home)
        {
            InitializeComponent();
            this.home = home;
            initializeList();
        }

        private void initializeList()
        {

            var query =
                from recipes in db.Recipes
                where recipes.RecipeId > 1
                orderby recipes.Name
                select recipes;
            recipeList.Controls.Clear();
            recipeList.RowCount = query.Count() + 1;
            recipeNames.Clear();
            int row = 0;
            recipeList.RowStyles.Clear();
            foreach(var recipe in query)
            {
                RowStyle style = new RowStyle(SizeType.Absolute, 20);
                recipeList.RowStyles.Add(style);
                Panel panel = new Panel();
                panel.Margin = new Padding(0);
                Label lbl = new Label();
                lbl.Dock = DockStyle.Fill;
                lbl.Text = recipe.Name;
                lbl.Click += new EventHandler(this.lbl_Click);
                panel.Controls.Add(lbl);
                panel.Width = recipeList.Width;
                panel.Dock = DockStyle.Fill;
                recipeNames.Add(panel);
                recipeList.Controls.Add(panel, 0, row++);
            }
            Label blank = new Label();
            blank.Text = "";
            recipeList.Controls.Add(blank, 0, row);
        }

        private void lbl_Click(object sender, EventArgs e)
        {

            foreach (Panel panel in recipeNames)
            {
                panel.BackColor = Color.White;
                if (panel.Controls.Contains((Label)sender))
                {
                    panel.BackColor = Color.Gainsboro;
                }
            }
            recipeDetails.Controls.Clear();
            recipeDetails.Controls.Add(new RecipeDetails(home, ((Label)sender).Text, this));
            selectedRecipe = (Label)sender;
        }

        public void refreshDetails(Recipe theRecipe)
        {
            selectedRecipe.Text = theRecipe.Name;
            
            recipeDetails.Controls.Clear();
            recipeDetails.Controls.Add(new RecipeDetails(home, theRecipe.Name, this));
        }

        private void newRecipe_Click(object sender, EventArgs e)
        {

            NewRecipe panel = new NewRecipe();
            panel.ShowDialog();
            initializeList();
        }

        private void deleteRecipeButton_Click(object sender, EventArgs e)
        {

            var query =
                from recipe in db.Recipes
                where recipe.Name == selectedRecipe.Text
                select recipe;
            db.Recipes.DeleteAllOnSubmit(query);
            foreach (var recipe in query)
            {
                db.RecipeSteps.DeleteAllOnSubmit(recipe.RecipeSteps);
                db.RecipeIngredients.DeleteAllOnSubmit(recipe.RecipeIngredients);
                //db.ProductEntries.DeleteAllOnSubmit();
            }
            db.SubmitChanges();
            initializeList();
            selectedRecipe = null;
        }
    }
}
