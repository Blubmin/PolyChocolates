namespace PolyChocolates
{
    partial class COA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COA));
            this.Add = new System.Windows.Forms.Button();
            this.certificate = new System.Windows.Forms.PictureBox();
            this.browse = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.certificate)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(90, 420);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(88, 23);
            this.Add.TabIndex = 5;
            this.Add.Text = "Add Certificate";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // certificate
            // 
            this.certificate.Location = new System.Drawing.Point(-2, -2);
            this.certificate.Margin = new System.Windows.Forms.Padding(2);
            this.certificate.Name = "certificate";
            this.certificate.Size = new System.Drawing.Size(590, 405);
            this.certificate.TabIndex = 6;
            this.certificate.TabStop = false;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(9, 420);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 7;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.certificate);
            this.panel.Location = new System.Drawing.Point(7, 10);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(594, 408);
            this.panel.TabIndex = 48;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(184, 420);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(88, 23);
            this.exportButton.TabIndex = 49;
            this.exportButton.Text = "Export Image";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // COA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(607, 453);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.Add);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "COA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "COA";
            ((System.ComponentModel.ISupportInitialize)(this.certificate)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.PictureBox certificate;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button exportButton;
    }
}