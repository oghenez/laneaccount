namespace AccountManager
{
    partial class TransactionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._total = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._description = new System.Windows.Forms.TextBox();
            this._transaction = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Amount = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Budget = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._completeTrans = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label4 = new System.Windows.Forms.Label();
            this._date = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._lvAssignedCategories = new System.Windows.Forms.ListView();
            this._cbAvailableCategories = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._transaction)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total: ";
            // 
            // _total
            // 
            this._total.Location = new System.Drawing.Point(172, 21);
            this._total.Name = "_total";
            this._total.Size = new System.Drawing.Size(100, 20);
            this._total.TabIndex = 2;
            this._total.Text = "123.45";
            this._total.TextChanged += new System.EventHandler(this._total_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description: ";
            // 
            // _description
            // 
            this._description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._description.Location = new System.Drawing.Point(348, 21);
            this._description.Name = "_description";
            this._description.Size = new System.Drawing.Size(349, 20);
            this._description.TabIndex = 4;
            // 
            // _transaction
            // 
            this._transaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._transaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._transaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Amount,
            this.Budget});
            this._transaction.Location = new System.Drawing.Point(7, 47);
            this._transaction.MultiSelect = false;
            this._transaction.Name = "_transaction";
            this._transaction.Size = new System.Drawing.Size(336, 167);
            this._transaction.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this._transaction.TabIndex = 5;
            this._transaction.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this._transaction_CellValueChanged);
            this._transaction.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._transaction_RowEnter);
            this._transaction.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this._transaction_RowsAdded);
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Budget
            // 
            this.Budget.HeaderText = "Budget";
            this.Budget.Name = "Budget";
            // 
            // _completeTrans
            // 
            this._completeTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._completeTrans.Location = new System.Drawing.Point(635, 221);
            this._completeTrans.Name = "_completeTrans";
            this._completeTrans.Size = new System.Drawing.Size(62, 25);
            this._completeTrans.TabIndex = 6;
            this._completeTrans.Text = "OK";
            this._completeTrans.Values.ExtraText = "";
            this._completeTrans.Values.Image = null;
            this._completeTrans.Values.ImageStates.ImageCheckedNormal = null;
            this._completeTrans.Values.ImageStates.ImageCheckedPressed = null;
            this._completeTrans.Values.ImageStates.ImageCheckedTracking = null;
            this._completeTrans.Values.Text = "OK";
            this._completeTrans.Click += new System.EventHandler(this._completeTrans_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date";
            // 
            // _date
            // 
            this._date.CustomFormat = "dd/mm/yyyy";
            this._date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._date.Location = new System.Drawing.Point(43, 21);
            this._date.Name = "_date";
            this._date.Size = new System.Drawing.Size(85, 20);
            this._date.TabIndex = 8;
            this._date.Value = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Budget";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._lvAssignedCategories);
            this.groupBox1.Controls.Add(this._cbAvailableCategories);
            this.groupBox1.Location = new System.Drawing.Point(349, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 167);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categories";
            // 
            // _lvAssignedCategories
            // 
            this._lvAssignedCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lvAssignedCategories.Location = new System.Drawing.Point(3, 43);
            this._lvAssignedCategories.Name = "_lvAssignedCategories";
            this._lvAssignedCategories.Size = new System.Drawing.Size(339, 117);
            this._lvAssignedCategories.TabIndex = 1;
            this._lvAssignedCategories.UseCompatibleStateImageBehavior = false;
            this._lvAssignedCategories.View = System.Windows.Forms.View.List;
            this._lvAssignedCategories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._lvAssignedCategories_MouseDoubleClick);
            // 
            // _cbAvailableCategories
            // 
            this._cbAvailableCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbAvailableCategories.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._cbAvailableCategories.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._cbAvailableCategories.FormattingEnabled = true;
            this._cbAvailableCategories.Location = new System.Drawing.Point(3, 16);
            this._cbAvailableCategories.Name = "_cbAvailableCategories";
            this._cbAvailableCategories.Size = new System.Drawing.Size(339, 21);
            this._cbAvailableCategories.TabIndex = 0;
            this._cbAvailableCategories.KeyDown += new System.Windows.Forms.KeyEventHandler(this._cbAvailableCategories_KeyDown);
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._date);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._completeTrans);
            this.Controls.Add(this._transaction);
            this.Controls.Add(this._description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._total);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TransactionForm";
            this.Size = new System.Drawing.Size(700, 248);
            ((System.ComponentModel.ISupportInitialize)(this._transaction)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _description;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView _transaction;
        private ComponentFactory.Krypton.Toolkit.KryptonButton _completeTrans;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _date;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewComboBoxColumn Budget;
        private System.Windows.Forms.ListView _lvAssignedCategories;
        private System.Windows.Forms.ComboBox _cbAvailableCategories;
    }
}
