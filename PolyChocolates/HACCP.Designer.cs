namespace PolyChocolates
{
    partial class HACCP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HACCP));
            this.haacpImage = new System.Windows.Forms.PictureBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.haacpImage)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // haacpImage
            // 
            this.haacpImage.BackColor = System.Drawing.Color.White;
            this.haacpImage.Location = new System.Drawing.Point(-2, -1);
            this.haacpImage.Margin = new System.Windows.Forms.Padding(2);
            this.haacpImage.Name = "haacpImage";
            this.haacpImage.Size = new System.Drawing.Size(590, 403);
            this.haacpImage.TabIndex = 51;
            this.haacpImage.TabStop = false;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(181, 419);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(88, 23);
            this.exportButton.TabIndex = 53;
            this.exportButton.Text = "Export Image";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(10, 419);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 52;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(89, 419);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(88, 23);
            this.Add.TabIndex = 50;
            this.Add.Text = "Add HAACP";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.haacpImage);
            this.panel.Location = new System.Drawing.Point(6, 10);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(594, 408);
            this.panel.TabIndex = 54;
            // 
            // HACCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 453);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.Add);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HACCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HACCP";
            ((System.ComponentModel.ISupportInitialize)(this.haacpImage)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox haacpImage;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Panel panel;
    }
}