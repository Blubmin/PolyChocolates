namespace PolyChocolates
{
    partial class RecipeDetails
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeDetails));
            this.recipeName = new System.Windows.Forms.TextBox();
            this.apply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.recipeIngredients = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.recipeSteps = new System.Windows.Forms.TableLayoutPanel();
            this.addStep = new System.Windows.Forms.Button();
            this.deleteStep = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.addIngredient = new System.Windows.Forms.Button();
            this.removeIngredient = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.traceabilityRequired = new System.Windows.Forms.ComboBox();
            this.effeciencyRequired = new System.Windows.Forms.ComboBox();
            this.qualityControl = new System.Windows.Forms.ComboBox();
            this.databaseDataSet = new PolyChocolates.databaseDataSet();
            this.databaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAL_POLY_CHOC_DBDataSet = new PolyChocolates.CAL_POLY_CHOC_DBDataSet();
            this.cALPOLYCHOCDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseDataSet1 = new PolyChocolates.databaseDataSet1();
            this.databaseDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.expectedWeight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.haccpIcon = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAL_POLY_CHOC_DBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cALPOLYCHOCDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.haccpIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // recipeName
            // 
            this.recipeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeName.Location = new System.Drawing.Point(3, 3);
            this.recipeName.Name = "recipeName";
            this.recipeName.Size = new System.Drawing.Size(672, 38);
            this.recipeName.TabIndex = 0;
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(600, 498);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 1;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingredients";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.recipeIngredients);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(135, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 187);
            this.panel2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(353, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Units";
            // 
            // recipeIngredients
            // 
            this.recipeIngredients.AutoSize = true;
            this.recipeIngredients.ColumnCount = 4;
            this.recipeIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.recipeIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.recipeIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.recipeIngredients.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.recipeIngredients.Location = new System.Drawing.Point(3, 30);
            this.recipeIngredients.Name = "recipeIngredients";
            this.recipeIngredients.RowCount = 1;
            this.recipeIngredients.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recipeIngredients.Size = new System.Drawing.Size(516, 27);
            this.recipeIngredients.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(188, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ingredient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Steps";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.recipeSteps);
            this.panel3.Location = new System.Drawing.Point(3, 343);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(672, 149);
            this.panel3.TabIndex = 9;
            // 
            // recipeSteps
            // 
            this.recipeSteps.AutoScroll = true;
            this.recipeSteps.AutoSize = true;
            this.recipeSteps.ColumnCount = 3;
            this.recipeSteps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.recipeSteps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.recipeSteps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.recipeSteps.Location = new System.Drawing.Point(3, 3);
            this.recipeSteps.Name = "recipeSteps";
            this.recipeSteps.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.recipeSteps.RowCount = 1;
            this.recipeSteps.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.recipeSteps.Size = new System.Drawing.Size(648, 20);
            this.recipeSteps.TabIndex = 0;
            // 
            // addStep
            // 
            this.addStep.Location = new System.Drawing.Point(3, 498);
            this.addStep.Name = "addStep";
            this.addStep.Size = new System.Drawing.Size(75, 23);
            this.addStep.TabIndex = 11;
            this.addStep.Text = "Add";
            this.addStep.UseVisualStyleBackColor = true;
            this.addStep.Click += new System.EventHandler(this.addStep_Click);
            // 
            // deleteStep
            // 
            this.deleteStep.Location = new System.Drawing.Point(84, 498);
            this.deleteStep.Name = "deleteStep";
            this.deleteStep.Size = new System.Drawing.Size(75, 23);
            this.deleteStep.TabIndex = 12;
            this.deleteStep.Text = "Remove";
            this.deleteStep.UseVisualStyleBackColor = true;
            this.deleteStep.Click += new System.EventHandler(this.deleteStep_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(519, 498);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // addIngredient
            // 
            this.addIngredient.Location = new System.Drawing.Point(135, 284);
            this.addIngredient.Name = "addIngredient";
            this.addIngredient.Size = new System.Drawing.Size(75, 23);
            this.addIngredient.TabIndex = 14;
            this.addIngredient.Text = "Add";
            this.addIngredient.UseVisualStyleBackColor = true;
            this.addIngredient.Click += new System.EventHandler(this.addIngredient_Click);
            // 
            // removeIngredient
            // 
            this.removeIngredient.Location = new System.Drawing.Point(216, 284);
            this.removeIngredient.Name = "removeIngredient";
            this.removeIngredient.Size = new System.Drawing.Size(75, 23);
            this.removeIngredient.TabIndex = 15;
            this.removeIngredient.Text = "Remove";
            this.removeIngredient.UseVisualStyleBackColor = true;
            this.removeIngredient.Click += new System.EventHandler(this.removeIngredient_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Require Traceability:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Require Efficiency:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Quality Control Form:";
            // 
            // traceabilityRequired
            // 
            this.traceabilityRequired.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traceabilityRequired.FormattingEnabled = true;
            this.traceabilityRequired.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.traceabilityRequired.Location = new System.Drawing.Point(7, 92);
            this.traceabilityRequired.Name = "traceabilityRequired";
            this.traceabilityRequired.Size = new System.Drawing.Size(121, 21);
            this.traceabilityRequired.TabIndex = 19;
            // 
            // effeciencyRequired
            // 
            this.effeciencyRequired.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effeciencyRequired.FormattingEnabled = true;
            this.effeciencyRequired.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.effeciencyRequired.Location = new System.Drawing.Point(7, 144);
            this.effeciencyRequired.Name = "effeciencyRequired";
            this.effeciencyRequired.Size = new System.Drawing.Size(121, 21);
            this.effeciencyRequired.TabIndex = 20;
            this.effeciencyRequired.SelectedValueChanged += new System.EventHandler(this.requireEfficiency_Changed);
            // 
            // qualityControl
            // 
            this.qualityControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityControl.FormattingEnabled = true;
            this.qualityControl.Location = new System.Drawing.Point(7, 236);
            this.qualityControl.Name = "qualityControl";
            this.qualityControl.Size = new System.Drawing.Size(121, 21);
            this.qualityControl.TabIndex = 21;
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "databaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // databaseDataSetBindingSource
            // 
            this.databaseDataSetBindingSource.DataSource = this.databaseDataSet;
            this.databaseDataSetBindingSource.Position = 0;
            // 
            // cAL_POLY_CHOC_DBDataSet
            // 
            this.cAL_POLY_CHOC_DBDataSet.DataSetName = "CAL_POLY_CHOC_DBDataSet";
            this.cAL_POLY_CHOC_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cALPOLYCHOCDBDataSetBindingSource
            // 
            this.cALPOLYCHOCDBDataSetBindingSource.DataSource = this.cAL_POLY_CHOC_DBDataSet;
            this.cALPOLYCHOCDBDataSetBindingSource.Position = 0;
            // 
            // databaseDataSet1
            // 
            this.databaseDataSet1.DataSetName = "databaseDataSet1";
            this.databaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // databaseDataSet1BindingSource
            // 
            this.databaseDataSet1BindingSource.DataSource = this.databaseDataSet1;
            this.databaseDataSet1BindingSource.Position = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Expected Weight (lbs):";
            // 
            // expectedWeight
            // 
            this.expectedWeight.Enabled = false;
            this.expectedWeight.Location = new System.Drawing.Point(7, 184);
            this.expectedWeight.Name = "expectedWeight";
            this.expectedWeight.Size = new System.Drawing.Size(121, 20);
            this.expectedWeight.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "HACCP Plan:";
            // 
            // haccpIcon
            // 
            this.haccpIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("haccpIcon.InitialImage")));
            this.haccpIcon.Location = new System.Drawing.Point(54, 280);
            this.haccpIcon.Name = "haccpIcon";
            this.haccpIcon.Size = new System.Drawing.Size(24, 27);
            this.haccpIcon.TabIndex = 25;
            this.haccpIcon.TabStop = false;
            // 
            // RecipeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.haccpIcon);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.expectedWeight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.qualityControl);
            this.Controls.Add(this.effeciencyRequired);
            this.Controls.Add(this.traceabilityRequired);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.removeIngredient);
            this.Controls.Add(this.addIngredient);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.deleteStep);
            this.Controls.Add(this.addStep);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.recipeName);
            this.Name = "RecipeDetails";
            this.Size = new System.Drawing.Size(678, 525);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAL_POLY_CHOC_DBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cALPOLYCHOCDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.haccpIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox recipeName;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel recipeIngredients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel recipeSteps;
        private System.Windows.Forms.Button addStep;
        private System.Windows.Forms.Button deleteStep;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button addIngredient;
        private System.Windows.Forms.Button removeIngredient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox traceabilityRequired;
        private System.Windows.Forms.ComboBox effeciencyRequired;
        private System.Windows.Forms.ComboBox qualityControl;
        private databaseDataSet databaseDataSet;
        private System.Windows.Forms.BindingSource databaseDataSetBindingSource;
        private CAL_POLY_CHOC_DBDataSet cAL_POLY_CHOC_DBDataSet;
        private System.Windows.Forms.BindingSource cALPOLYCHOCDBDataSetBindingSource;
        private databaseDataSet1 databaseDataSet1;
        private System.Windows.Forms.BindingSource databaseDataSet1BindingSource;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox expectedWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox haccpIcon;
    }
}
