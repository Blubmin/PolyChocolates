namespace PolyChocolates
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.SidePanel = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runningInventoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastInventoriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoicingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recipesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupShutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chocolateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chocolateSetupTab = new System.Windows.Forms.ToolStripMenuItem();
            this.chocolateShutdownTab = new System.Windows.Forms.ToolStripMenuItem();
            this.bbqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bbqSetupTab = new System.Windows.Forms.ToolStripMenuItem();
            this.bbqShutdownTab = new System.Windows.Forms.ToolStripMenuItem();
            this.jamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jamSetupTab = new System.Windows.Forms.ToolStripMenuItem();
            this.jamShutdownTab = new System.Windows.Forms.ToolStripMenuItem();
            this.qualityFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SidePanel
            // 
            this.SidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SidePanel.BackColor = System.Drawing.SystemColors.Control;
            this.SidePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SidePanel.Location = new System.Drawing.Point(-2, 97);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(200, 489);
            this.SidePanel.TabIndex = 0;
            // 
            // TopPanel
            // 
            this.TopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TopPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TopPanel.Controls.Add(this.pictureBox1);
            this.TopPanel.Location = new System.Drawing.Point(-1, -1);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1353, 100);
            this.TopPanel.TabIndex = 1;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MenuPanel.Controls.Add(this.menu);
            this.MenuPanel.Location = new System.Drawing.Point(-1, 231);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(198, 457);
            this.MenuPanel.TabIndex = 2;
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.SystemColors.Control;
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.invoicingToolStripMenuItem,
            this.productEntryToolStripMenuItem,
            this.recipesToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.setupShutdownToolStripMenuItem,
            this.qualityFormsToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(202, 457);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runningInventoryMenuItem,
            this.pastInventoriesMenuItem});
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // runningInventoryMenuItem
            // 
            this.runningInventoryMenuItem.Name = "runningInventoryMenuItem";
            this.runningInventoryMenuItem.Size = new System.Drawing.Size(207, 24);
            this.runningInventoryMenuItem.Text = "Running Inventory";
            this.runningInventoryMenuItem.Click += new System.EventHandler(this.runningInventoryMenuItem_Click);
            // 
            // pastInventoriesMenuItem
            // 
            this.pastInventoriesMenuItem.Name = "pastInventoriesMenuItem";
            this.pastInventoriesMenuItem.Size = new System.Drawing.Size(207, 24);
            this.pastInventoriesMenuItem.Text = "Past Inventories";
            this.pastInventoriesMenuItem.Click += new System.EventHandler(this.pastInventoriesMenuItem_Click);
            // 
            // invoicingToolStripMenuItem
            // 
            this.invoicingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newInvoiceToolStripMenuItem,
            this.pastInvoicesToolStripMenuItem,
            this.customerManagementToolStripMenuItem});
            this.invoicingToolStripMenuItem.Name = "invoicingToolStripMenuItem";
            this.invoicingToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.invoicingToolStripMenuItem.Text = "Invoicing";
            // 
            // newInvoiceToolStripMenuItem
            // 
            this.newInvoiceToolStripMenuItem.Name = "newInvoiceToolStripMenuItem";
            this.newInvoiceToolStripMenuItem.Size = new System.Drawing.Size(245, 24);
            this.newInvoiceToolStripMenuItem.Text = "New Invoice";
            this.newInvoiceToolStripMenuItem.Click += new System.EventHandler(this.newInvoiceToolStripMenuItem_Click);
            // 
            // pastInvoicesToolStripMenuItem
            // 
            this.pastInvoicesToolStripMenuItem.Name = "pastInvoicesToolStripMenuItem";
            this.pastInvoicesToolStripMenuItem.Size = new System.Drawing.Size(245, 24);
            this.pastInvoicesToolStripMenuItem.Text = "Search Invoices";
            this.pastInvoicesToolStripMenuItem.Click += new System.EventHandler(this.pastInvoices_Click);
            // 
            // customerManagementToolStripMenuItem
            // 
            this.customerManagementToolStripMenuItem.Name = "customerManagementToolStripMenuItem";
            this.customerManagementToolStripMenuItem.Size = new System.Drawing.Size(245, 24);
            this.customerManagementToolStripMenuItem.Text = "Customer Management";
            this.customerManagementToolStripMenuItem.Click += new System.EventHandler(this.customerManagement_Click);
            // 
            // productEntryToolStripMenuItem
            // 
            this.productEntryToolStripMenuItem.Name = "productEntryToolStripMenuItem";
            this.productEntryToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.productEntryToolStripMenuItem.Text = "Product Entry";
            // 
            // recipesToolStripMenuItem
            // 
            this.recipesToolStripMenuItem.Name = "recipesToolStripMenuItem";
            this.recipesToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.recipesToolStripMenuItem.Text = "Recipes";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // setupShutdownToolStripMenuItem
            // 
            this.setupShutdownToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chocolateToolStripMenuItem,
            this.bbqToolStripMenuItem,
            this.jamToolStripMenuItem});
            this.setupShutdownToolStripMenuItem.Name = "setupShutdownToolStripMenuItem";
            this.setupShutdownToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.setupShutdownToolStripMenuItem.Text = "Setup/Shutdown";
            // 
            // chocolateToolStripMenuItem
            // 
            this.chocolateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chocolateSetupTab,
            this.chocolateShutdownTab});
            this.chocolateToolStripMenuItem.Name = "chocolateToolStripMenuItem";
            this.chocolateToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.chocolateToolStripMenuItem.Text = "Chocolate";
            // 
            // chocolateSetupTab
            // 
            this.chocolateSetupTab.Name = "chocolateSetupTab";
            this.chocolateSetupTab.Size = new System.Drawing.Size(150, 24);
            this.chocolateSetupTab.Text = "Setup";
            this.chocolateSetupTab.Click += new System.EventHandler(this.chocolateSetupTab_Click);
            // 
            // chocolateShutdownTab
            // 
            this.chocolateShutdownTab.Name = "chocolateShutdownTab";
            this.chocolateShutdownTab.Size = new System.Drawing.Size(150, 24);
            this.chocolateShutdownTab.Text = "Shutdown";
            this.chocolateShutdownTab.Click += new System.EventHandler(this.chocolateShutdownTab_Click);
            // 
            // bbqToolStripMenuItem
            // 
            this.bbqToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bbqSetupTab,
            this.bbqShutdownTab});
            this.bbqToolStripMenuItem.Name = "bbqToolStripMenuItem";
            this.bbqToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.bbqToolStripMenuItem.Text = "BBQ";
            // 
            // bbqSetupTab
            // 
            this.bbqSetupTab.Name = "bbqSetupTab";
            this.bbqSetupTab.Size = new System.Drawing.Size(150, 24);
            this.bbqSetupTab.Text = "Setup";
            this.bbqSetupTab.Click += new System.EventHandler(this.bbqSetupTab_Click);
            // 
            // bbqShutdownTab
            // 
            this.bbqShutdownTab.Name = "bbqShutdownTab";
            this.bbqShutdownTab.Size = new System.Drawing.Size(150, 24);
            this.bbqShutdownTab.Text = "Shutdown";
            this.bbqShutdownTab.Click += new System.EventHandler(this.bbqShutdownTab_Click);
            // 
            // jamToolStripMenuItem
            // 
            this.jamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jamSetupTab,
            this.jamShutdownTab});
            this.jamToolStripMenuItem.Name = "jamToolStripMenuItem";
            this.jamToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.jamToolStripMenuItem.Text = "Jam";
            // 
            // jamSetupTab
            // 
            this.jamSetupTab.Name = "jamSetupTab";
            this.jamSetupTab.Size = new System.Drawing.Size(150, 24);
            this.jamSetupTab.Text = "Setup";
            this.jamSetupTab.Click += new System.EventHandler(this.jamSetupTab_Click);
            // 
            // jamShutdownTab
            // 
            this.jamShutdownTab.Name = "jamShutdownTab";
            this.jamShutdownTab.Size = new System.Drawing.Size(150, 24);
            this.jamShutdownTab.Text = "Shutdown";
            this.jamShutdownTab.Click += new System.EventHandler(this.jamShutdownTab_Click);
            // 
            // qualityFormsToolStripMenuItem
            // 
            this.qualityFormsToolStripMenuItem.Name = "qualityFormsToolStripMenuItem";
            this.qualityFormsToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.qualityFormsToolStripMenuItem.Text = "Quality Forms";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1349, 96);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1350, 676);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.SidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopPanel.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem productEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupShutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recipesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chocolateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chocolateSetupTab;
        private System.Windows.Forms.ToolStripMenuItem chocolateShutdownTab;
        private System.Windows.Forms.ToolStripMenuItem bbqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bbqSetupTab;
        private System.Windows.Forms.ToolStripMenuItem bbqShutdownTab;
        private System.Windows.Forms.ToolStripMenuItem jamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jamSetupTab;
        private System.Windows.Forms.ToolStripMenuItem jamShutdownTab;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runningInventoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastInventoriesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qualityFormsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem invoicingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastInvoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;



    }
}

