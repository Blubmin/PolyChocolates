namespace PolyChocolates
{
    partial class PropertiesWindow
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
            this.label3 = new System.Windows.Forms.Label();
            this.InvoiceHeader = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PreviousPassword = new System.Windows.Forms.TextBox();
            this.NewPassword = new System.Windows.Forms.TextBox();
            this.RepeatPassword = new System.Windows.Forms.TextBox();
            this.ApplyChanges = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Invoicing Header";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InvoiceHeader
            // 
            this.InvoiceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceHeader.Location = new System.Drawing.Point(130, 12);
            this.InvoiceHeader.Name = "InvoiceHeader";
            this.InvoiceHeader.Size = new System.Drawing.Size(154, 45);
            this.InvoiceHeader.TabIndex = 17;
            this.InvoiceHeader.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Change Password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Previous Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "New Password";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Repeat New";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PreviousPassword
            // 
            this.PreviousPassword.Location = new System.Drawing.Point(142, 106);
            this.PreviousPassword.Name = "PreviousPassword";
            this.PreviousPassword.Size = new System.Drawing.Size(142, 20);
            this.PreviousPassword.TabIndex = 22;
            // 
            // NewPassword
            // 
            this.NewPassword.Location = new System.Drawing.Point(142, 135);
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.Size = new System.Drawing.Size(142, 20);
            this.NewPassword.TabIndex = 23;
            // 
            // RepeatPassword
            // 
            this.RepeatPassword.Location = new System.Drawing.Point(142, 162);
            this.RepeatPassword.Name = "RepeatPassword";
            this.RepeatPassword.Size = new System.Drawing.Size(142, 20);
            this.RepeatPassword.TabIndex = 24;
            // 
            // ApplyChanges
            // 
            this.ApplyChanges.Location = new System.Drawing.Point(120, 192);
            this.ApplyChanges.Name = "ApplyChanges";
            this.ApplyChanges.Size = new System.Drawing.Size(88, 23);
            this.ApplyChanges.TabIndex = 25;
            this.ApplyChanges.Text = "Apply Changes";
            this.ApplyChanges.UseVisualStyleBackColor = true;
            this.ApplyChanges.Click += new System.EventHandler(this.ApplyChanges_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(212, 192);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 26;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // PropertiesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 221);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ApplyChanges);
            this.Controls.Add(this.RepeatPassword);
            this.Controls.Add(this.NewPassword);
            this.Controls.Add(this.PreviousPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InvoiceHeader);
            this.Controls.Add(this.label3);
            this.Name = "PropertiesWindow";
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox InvoiceHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PreviousPassword;
        private System.Windows.Forms.TextBox NewPassword;
        private System.Windows.Forms.TextBox RepeatPassword;
        private System.Windows.Forms.Button ApplyChanges;
        private System.Windows.Forms.Button Cancel;
    }
}