namespace PolyChocolates
{
    partial class RecipeControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recipeList = new System.Windows.Forms.TableLayoutPanel();
            this.recipeDetails = new System.Windows.Forms.Panel();
            this.newRecipeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(178, 13);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(113, 31);
            this.TitleLabel.TabIndex = 13;
            this.TitleLabel.Text = "Recipes";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.recipeList);
            this.panel1.Location = new System.Drawing.Point(128, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 501);
            this.panel1.TabIndex = 14;
            // 
            // recipeList
            // 
            this.recipeList.AutoScroll = true;
            this.recipeList.AutoSize = true;
            this.recipeList.ColumnCount = 1;
            this.recipeList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 239F));
            this.recipeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeList.Location = new System.Drawing.Point(0, 0);
            this.recipeList.Name = "recipeList";
            this.recipeList.RowCount = 2;
            this.recipeList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.recipeList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.recipeList.Size = new System.Drawing.Size(239, 497);
            this.recipeList.TabIndex = 0;
            // 
            // recipeDetails
            // 
            this.recipeDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recipeDetails.Location = new System.Drawing.Point(417, 52);
            this.recipeDetails.Name = "recipeDetails";
            this.recipeDetails.Size = new System.Drawing.Size(682, 530);
            this.recipeDetails.TabIndex = 15;
            // 
            // newRecipeButton
            // 
            this.newRecipeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newRecipeButton.Location = new System.Drawing.Point(130, 559);
            this.newRecipeButton.Name = "newRecipeButton";
            this.newRecipeButton.Size = new System.Drawing.Size(241, 23);
            this.newRecipeButton.TabIndex = 16;
            this.newRecipeButton.Text = "New Recipe";
            this.newRecipeButton.UseVisualStyleBackColor = true;
            this.newRecipeButton.Click += new System.EventHandler(this.newRecipe_Click);
            // 
            // RecipeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newRecipeButton);
            this.Controls.Add(this.recipeDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TitleLabel);
            this.Name = "RecipeControl";
            this.Size = new System.Drawing.Size(1166, 605);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel recipeDetails;
        private System.Windows.Forms.Button newRecipeButton;
        private System.Windows.Forms.TableLayoutPanel recipeList;
    }
}
