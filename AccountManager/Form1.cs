using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using ComponentFactory.Krypton.Toolkit;

namespace AccountManager
{
    //TODO: History of changes to budget amounts
    //TODO: Category entry should have a list to choose from and add to - have some code to do the match
    //Might be better to display an additional list box that can be controlled and selected from, or overtype
    public partial class LaneAccount : Form
    {
        public LaneAccount(string fileName)
        {
            InitializeComponent();
            OpenFile(fileName);
            
        }
        public LaneAccount()
        {
            InitializeComponent();
        }

        private void splitter1_DoubleClick(object sender, EventArgs e)
        {
            _accountDescPanel.Visible = !_accountDescPanel.Visible;
        }

        private void splitter1_MouseHover(object sender, EventArgs e)
        {
            _accountDescPanel.Visible = true;
        }

        private void splitter2_DoubleClick(object sender, EventArgs e)
        {
            _transaction.Visible = !_transaction.Visible;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Account Files|*.lac";
            dlg.Multiselect = false;
            dlg.Title = "Select Account File";
            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string file = dlg.FileName;
            OpenFile(file);
        }
        private void OpenFile(string FileName)
        {
            _dataAccess = new CDataAccess(FileName);
            _dataAccess.ReadAllAccounts();
            _dataAccess.ReadAllBudgets();
            _dataAccess.ReadAllTransations();

            _accountDesc.SetAccounts(_dataAccess.Accounts);
            _transaction.SetBudgets(_dataAccess.Budgets);
            _transaction.SetCategories(_dataAccess.Categories);
        }


        private void InitialiseGrid()
        {
            _transactionGrid.Columns.Clear();
            KryptonDataGridViewTextBoxColumn DateCol = new KryptonDataGridViewTextBoxColumn();
            DateCol.Name = "Date";
            DateCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            _transactionGrid.Columns.Add(DateCol);
            KryptonDataGridViewTextBoxColumn AmountCol = new KryptonDataGridViewTextBoxColumn();
            AmountCol.Name = "Amount";
            AmountCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            _transactionGrid.Columns.Add(AmountCol);

            _budget.Clear();
            _columns.Clear();
            _columns.Add("Date", 0);
            _columns.Add("Amount", 1);
            _budget.Add("Amount", 0);

            int i = 2;
            foreach (Budget b in _dataAccess.Budgets)
            {
                KryptonDataGridViewTextBoxColumn col = new KryptonDataGridViewTextBoxColumn();
                col.Name = b.BudgetName;
                col.ToolTipText = "£" + Math.Round(b.Amount / 100.0, 2).ToString() + " " + b.BudgetPeriod.ToString();
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                _transactionGrid.Columns.Add(col);
                _columns.Add(b.BudgetName, i++);
                _budget.Add(b.BudgetName, 0);
            }
            KryptonDataGridViewTextBoxColumn DescCol = new KryptonDataGridViewTextBoxColumn();
            DescCol.Name = "Description";
            DescCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            _transactionGrid.Columns.Add(DescCol);
            _columns.Add("Description", i++);
        }
        private void FillGrid()
        {
            foreach (AccountTransactions t in _dataAccess.AccountTransactions)
            {
                AddTransaction(t);
            }
            _transactionGrid.Rows.Insert(0, 2);
            DataGridViewRow row = _transactionGrid.Rows[0];
            row.Cells["Date"].Value = DateTime.Now.ToShortDateString();
            row.Cells["Date"].Style.BackColor = Color.LightYellow;
            row.Cells["Amount"].Value = Math.Round(_budget["Amount"] / 100.00, 2);
            row.Cells["Amount"].Style.BackColor = Color.LightYellow;
            foreach (Budget budg in _dataAccess.Budgets)
            {
                row.Cells[budg.BudgetName].Value = Math.Round(_budget[budg.BudgetName] / 100.00, 2);
                row.Cells[budg.BudgetName].Style.BackColor = Color.LightYellow;
            }
            row.Cells["Description"].Value = "Running Totals";
            row.Cells["Description"].Style.BackColor = Color.LightYellow;
            row.ContextMenuStrip = TrasactionContext;
            row.Cells[0].ContextMenuStrip = TrasactionContext;

            _accountDesc.UpdateBalance(Math.Round(_budget["Amount"] / 100.00, 2).ToString());
            _accountDesc.UpdateLastBalanced(_lastBalanced.ToShortDateString());
        }
        private void FillGridAllAccounts()
        {
            foreach (AccountTransactions t in _dataAccess.Transactions)
            {
                AddTransaction(t);
            }
            _transactionGrid.Rows.Insert(0, 2);
            DataGridViewRow row = _transactionGrid.Rows[0];
            row.Cells["Date"].Value = DateTime.Now.ToShortDateString();
            row.Cells["Date"].Style.BackColor = Color.LightYellow;
            row.Cells["Amount"].Value = Math.Round(_budget["Amount"] / 100.00, 2);
            row.Cells["Amount"].Style.BackColor = Color.LightYellow;
            foreach (Budget budg in _dataAccess.Budgets)
            {
                row.Cells[budg.BudgetName].Value = Math.Round(_budget[budg.BudgetName] / 100.00, 2);
                row.Cells[budg.BudgetName].Style.BackColor = Color.LightYellow;
            }
            row.Cells["Description"].Value = "Running Totals";
            row.Cells["Description"].Style.BackColor = Color.LightYellow;
            row.ContextMenuStrip = TrasactionContext;
            row.Cells[0].ContextMenuStrip = TrasactionContext;

            _accountDesc.UpdateBalance(Math.Round(_budget["Amount"] / 100.00, 2).ToString());
            _accountDesc.UpdateLastBalanced(_lastBalanced.ToShortDateString());
        }
        private void AddTransaction(AccountTransactions trans)
        {
            //Take the transaction and put it into the grid
            _transactionGrid.Rows.Insert(0, 1);
            DataGridViewRow row = _transactionGrid.Rows[0];
            row.Cells[_columns["Date"]].Value = trans.TransactionDate.ToShortDateString();
            row.Tag = trans.ID;
            row.Cells[_columns["Description"]].Value = trans.Description;
            if (trans.Balanced)
            {
                row.Cells[_columns["Amount"]].Style.BackColor = Color.LightGray;
                row.Cells[_columns["Amount"]].ToolTipText = "Balanced here";
                _lastBalanced = trans.TransactionDate;
            }
            foreach (Transaction t in trans.Transactions)
            {
                row.Cells[_columns[t.TransactionBudget]].Value = Math.Round(t.Amount / 100.0, 2);
                _budget[t.TransactionBudget] += t.Amount;
                if (t.Amount < 0)
                {
                    row.Cells[_columns[t.TransactionBudget]].Style.ForeColor = Color.Red;
                }
                //keep track of the budget totals
                _budget["Amount"] += t.Amount;
            }
            //populate the running total
            row.Cells[_columns["Amount"]].Value = Math.Round(_budget["Amount"] / 100.0, 2);
        }
        private void _accountDesc_OnAccountChanged(string name)
        {
            _lastBalanced = new DateTime(0);
            InitialiseGrid();
            if (name == "All Accounts")
            {
                _transactionGrid.ContextMenuStrip = null;
                menuStrip1.Items["transactionsToolStripMenuItem"].Enabled = false;
                addToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                FillGridAllAccounts();
            }
            else
            {
                _transactionGrid.ContextMenuStrip = TrasactionContext;
                Account ac = new Account();
                ac.AccountName = name;
                _dataAccess.ReadTransactions(ac);
                menuStrip1.Items["transactionsToolStripMenuItem"].Enabled = true;
                addToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                //Update the transaction panel to edit and add for the new account
                _transaction.SetAccount(name);
                FillGrid();
            }
        }

        private void splitter2_MouseHover(object sender, EventArgs e)
        {
            _transaction.Visible = true;
        }

        private void _transaction_TransactionAdded(AccountTransactions trans)
        {
            _dataAccess.AddTransaction(trans);
            _dataAccess.ReadTransactions(_accountDesc.CurrentAccount);
            InitialiseGrid();
            FillGrid();
        }

        private void _transaction_TransactionEdited(AccountTransactions trans)
        {
            _dataAccess.UpdateTransaction(trans);
            _dataAccess.ReadTransactions(_accountDesc.CurrentAccount);
            InitialiseGrid();
            FillGrid();
        }
        CDataAccess _dataAccess;
        private Dictionary<string, int> _columns = new Dictionary<string, int>();
        private Dictionary<string, int> _budget = new Dictionary<string, int>();

        private void editTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(_transactionGrid.Rows[_transactionGrid.SelectedCells[0].RowIndex].Tag);
            AccountTransactions t = _dataAccess.GetTransaction(id);
            _transaction.EditTransaction(t);
            //Reload Data
            InitialiseGrid();
            FillGrid();
        }

        private void deleteTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(_transactionGrid.Rows[_transactionGrid.SelectedCells[0].RowIndex].Tag);
            _dataAccess.DeleteTransaction(_dataAccess.GetTransaction(id));
            //Reload data
            InitialiseGrid();
            FillGrid();
        }

        private void balancedHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(_transactionGrid.Rows[_transactionGrid.SelectedCells[0].RowIndex].Tag);
            _dataAccess.BalanceTransaction(id);
            //Reload the data
            InitialiseGrid();
            FillGrid();
        }
        private DateTime _lastBalanced = new DateTime(0);

        private void addNewTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _transaction.AddTransaction();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _transaction.AddTransaction();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(_transactionGrid.Rows[_transactionGrid.SelectedCells[0].RowIndex].Tag);
            AccountTransactions t = _dataAccess.GetTransaction(id);
            _transaction.EditTransaction(t);
            //Reload Data
            InitialiseGrid();
            FillGrid();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = _transactionGrid.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(_transactionGrid.Rows[row].Tag);
            _dataAccess.DeleteTransaction(_dataAccess.GetTransaction(id));
            //Reload data
            InitialiseGrid();
            FillGrid();
        }
    }
}
