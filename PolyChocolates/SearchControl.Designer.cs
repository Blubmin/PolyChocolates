namespace PolyChocolates
{
    partial class SearchControl
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.searchResults = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.searchType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.searchResults.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(132, 24);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(100, 31);
            this.TitleLabel.TabIndex = 12;
            this.TitleLabel.Text = "Search";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(261, 59);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(142, 20);
            this.searchBox.TabIndex = 13;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(409, 59);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 15;
            this.SearchButton.Text = "Filter";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchResults
            // 
            this.searchResults.AutoSize = true;
            this.searchResults.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.searchResults.ColumnCount = 7;
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.Controls.Add(this.label6, 0, 0);
            this.searchResults.Controls.Add(this.label5, 5, 0);
            this.searchResults.Controls.Add(this.label4, 4, 0);
            this.searchResults.Controls.Add(this.label3, 3, 0);
            this.searchResults.Controls.Add(this.label2, 2, 0);
            this.searchResults.Controls.Add(this.label1, 1, 0);
            this.searchResults.Controls.Add(this.label7, 6, 0);
            this.searchResults.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchResults.Location = new System.Drawing.Point(0, 0);
            this.searchResults.Name = "searchResults";
            this.searchResults.RowCount = 2;
            this.searchResults.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.searchResults.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.searchResults.Size = new System.Drawing.Size(857, 25);
            this.searchResults.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(378, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pilot Manager";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(235, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Student Manager";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(184, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code Date";
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ResultsLabel.Location = new System.Drawing.Point(135, 115);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(0, 16);
            this.ResultsLabel.TabIndex = 17;
            // 
            // searchType
            // 
            this.searchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchType.FormattingEnabled = true;
            this.searchType.Items.AddRange(new object[] {
            "Code Date",
            "Product Type",
            "Inventory Lot Code",
            "Status"});
            this.searchType.Location = new System.Drawing.Point(137, 58);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(118, 21);
            this.searchType.TabIndex = 18;
            this.searchType.SelectedIndexChanged += new System.EventHandler(this.searchType_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.searchResults);
            this.panel1.Location = new System.Drawing.Point(135, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 504);
            this.panel1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 18);
            this.label6.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(498, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Status";
            // 
            // SearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchType);
            this.Controls.Add(this.ResultsLabel);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.TitleLabel);
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(1166, 605);
            this.searchResults.ResumeLayout(false);
            this.searchResults.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label ResultsLabel;
        private System.Windows.Forms.TableLayoutPanel searchResults;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox searchType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
