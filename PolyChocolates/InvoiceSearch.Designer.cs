namespace PolyChocolates
{
    partial class InvoiceSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchResults = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.searchType = new System.Windows.Forms.ComboBox();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.searchResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.searchResults);
            this.panel1.Location = new System.Drawing.Point(141, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 509);
            this.panel1.TabIndex = 25;
            // 
            // searchResults
            // 
            this.searchResults.AutoScroll = true;
            this.searchResults.AutoSize = true;
            this.searchResults.BackColor = System.Drawing.SystemColors.Control;
            this.searchResults.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.searchResults.ColumnCount = 6;
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchResults.Controls.Add(this.label5, 0, 0);
            this.searchResults.Controls.Add(this.label2, 2, 0);
            this.searchResults.Controls.Add(this.label3, 3, 0);
            this.searchResults.Controls.Add(this.label1, 1, 0);
            this.searchResults.Controls.Add(this.label4, 4, 0);
            this.searchResults.Controls.Add(this.label6, 5, 0);
            this.searchResults.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchResults.Location = new System.Drawing.Point(0, 0);
            this.searchResults.Name = "searchResults";
            this.searchResults.RowCount = 2;
            this.searchResults.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.searchResults.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.searchResults.Size = new System.Drawing.Size(878, 505);
            this.searchResults.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 18);
            this.label5.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(254, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Account Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(396, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(448, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Amount";
            // 
            // searchType
            // 
            this.searchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchType.FormattingEnabled = true;
            this.searchType.Items.AddRange(new object[] {
            "Invoice Number",
            "Customer",
            "Code Date"});
            this.searchType.Location = new System.Drawing.Point(141, 50);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(118, 21);
            this.searchType.TabIndex = 24;
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Font = new System.Drawing.Font("Eras Light ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ResultsLabel.Location = new System.Drawing.Point(141, 69);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(0, 17);
            this.ResultsLabel.TabIndex = 23;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(413, 51);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 22;
            this.SearchButton.Text = "Filter";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(265, 51);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(142, 20);
            this.searchBox.TabIndex = 21;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TitleLabel.Location = new System.Drawing.Point(138, 16);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(194, 31);
            this.TitleLabel.TabIndex = 20;
            this.TitleLabel.Text = "Invoice Search";
            // 
            // InvoiceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchType);
            this.Controls.Add(this.ResultsLabel);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.TitleLabel);
            this.Name = "InvoiceSearch";
            this.Size = new System.Drawing.Size(1166, 605);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.searchResults.ResumeLayout(false);
            this.searchResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel searchResults;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox searchType;
        private System.Windows.Forms.Label ResultsLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label label6;
    }
}
