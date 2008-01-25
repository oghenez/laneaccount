using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public enum Period
    {
        weekly='w',
        monthly='m',
        annual='a',
        none='n'
    }

    public class Account
    {
        string _name;
        public string AccountName { get { return _name; } set { _name = value; } }
    }

    public class AccountTransactions
    {
        int _id = 0;
        public int ID { get { return _id; } set { _id = value; } }
        DateTime _transactionDate;
        public DateTime TransactionDate { get { return _transactionDate; } set { _transactionDate = value; } }
        string _description;
        public string Description { get { return _description; } set { _description = value; } }
        string _account;
        public string AccountName { get { return _account; } set { _account = value; } }
        bool _balanced;
        public bool Balanced { get { return _balanced; } set { _balanced = value; } }
        private List<Transaction> _transactions = new List<Transaction>();
        public List<Transaction> Transactions { get { return _transactions; } set { _transactions = value; } }
    }

    public class Transaction
    {
        int _amount;
        public int Amount { get { return _amount; } set { _amount = value; } }
        string _budget;
        public string TransactionBudget { get { return _budget; } set { _budget = value; } }
        List<string> _categories = new List<string>();
        public List<string> Categories { get { return _categories; } set { _categories = value; } }
    }
    public class Budget
    {
        private string _budgetName;
        public string BudgetName { get { return _budgetName; } set { _budgetName = value; } }
        private int _amount;
        public int Amount { get { return _amount; } set { _amount = value; } }
        private Period _period;
        public Period BudgetPeriod { get { return _period; } set { _period = value; } }
    }
}
