using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace AccountManager
{
    public delegate void ChangeAccount (string name);
    public partial class AccountDescription : UserControl
    {
        public event ChangeAccount OnAccountChanged;
        public Account CurrentAccount
        {
            get
            {
                Account ac = new Account();
                ac.AccountName = _accountList.SelectedItem.ToString();
                return ac;
            }
        }
        public AccountDescription()
        {
            InitializeComponent();
        }

        public void SetAccounts(List<Account> accounts)
        {
            _accountList.Items.Clear();
            accounts.Sort(delegate(Account ac1, Account ac2) { return ac1.AccountName.CompareTo(ac2.AccountName); });
            _accountList.Items.Add("All Accounts");
            foreach (Account ac in accounts)
            {
                _accountList.Items.Add(ac.AccountName);
            }
            _accountList.SelectedIndex = 0;
        }
        public void UpdateLastBalanced(string date)
        {
            _lastBalanced.Text = date;
        }
        public void UpdateBalance(string balance)
        {
            _balance.Text = balance;
        }

        private void _accountList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnAccountChanged != null)
            {
                OnAccountChanged(_accountList.SelectedItem.ToString());
            }
        }
    }
}
