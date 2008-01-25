namespace AccountManager
{
    partial class LaneAccount
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
            this.components = new System.ComponentModel.Container();
            this._accountDescPanel = new System.Windows.Forms.Panel();
            this._accountDesc = new AccountManager.AccountDescription();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._transactionGrid = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.TrasactionContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balancedHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._transaction = new AccountManager.TransactionForm();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._accountDescPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._transactionGrid)).BeginInit();
            this.TrasactionContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // _accountDescPanel
            // 
            this._accountDescPanel.Controls.Add(this._accountDesc);
            this._accountDescPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._accountDescPanel.Location = new System.Drawing.Point(0, 24);
            this._accountDescPanel.Name = "_accountDescPanel";
            this._accountDescPanel.Size = new System.Drawing.Size(200, 478);
            this._accountDescPanel.TabIndex = 0;
            // 
            // _accountDesc
            // 
            this._accountDesc.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._accountDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this._accountDesc.Location = new System.Drawing.Point(0, 0);
            this._accountDesc.Name = "_accountDesc";
            this._accountDesc.Size = new System.Drawing.Size(200, 478);
            this._accountDesc.TabIndex = 0;
            this._accountDesc.OnAccountChanged += new AccountManager.ChangeAccount(this._accountDesc_OnAccountChanged);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Blue;
            this.splitter1.Location = new System.Drawing.Point(200, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 478);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            this.splitter1.DoubleClick += new System.EventHandler(this.splitter1_DoubleClick);
            this.splitter1.MouseHover += new System.EventHandler(this.splitter1_MouseHover);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Blue;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(203, 223);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(559, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            this.splitter2.DoubleClick += new System.EventHandler(this.splitter2_DoubleClick);
            this.splitter2.MouseHover += new System.EventHandler(this.splitter2_MouseHover);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.transactionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(762, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "&Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // _transactionGrid
            // 
            this._transactionGrid.AllowUserToAddRows = false;
            this._transactionGrid.AllowUserToDeleteRows = false;
            this._transactionGrid.AllowUserToResizeRows = false;
            this._transactionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._transactionGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._transactionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._transactionGrid.ContextMenuStrip = this.TrasactionContext;
            this._transactionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._transactionGrid.Location = new System.Drawing.Point(203, 24);
            this._transactionGrid.MultiSelect = false;
            this._transactionGrid.Name = "_transactionGrid";
            this._transactionGrid.ReadOnly = true;
            this._transactionGrid.Size = new System.Drawing.Size(559, 199);
            this._transactionGrid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this._transactionGrid.TabIndex = 5;
            // 
            // TrasactionContext
            // 
            this.TrasactionContext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TrasactionContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTransactionToolStripMenuItem,
            this.deleteTransactionToolStripMenuItem,
            this.balancedHereToolStripMenuItem,
            this.toolStripSeparator1,
            this.addNewTransactionToolStripMenuItem});
            this.TrasactionContext.Name = "TrasactionContext";
            this.TrasactionContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TrasactionContext.Size = new System.Drawing.Size(181, 98);
            // 
            // editTransactionToolStripMenuItem
            // 
            this.editTransactionToolStripMenuItem.Name = "editTransactionToolStripMenuItem";
            this.editTransactionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editTransactionToolStripMenuItem.Text = "Edit Transaction";
            this.editTransactionToolStripMenuItem.Click += new System.EventHandler(this.editTransactionToolStripMenuItem_Click);
            // 
            // deleteTransactionToolStripMenuItem
            // 
            this.deleteTransactionToolStripMenuItem.Name = "deleteTransactionToolStripMenuItem";
            this.deleteTransactionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteTransactionToolStripMenuItem.Text = "Delete Transaction";
            this.deleteTransactionToolStripMenuItem.Click += new System.EventHandler(this.deleteTransactionToolStripMenuItem_Click);
            // 
            // balancedHereToolStripMenuItem
            // 
            this.balancedHereToolStripMenuItem.Name = "balancedHereToolStripMenuItem";
            this.balancedHereToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.balancedHereToolStripMenuItem.Text = "Balanced Here";
            this.balancedHereToolStripMenuItem.Click += new System.EventHandler(this.balancedHereToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // addNewTransactionToolStripMenuItem
            // 
            this.addNewTransactionToolStripMenuItem.Name = "addNewTransactionToolStripMenuItem";
            this.addNewTransactionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addNewTransactionToolStripMenuItem.Text = "Add New Transaction";
            this.addNewTransactionToolStripMenuItem.Click += new System.EventHandler(this.addNewTransactionToolStripMenuItem_Click);
            // 
            // _transaction
            // 
            this._transaction.BackColor = System.Drawing.Color.White;
            this._transaction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._transaction.Location = new System.Drawing.Point(203, 226);
            this._transaction.Name = "_transaction";
            this._transaction.Size = new System.Drawing.Size(559, 276);
            this._transaction.TabIndex = 2;
            this._transaction.TransactionEdited += new AccountManager.TransactionComplete(this._transaction_TransactionEdited);
            this._transaction.TransactionAdded += new AccountManager.TransactionComplete(this._transaction_TransactionAdded);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // LaneAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 502);
            this.Controls.Add(this._transactionGrid);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this._transaction);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this._accountDescPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LaneAccount";
            this.Text = "Lane Account Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._accountDescPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._transactionGrid)).EndInit();
            this.TrasactionContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _accountDescPanel;
        private System.Windows.Forms.Splitter splitter1;
        private AccountDescription _accountDesc;
        private TransactionForm _transaction;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView _transactionGrid;
        private System.Windows.Forms.ContextMenuStrip TrasactionContext;
        private System.Windows.Forms.ToolStripMenuItem editTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balancedHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addNewTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

    }
}

