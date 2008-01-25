namespace AccountManager
{
    partial class AccountDescription
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
            this._accountList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._balance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._lastBalanced = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Account";
            // 
            // _accountList
            // 
            this._accountList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._accountList.FormattingEnabled = true;
            this._accountList.Location = new System.Drawing.Point(89, 9);
            this._accountList.Name = "_accountList";
            this._accountList.Size = new System.Drawing.Size(156, 21);
            this._accountList.TabIndex = 1;
            this._accountList.SelectedIndexChanged += new System.EventHandler(this._accountList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Balance:";
            // 
            // _balance
            // 
            this._balance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._balance.AutoSize = true;
            this._balance.Location = new System.Drawing.Point(89, 38);
            this._balance.Name = "_balance";
            this._balance.Size = new System.Drawing.Size(34, 13);
            this._balance.TabIndex = 3;
            this._balance.Text = "£0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Balanced:";
            // 
            // _lastBalanced
            // 
            this._lastBalanced.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lastBalanced.AutoSize = true;
            this._lastBalanced.Location = new System.Drawing.Point(92, 63);
            this._lastBalanced.Name = "_lastBalanced";
            this._lastBalanced.Size = new System.Drawing.Size(53, 13);
            this._lastBalanced.TabIndex = 5;
            this._lastBalanced.Text = "1/1/2007";
            // 
            // AccountDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this._lastBalanced);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._balance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._accountList);
            this.Controls.Add(this.label1);
            this.Name = "AccountDescription";
            this.Size = new System.Drawing.Size(248, 482);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _accountList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _balance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _lastBalanced;
    }
}
