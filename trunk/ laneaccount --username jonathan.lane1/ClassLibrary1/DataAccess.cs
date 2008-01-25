using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace DataAccess
{
    public class CDataAccess
    {
        private string _fileName = "";
        private List<Budget> _budgets = new List<Budget>();
        public List<Budget> Budgets { get { return _budgets; } }
        private List<AccountTransactions> _transactions = new List<AccountTransactions>();
        public List<AccountTransactions> Transactions { get { return _transactions; } }
        private List<AccountTransactions> _accountTransactions = new List<AccountTransactions>();
        public List<AccountTransactions> AccountTransactions { get { return _accountTransactions; } }
        private List<Account> _accounts = new List<Account>();
        public List<Account> Accounts { get { return _accounts; } }
        private List<string> _categories = new List<string>();
        public List<string> Categories { get { return _categories; } }
        private int _maxTransID = 0;
        private XDocument _accountFile;
        private bool _reloadBudgets = true;
        private bool _reloadTransactions = true;
        private bool _reloadAccounts = true;
        public CDataAccess(string file)
        {
            _fileName = file;
            //read the file
            _accountFile = XDocument.Load(file);
        }

        public void ReadAllBudgets()
        {
            //don't bother to actually reload if the file hasn't changed
            if (!_reloadBudgets)
            {
                return;
            }
            //extract the budgets
            _budgets = (from budgets in _accountFile.Descendants("budgets").Elements("budget")
                        select new Budget
                        {
                            BudgetName = (string)budgets.Attribute("name"),
                            Amount = (int)budgets.Attribute("amount"),
                            BudgetPeriod = (Period)((string)budgets.Attribute("period"))[0]
                        }).ToList<Budget>();
            _reloadBudgets = false;
        }
        public void AddBudget(Budget b)
        {
            _budgets.Add(b);
            XElement element = new XElement("budget",
                                new XAttribute("name", b.BudgetName),
                                new XAttribute("amount", b.Amount),
                                new XAttribute("period", b.BudgetPeriod));
            _accountFile.Element("account").Element("budgets").Add(element);
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(_fileName, null);
            writer.Formatting = System.Xml.Formatting.Indented;
            _accountFile.WriteTo(writer);
            _reloadBudgets = true;
            writer.Close();
        }
        public void DeleteBudget(Budget b)
        {
            foreach (Budget budg in _budgets)
            {
                if (b.BudgetName == budg.BudgetName)
                {
                    _budgets.Remove(budg);
                    break;
                }
            }
            var budget = (from bud in _accountFile.Descendants("budget")
                          where (string)bud.Attribute("name") == b.BudgetName
                            select bud);
            budget.Remove();
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(_fileName, null);
            writer.Formatting = System.Xml.Formatting.Indented;
            _accountFile.WriteTo(writer);
            _reloadBudgets = true;
            writer.Close();
        }
        public void UpdateBudget(Budget b)
        {
            DeleteBudget(b);
            AddBudget(b);
        }

        public void ReadAllTransations()
        {
            if (!_reloadTransactions)
            {
                return;
            }
            _transactions = (from transactions in _accountFile.Descendants("account").Elements("transaction")
                             select new AccountTransactions
                             {
                                 TransactionDate = DateTime.Parse((string)transactions.Attribute("date")),
                                 ID = (int)transactions.Attribute("id"),
                                 Description = (string)transactions.Attribute("description"),
                                 AccountName = (string)transactions.Attribute("AccountType"),
                                 Balanced = (bool)transactions.Attribute("Balanced"),
                                 Transactions = (from trans in transactions.Elements("amount")
                                                 select new Transaction
                                                 {
                                                     Amount = (int)trans.Attribute("total"),
                                                     TransactionBudget = (string)trans.Attribute("budget"),
                                                     Categories = (from cats in trans.Elements("category")
                                                                   select(
                                                                       (string)cats.Attribute("title")
                                                                   )).ToList<string>()
                                                 }).ToList<Transaction>()
                             }).ToList<AccountTransactions>();
            _transactions.Sort(delegate(AccountTransactions t1, AccountTransactions t2)
                                {
                                    if (t1.TransactionDate == t2.TransactionDate)
                                    {
                                        return t1.ID.CompareTo(t2.ID);
                                    }
                                    return t1.TransactionDate.CompareTo(t2.TransactionDate);
                                });

            foreach (AccountTransactions t in _transactions)
            {
                foreach (Transaction tran in t.Transactions)
                {
                    foreach (string category in tran.Categories)
                    {
                        if (!_categories.Exists(delegate (string check){return check == category;}))
                        {
                            _categories.Add(category);
                        }
                    }
                }
                _maxTransID = Math.Max(t.ID ,_maxTransID);                
            }
            _reloadTransactions = false;
        }
        public void ReadTransactions(Account ac)
        {
            ReadAllTransations();
            _accountTransactions = (from acnt in _transactions
                                   where acnt.AccountName == ac.AccountName
                                   select acnt).ToList<AccountTransactions>();
            _accountTransactions.Sort(delegate(AccountTransactions t1, AccountTransactions t2)
                                        {
                                            if (t1.TransactionDate == t2.TransactionDate)
                                            {
                                                return t1.ID.CompareTo(t2.ID);
                                            }
                                            return t1.TransactionDate.CompareTo(t2.TransactionDate);
                                        });
        }
        public void AddTransaction(AccountTransactions trans)
        {
            //add the transaction into the list
            trans.ID = (++_maxTransID);

            _transactions.Add(trans);
            XElement element = new XElement("transaction",
                                new XAttribute("date", trans.TransactionDate.ToShortDateString()),
                                new XAttribute("id", trans.ID),
                                new XAttribute("description", trans.Description),
                                new XAttribute("AccountType" ,trans.AccountName),
                                new XAttribute("Balanced", trans.Balanced));

            foreach (Transaction t in trans.Transactions)
            {
                XElement AmountElement = new XElement("amount");
                AmountElement.Add(new XAttribute("total", t.Amount),
                                  new XAttribute("budget", t.TransactionBudget));
                foreach (string cat in t.Categories)
                {
                    AmountElement.Add(new XElement("category", 
                                        new XAttribute ("title", cat)));
                }
                element.Add(AmountElement);
            }
            //write the file
            _accountFile.Element("account").Add(element);
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(_fileName ,null);
            writer.Formatting = System.Xml.Formatting.Indented;
            _accountFile.WriteTo(writer);
            _reloadTransactions = true;
            writer.Close();
        }
        
        public AccountTransactions GetTransaction(int TransactionID)
        {
            //Find the transaction with this ID from the list
            return (from acnt in _transactions
             where acnt.ID == TransactionID
             select acnt).ToArray()[0];
        }
        public void BalanceTransaction(int TransactionID)
        {
            // Find this transaction in the list and set it to be balanced
            AccountTransactions t = GetTransaction(TransactionID);
            t.Balanced = true;
            UpdateTransaction(t);
        }
        
        /// <summary>
        /// Updates a single transaction in the list
        /// </summary>
        /// <param name="trans">the updated transaction (keys on id)</param>
        public void UpdateTransaction(AccountTransactions trans)
        {
            DeleteTransaction(trans);
            AddTransaction(trans);
        }
        public void DeleteTransaction(AccountTransactions trans)
        {
            //Remove from the list
            foreach (AccountTransactions t in _transactions)
            {
                if (t.ID == trans.ID)
                {
                    _transactions.Remove(t);
                    break;
                }
            }
            //Query for the correct node in the _accountFile
            var transaction = (from accounttrans in _accountFile.Descendants("transaction")
                               where (int)accounttrans.Attribute("id") == trans.ID
                                   select accounttrans);
            //Pass it to remove
            transaction.Remove();
            //Save
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(_fileName, null);
            writer.Formatting = System.Xml.Formatting.Indented;
            _accountFile.WriteTo(writer);
            _reloadTransactions = true;
            writer.Close();
        }

        public void ReadAllAccounts()
        {
            if (!_reloadAccounts)
            {
                return;
            }
            _accounts = (from account in _accountFile.Descendants("accounts").Elements("AccountType")
                        select new Account
                        {
                            AccountName = (string)account.Attribute("name"),
                        }).ToList<Account>();
            _reloadAccounts = false;
        }
        public void DeleteAccount(Account account)
        {
            foreach (Account ac in _accounts)
            {
                if (ac.AccountName == account.AccountName)
                {
                    _accounts.Remove(ac);
                    break;
                }
            }
            var acc = (from acnt in _accountFile.Descendants("AccountType")
                          where (string)acnt.Attribute("name") == account.AccountName
                      select acnt);
            acc.Remove();
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(_fileName, null);
            writer.Formatting = System.Xml.Formatting.Indented;
            _accountFile.WriteTo(writer);
            _reloadAccounts = true;
            writer.Close();
        }
        public void AddAccount(Account account)
        {
            _accounts.Add(account);
            XElement element = new XElement("AccountType",
                                new XAttribute("name", account.AccountName));
            _accountFile.Element("account").Element("accounts").Add(element);
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(_fileName, null);
            writer.Formatting = System.Xml.Formatting.Indented;
            _accountFile.WriteTo(writer);
            _reloadAccounts = true;
            writer.Close();
        }
        public void UpdateAccount(Account oldAc, Account newAc)
        {
            DeleteAccount(oldAc);
            AddAccount(newAc);
        }
    }
}
