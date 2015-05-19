namespace PolyChocolates
{
    partial class QualityWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QualityWindow));
            this.qualityPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.qualityTable = new System.Windows.Forms.TableLayoutPanel();
            this.newQualityButton = new System.Windows.Forms.Button();
            this.removeSelected = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qualityPanel
            // 
            this.qualityPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.qualityPanel.Location = new System.Drawing.Point(201, 1);
            this.qualityPanel.Name = "qualityPanel";
            this.qualityPanel.Size = new System.Drawing.Size(1112, 605);
            this.qualityPanel.TabIndex = 0;
            this.qualityPanel.BackColorChanged += new System.EventHandler(this.refreshList);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.qualityTable);
            this.panel1.Location = new System.Drawing.Point(12, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 534);
            this.panel1.TabIndex = 0;
            // 
            // qualityTable
            // 
            this.qualityTable.AutoSize = true;
            this.qualityTable.ColumnCount = 2;
            this.qualityTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.qualityTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.qualityTable.Location = new System.Drawing.Point(3, 3);
            this.qualityTable.Name = "qualityTable";
            this.qualityTable.RowCount = 1;
            this.qualityTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.qualityTable.Size = new System.Drawing.Size(173, 27);
            this.qualityTable.TabIndex = 0;
            // 
            // newQualityButton
            // 
            this.newQualityButton.AutoSize = true;
            this.newQualityButton.Location = new System.Drawing.Point(120, 583);
            this.newQualityButton.Name = "newQualityButton";
            this.newQualityButton.Size = new System.Drawing.Size(75, 23);
            this.newQualityButton.TabIndex = 0;
            this.newQualityButton.Text = "New Quality";
            this.newQualityButton.UseVisualStyleBackColor = true;
            this.newQualityButton.Click += new System.EventHandler(this.newQualityButton_Click);
            // 
            // removeSelected
            // 
            this.removeSelected.AutoSize = true;
            this.removeSelected.Location = new System.Drawing.Point(12, 583);
            this.removeSelected.Name = "removeSelected";
            this.removeSelected.Size = new System.Drawing.Size(102, 23);
            this.removeSelected.TabIndex = 1;
            this.removeSelected.Text = "Remove Selected";
            this.removeSelected.UseVisualStyleBackColor = true;
            this.removeSelected.Click += new System.EventHandler(this.removeSelected_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(91, 31);
            this.TitleLabel.TabIndex = 47;
            this.TitleLabel.Text = "Forms";
            // 
            // QualityWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 607);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.removeSelected);
            this.Controls.Add(this.newQualityButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.qualityPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QualityWindow";
            this.Text = "Quality Control Forms";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel qualityPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newQualityButton;
        private System.Windows.Forms.Button removeSelected;
        private System.Windows.Forms.TableLayoutPanel qualityTable;
        private System.Windows.Forms.Label TitleLabel;
    }
}