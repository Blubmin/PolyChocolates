namespace PolyChocolates
{
    partial class SearchEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchEntry));
            this.container = new System.Windows.Forms.Panel();
            this.ResultsTable = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.container.SuspendLayout();
            this.ResultsTable.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.container.AutoScroll = true;
            this.container.BackColor = System.Drawing.Color.White;
            this.container.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.container.Controls.Add(this.ResultsTable);
            this.container.Location = new System.Drawing.Point(4, 25);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1075, 620);
            this.container.TabIndex = 48;
            // 
            // ResultsTable
            // 
            this.ResultsTable.AutoSize = true;
            this.ResultsTable.ColumnCount = 1;
            this.ResultsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ResultsTable.Controls.Add(this.panel1, 0, 0);
            this.ResultsTable.Controls.Add(this.panel3, 0, 2);
            this.ResultsTable.Location = new System.Drawing.Point(-2, 2);
            this.ResultsTable.Margin = new System.Windows.Forms.Padding(2);
            this.ResultsTable.Name = "ResultsTable";
            this.ResultsTable.RowCount = 7;
            this.ResultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.ResultsTable.Size = new System.Drawing.Size(1049, 612);
            this.ResultsTable.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 4);
            this.panel1.TabIndex = 46;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(0, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 4);
            this.panel3.TabIndex = 47;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1091, 24);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.printToolStripMenuItem.Text = "Save";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // SearchEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 649);
            this.Controls.Add(this.container);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SearchEntry";
            this.Text = "SearchEntry";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.ResultsTable.ResumeLayout(false);
            this.ResultsTable.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.TableLayoutPanel ResultsTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument2;
    }
}