using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using MathFunctions;

namespace AccountManager
{
    public delegate void TransactionComplete(AccountTransactions trans);
    public partial class TransactionForm : UserControl
    {
        public TransactionForm()
        {
            InitializeComponent();
            DisableControls();
        }
        public void EditTransaction(AccountTransactions trans)
        {
            EnableControls();
            _transaction.Rows.Clear();
            _editMode = true;
            //Put the supplied transaction into the controls
            _description.Text = trans.Description;
            _date.Value = trans.TransactionDate;
            _id = trans.ID;
            _balanced = trans.Balanced;
            int total = 0;
            foreach (Transaction t in trans.Transactions)
            {
               int RowID = _transaction.Rows.Add(new object[] { (t.Amount/100.0).ToString(), 
                                                     t.TransactionBudget});
               _transaction.Rows[RowID].Tag = t.Categories;
                total += t.Amount;
            }
            _total.Text = (total/100.0).ToString();
        }
        public void AddTransaction()
        {
            EnableControls();
            _transaction.Rows.Clear();
            _editMode = false;
        }
        public event TransactionComplete TransactionEdited;
        public event TransactionComplete TransactionAdded;
        public void SetBudgets(List<Budget> budgets)
        {
            //Put the budgets into the column 1 combo box
            foreach (Budget b in budgets)
            {
                ((DataGridViewComboBoxColumn)_transaction.Columns[1]).Items.Add(b.BudgetName);
            }
        }
        public void SetAccount(string account)
        {
            _account = account;
        }
        public void SetCategories(List<string> categories)
        {
            _categories = categories;
            _categories.Sort();
        }

        private void EnableControls()
        {
            _completeTrans.Enabled = true;
            _description.Enabled = true;
            _total.Enabled = true;
            _transaction.Enabled = true;
            _date.Enabled = true;
            _description.Text = "";
            _total.Text = "0";
        }
        private void DisableControls()
        {
            _completeTrans.Enabled = false;
            _description.Enabled = false;
            _total.Enabled = false;
            _transaction.Enabled = false;
            _date.Enabled = false;
        }
        private void _completeTrans_Click(object sender, EventArgs e)
        {
            DisableControls();
            AccountTransactions trans = new AccountTransactions();
            trans.ID = _id;
            trans.Balanced = _balanced;
            trans.Description = _description.Text;
            trans.TransactionDate = _date.Value;
            trans.AccountName = _account;

            foreach (DataGridViewRow row in _transaction.Rows)
            {
                if (row.Cells[0].Value == null)
                {
                    continue;
                }
                Transaction t = new Transaction();
                float fAmount = float.Parse(row.Cells[0].Value.ToString());
                fAmount = (float)Math.Round(fAmount, 2);
                fAmount *= (100.0f);
                t.Amount = (int)(Math.Round(fAmount));
                t.TransactionBudget = row.Cells[1].Value.ToString();
                if (row.Tag != null)
                {
                    foreach (string str in (List<string>)row.Tag)
                    {
                        t.Categories.Add(str);
                    }
                }
                trans.Transactions.Add(t);
            }
            if (_editMode)
            {
                if (TransactionEdited != null)
                {
                    TransactionEdited(trans);
                }
            }
            else
            {
                if (TransactionAdded != null)
                {
                    TransactionAdded(trans);
                }
            }
        }

        private bool _editMode = false;
        private int _id = 0;
        private bool _balanced = false;
        private string _account = "";
        private List<string> _categories = new List<string>();

        private void _total_TextChanged(object sender, EventArgs e)
        {
            int total = 0;
            foreach (DataGridViewRow row in _transaction.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    float val = (float)Math.Round(float.Parse(row.Cells[0].Value.ToString()), 2);
                    val = (float)Math.Round(val, 2);
                    val *= 100f;
                    val = (float)Math.Round(val);
                    total += (int)val;
                }
            }
            float totalVal = 0;
            if (_total.Text != "" && _total.Text != "-")
            {
                totalVal = float.Parse(_total.Text);
                totalVal = (float)Math.Round(totalVal, 2);
                totalVal *= 100f;
                totalVal = (float)Math.Round(totalVal);
            }
            int iTotalVal = (int)totalVal;
            //if there are no rows then add one and stick the value in it
            //otherwise modify the value in the highest number row
            if (total != iTotalVal)
            {
                if (_transaction.Rows.Count == 0)
                {
                    int iRow = _transaction.Rows.Add();
                    _transaction.Rows[iRow].Cells[0].Value = Math.Round((iTotalVal - total) / 100.0f, 2);
                }
                else
                {
                    //if we're putting into an existing row then we need to disregard the value in here
                    int iVal = 0;
                    if (_transaction.Rows[_transaction.Rows.Count - 1].Cells[0].Value != null)
                    {
                        float fCurrVal = float.Parse(_transaction.Rows[_transaction.Rows.Count - 1].Cells[0].Value.ToString());
                        fCurrVal = (float)Math.Round(fCurrVal, 2);
                        fCurrVal *= 100;
                        iVal = (int)Math.Round(fCurrVal);
                    }
                    _transaction.Rows[_transaction.Rows.Count - 1].Cells[0].Value = Math.Round((iTotalVal - total + iVal) / 100.0f, 2);
                }
            }
        }

        private void _transaction_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //TODO: A new row is added, populate the amount column with the remaining amount
            /*int iTotal = 0;
            foreach (DataGridViewRow row in _transaction.Rows)
            {
                if (row.Cells[0].Value == null)
                {
                    continue;
                }
                float fVal = float.Parse(row.Cells[0].Value.ToString());
                fVal = (float)Math.Round(fVal, 2);
                fVal *= 100;
                iTotal += (int)fVal;
            }
            float totalVal = float.Parse(_total.Text);
            totalVal = (float)Math.Round(totalVal, 2);
            totalVal *= 100;
            int iFull = (int)totalVal;
            int iRemain = iFull - iTotal;

            _transaction.Rows[_transaction.Rows.Count - 1].Cells[0].Value = Math.Round(iRemain / 100.0f, 2);*/
        }

        private void _transaction_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex  >= 0)
            {
                //only process this if it isn't a formula
                if (_transaction.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && 
                    _transaction.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()[0] == '=')
                {
                    return;
                }
                try
                {
                    float.Parse(_transaction.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter a numeric value only");
                    return;
                }
                //just left the amount column
                //update the highest row with the correct amount
                int iValue = 0;
                foreach (DataGridViewRow row in _transaction.Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        continue;
                    }
                    float fVal = float.Parse(row.Cells[0].Value.ToString());
                    fVal = (float)Math.Round(fVal, 2);
                    fVal *= 100.0f;
                    iValue += (int)Math.Round(fVal);
                }
                float fTotal = 0;
                if (_total.Text == "" || _total.Text == "-")
                {
                    fTotal = 0;
                }
                else
                {
                    fTotal = float.Parse(_total.Text);
                }
                fTotal = (float)Math.Round(fTotal, 2);
                fTotal *= 100.0f;
                int iFull = (int)Math.Round(fTotal);
                //if we're adding this into an existing row, disregard the value in that row
                int iRemain = iFull - iValue;

                if (_transaction.Rows[_transaction.Rows.Count - 1].Cells[0].Value != null)
                {
                    float fDis = float.Parse(_transaction.Rows[_transaction.Rows.Count - 1].Cells[0].Value.ToString());
                    fDis = (float)Math.Round(fDis, 2);
                    fDis *= 100.0f;
                    iRemain += (int)Math.Round(fDis);
                }
                _transaction.Rows[_transaction.Rows.Count - 1].Cells[0].Value = Math.Round(iRemain / 100.0f, 2);
            }
        }

        private void _transaction_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //add the categories to the autocomplete and the available list
            _cbAvailableCategories.Items.Clear();
            _cbAvailableCategories.AutoCompleteCustomSource.Clear();
            _cbAvailableCategories.AutoCompleteCustomSource.AddRange(_categories.ToArray());
            _cbAvailableCategories.Items.AddRange(_categories.ToArray());
            _lvAssignedCategories.Items.Clear();
            //remove from the available list and put them into the assigned list
            if (_transaction.Rows[e.RowIndex].Tag != null)//if it's null then this row doesn't have any categories already assigned
            {
                foreach (string str in ((List<string>)_transaction.Rows[e.RowIndex].Tag))
                {
                    _cbAvailableCategories.Items.Remove(str);
                    _lvAssignedCategories.Items.Add(str);
                    _cbAvailableCategories.AutoCompleteCustomSource.Remove(str);
                }
            }
        }

        private void _cbAvailableCategories_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                //add the item to the assigned list
                _lvAssignedCategories.Items.Add(_cbAvailableCategories.Text);
                if (!_categories.Contains(_cbAvailableCategories.Text))
                {
                    //Add the new category to the categories list so it will be available next time
                    _categories.Add(_cbAvailableCategories.Text);
                }
                else
                {
                    //remove the item from the available lists if it was an existing one
                    _cbAvailableCategories.AutoCompleteCustomSource.Remove(_cbAvailableCategories.Text);
                    _cbAvailableCategories.Items.Remove(_cbAvailableCategories.Text);
                }
                //now update the list of categories in the tag for the applicable row
                //get the row
                int currRow = _transaction.SelectedCells[0].RowIndex;
                //we need an array of strings so convert from the assigned items to an array
                List<String> assignedArray = new List<String>();
                foreach (ListViewItem lvi in _lvAssignedCategories.Items)
                {
                    assignedArray.Add(lvi.Text);
                }
                _transaction.Rows[currRow].Tag = assignedArray;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        private void _lvAssignedCategories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //double clicking the assigned list removes it and moves it back into the available list
            //work out which item was double clicked
            ListViewItem item = _lvAssignedCategories.HitTest(e.Location).Item;
            //put it into the auto complete list
            _cbAvailableCategories.AutoCompleteCustomSource.Add(item.Text);
            _cbAvailableCategories.Items.Add(item.Text);
            List<string> comboItems = new List<string>();
            foreach (string str in _cbAvailableCategories.Items)
            {
                comboItems.Add(str);
            }
            comboItems.Sort();
            _cbAvailableCategories.Items.Clear();
            _cbAvailableCategories.Items.AddRange(comboItems.ToArray());
            //take it out of the list of assigned categories
            _lvAssignedCategories.Items.Remove(item);
        }

        private void _transaction_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_transaction.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                    _transaction.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()[0] == '=')
                {
                    //if this is a formula then let's process it
                    MathParser parser = new MathParser();
                    string tmp = _transaction.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    decimal value = parser.Calculate(tmp.Substring(1, tmp.Length - 1));
                    _transaction.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
                }
            }
        }
    }
}
