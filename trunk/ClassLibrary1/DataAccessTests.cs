using System;
using NUnit.Framework.Constraints;
using NUnit.Framework.SyntaxHelpers;
using NUnit.Framework;
using DataAccess;   

namespace DataAccess
{
    [TestFixture]
    public class DataAccessTests
    {
        string fileName= @"C:\Documents and Settings\jon\My Documents\Visual Studio 2008\Projects\AccountManager\ClassLibrary1\TestData.xml";
        CDataAccess da;
        [Test]
        public void TestOpenFile()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
        }

        [Test]
        public void TestReadBudgets()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllBudgets();
            Assert.That(da.Budgets.Count == 3);
            Assert.That(da.Budgets[0].Amount == 0);
            Assert.That(da.Budgets[0].BudgetName == "excess");
            Assert.That(da.Budgets[0].BudgetPeriod == Period.none);

            Assert.That(da.Budgets[1].Amount == 25);
            Assert.That(da.Budgets[1].BudgetName == "food");
            Assert.That(da.Budgets[1].BudgetPeriod == Period.weekly);

            Assert.That(da.Budgets[2].Amount == 705);
            Assert.That(da.Budgets[2].BudgetName == "mortgage");
            Assert.That(da.Budgets[2].BudgetPeriod == Period.monthly);
        }

        [Test]
        public void TestAddBudget()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllBudgets();

            AddBudget();

            da.ReadAllBudgets();

            Assert.That(da.Budgets.Count == 4);
            Assert.That(da.Budgets[3].Amount == 7500);
            Assert.That(da.Budgets[3].BudgetName == "Other");
            Assert.That(da.Budgets[3].BudgetPeriod == Period.annual);

            DeleteBudget();
        }

        [Test]
        public void TestUpdateBudget()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllBudgets();
            AddBudget();

            Budget budg = new Budget();
            budg.Amount = 7600;
            budg.BudgetName = "Other";
            budg.BudgetPeriod = Period.none;

            da.UpdateBudget(budg);
            da.ReadAllBudgets();

            Assert.That(da.Budgets.Count == 4);
            Assert.That(da.Budgets[3].Amount == 7600);
            Assert.That(da.Budgets[3].BudgetName == "Other");
            Assert.That(da.Budgets[3].BudgetPeriod == Period.none);

            DeleteBudget();
        }

        [Test]
        public void TestDeleteBudget()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllBudgets();

            AddBudget();
            DeleteBudget();

            da.ReadAllBudgets();

            Assert.That(da.Budgets.Count == 3);
            Assert.That(da.Budgets[0].BudgetName != "Other");
            Assert.That(da.Budgets[1].BudgetName != "Other");
            Assert.That(da.Budgets[2].BudgetName != "Other");
        }

        [Test]
        public void TestReadTransactions()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllTransations();
            Assert.That(da.Transactions.Count == 2);

            Assert.That(da.Transactions[0].Description == "Spent at Sainsburys");
            Assert.That(da.Transactions[0].AccountName == "CreditCard");
            Assert.That(da.Transactions[0].Balanced == true);
            Assert.That(da.Transactions[0].ID == 0);
            Assert.That(da.Transactions[0].TransactionDate == DateTime.Parse("1/1/2007"));
            Assert.That(da.Transactions[0].Transactions.Count == 2);
            Assert.That(da.Transactions[0].Transactions[0].Amount == 1250);
            Assert.That(da.Transactions[0].Transactions[0].TransactionBudget == "food");
            Assert.That(da.Transactions[0].Transactions[0].Categories.Count == 2);
            Assert.That(da.Transactions[0].Transactions[0].Categories[0] == "food");
            Assert.That(da.Transactions[0].Transactions[0].Categories[1] == "crisps");
            Assert.That(da.Transactions[0].Transactions[1].Amount == 1325);
            Assert.That(da.Transactions[0].Transactions[1].TransactionBudget == "excess");
            Assert.That(da.Transactions[0].Transactions[1].Categories.Count == 1);
            Assert.That(da.Transactions[0].Transactions[1].Categories[0] == "music");

            Assert.That(da.Transactions[1].Description == "Spent at Tesco");
            Assert.That(da.Transactions[1].ID == 1);
            Assert.That(da.Transactions[1].AccountName == "Current");
            Assert.That(da.Transactions[1].Balanced == false);
            Assert.That(da.Transactions[1].TransactionDate == DateTime.Parse("2/1/2007"));
            Assert.That(da.Transactions[1].Transactions.Count == 1);
            Assert.That(da.Transactions[1].Transactions[0].Amount == 1023);
            Assert.That(da.Transactions[1].Transactions[0].TransactionBudget == "food");
            Assert.That(da.Transactions[1].Transactions[0].Categories.Count == 1);
            Assert.That(da.Transactions[1].Transactions[0].Categories[0] == "junk");
        }

        [Test]
        public void TestAddTransaction()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllTransations();
            Assert.That(da.Transactions.Count == 2);
            AddTransaction();

            da.ReadAllTransations();

            Assert.That(da.Transactions.Count == 3);
            Assert.That(da.Transactions[2].Description == "Unit Test");
            Assert.That(da.Transactions[2].ID == 2);
            Assert.That(da.Transactions[2].AccountName == "Savings");
            Assert.That(da.Transactions[2].Balanced == true);
            Assert.That(da.Transactions[2].TransactionDate == DateTime.Parse("3/1/2008"));
            Assert.That(da.Transactions[2].Transactions.Count == 2);
            Assert.That(da.Transactions[2].Transactions[0].Amount == 1234);
            Assert.That(da.Transactions[2].Transactions[0].TransactionBudget == "Other");
            Assert.That(da.Transactions[2].Transactions[0].Categories.Count == 1);
            Assert.That(da.Transactions[2].Transactions[0].Categories[0] == "Cat1");
            Assert.That(da.Transactions[2].Transactions[1].Amount == 4321);
            Assert.That(da.Transactions[2].Transactions[1].TransactionBudget == "Other1");
            Assert.That(da.Transactions[2].Transactions[1].Categories.Count == 2);
            Assert.That(da.Transactions[2].Transactions[1].Categories[0] == "Cat2");
            Assert.That(da.Transactions[2].Transactions[1].Categories[1] == "Cat3");

            DeleteTransaction();
        }

        [Test]
        public void TestUpdateTransaction()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllTransations();
            AddTransaction();
            Assert.That(da.Transactions.Count == 3);

            AccountTransactions trans = new AccountTransactions();
            trans.Description = "Unit Test";
            trans.ID = 2;
            trans.AccountName = "Savings";
            trans.Balanced = true;
            trans.TransactionDate = DateTime.Parse("4/1/2008");
            Transaction t1 = new Transaction();
            t1.Amount = 1235;
            t1.TransactionBudget = "Other";
            t1.Categories.Add("Cat1");
            Transaction t2 = new Transaction();
            t2.Amount = 5321;
            t2.TransactionBudget = "Other1";
            t2.Categories.Add("Cat2");
            t2.Categories.Add("Cat4");
            trans.Transactions.Add(t1);
            trans.Transactions.Add(t2);

            da.UpdateTransaction(trans);
            da.ReadAllTransations();

            Assert.That(da.Transactions.Count == 3);
            Assert.That(da.Transactions[2].Description == "Unit Test");
            Assert.That(da.Transactions[2].ID == 2);
            Assert.That(da.Transactions[2].Balanced == true);
            Assert.That(da.Transactions[2].AccountName == "Savings");
            Assert.That(da.Transactions[2].TransactionDate == DateTime.Parse("4/1/2008"));
            Assert.That(da.Transactions[2].Transactions.Count == 2);
            Assert.That(da.Transactions[2].Transactions[0].Amount == 1235);
            Assert.That(da.Transactions[2].Transactions[0].TransactionBudget == "Other");
            Assert.That(da.Transactions[2].Transactions[0].Categories.Count == 1);
            Assert.That(da.Transactions[2].Transactions[0].Categories[0] == "Cat1");
            Assert.That(da.Transactions[2].Transactions[1].Amount == 5321);
            Assert.That(da.Transactions[2].Transactions[1].TransactionBudget == "Other1");
            Assert.That(da.Transactions[2].Transactions[1].Categories.Count == 2);
            Assert.That(da.Transactions[2].Transactions[1].Categories[0] == "Cat2");
            Assert.That(da.Transactions[2].Transactions[1].Categories[1] == "Cat4");
            DeleteTransaction();
        }

        [Test]
        public void TestDeleteTransaction()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllTransations();
            AddTransaction();
            Assert.That(da.Transactions.Count == 3);

            da.ReadAllTransations();
            DeleteTransaction();

            da.ReadAllTransations();

            Assert.That(da.Transactions.Count == 2);
            Assert.That(da.Transactions[0].ID != 2);
            Assert.That(da.Transactions[1].ID != 2);
        }

        [Test]
        public void TestReadAccounts()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllAccounts();

            Assert.That(da.Accounts.Count == 2);
            Assert.That(da.Accounts[0].AccountName == "CreditCard");
            Assert.That(da.Accounts[1].AccountName == "Current");
        }

        [Test]
        public void TestAddAccount()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllAccounts();

            AddAccount();
            Assert.That(da.Accounts.Count == 3);
            Assert.That(da.Accounts[0].AccountName == "CreditCard");
            Assert.That(da.Accounts[1].AccountName == "Current");
            Assert.That(da.Accounts[2].AccountName == "Savings");
            DeleteAccount();
        }

        [Test]
        public void TestUpdateAccount()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllAccounts();

            AddAccount();
            Assert.That(da.Accounts.Count == 3);
            Assert.That(da.Accounts[0].AccountName == "CreditCard");
            Assert.That(da.Accounts[1].AccountName == "Current");
            Assert.That(da.Accounts[2].AccountName == "Savings");

            Account ac = new Account();
            ac.AccountName = "ISA";

            da.UpdateAccount(da.Accounts[2], ac);

            da.ReadAllAccounts();
            Assert.That(da.Accounts.Count == 3);
            Assert.That(da.Accounts[0].AccountName == "CreditCard");
            Assert.That(da.Accounts[1].AccountName == "Current");
            Assert.That(da.Accounts[2].AccountName == "ISA");

            da.DeleteAccount(ac);
        }

        [Test]
        public void TestDeleteAccount()
        {
            da = new CDataAccess(fileName);
            Assert.IsNotNull(da);
            da.ReadAllAccounts();

            AddAccount();
            Assert.That(da.Accounts.Count == 3);
            Assert.That(da.Accounts[0].AccountName == "CreditCard");
            Assert.That(da.Accounts[1].AccountName == "Current");
            Assert.That(da.Accounts[2].AccountName == "Savings");
            DeleteAccount();
            Assert.That(da.Accounts.Count == 2);
            Assert.That(da.Accounts[0].AccountName == "CreditCard");
            Assert.That(da.Accounts[1].AccountName == "Current");
        }

        private void AddBudget()
        {
            Budget budg = new Budget();
            budg.Amount = 7500;
            budg.BudgetName = "Other";
            budg.BudgetPeriod = Period.annual;
            da.AddBudget(budg);
        }
        private void DeleteBudget()
        {
            Budget budg = new Budget();
            budg.Amount = 7500;
            budg.BudgetName = "Other";
            budg.BudgetPeriod = Period.annual;

            da.DeleteBudget(budg);
        }
        private void AddTransaction()
        {
            AccountTransactions trans = new AccountTransactions();
            trans.Description = "Unit Test";
            trans.AccountName = "Savings";
            trans.Balanced = true;
            trans.ID = 2;
            trans.TransactionDate = DateTime.Parse("3/1/2008");
            Transaction t1 = new Transaction();
            t1.Amount = 1234;
            t1.TransactionBudget = "Other";
            t1.Categories.Add("Cat1");
            Transaction t2 = new Transaction();
            t2.Amount = 4321;
            t2.TransactionBudget = "Other1";
            t2.Categories.Add("Cat2");
            t2.Categories.Add("Cat3");
            trans.Transactions.Add(t1);
            trans.Transactions.Add(t2);

            da.AddTransaction(trans);
        }
        private void DeleteTransaction()
        {
            AccountTransactions trans = new AccountTransactions();
            trans.Description = "Unit Test";
            trans.ID = 2;
            trans.TransactionDate = DateTime.Parse("4/1/2008");
            Transaction t1 = new Transaction();
            t1.Amount = 1235;
            t1.TransactionBudget = "Other";
            t1.Categories.Add("Cat1");
            Transaction t2 = new Transaction();
            t2.Amount = 5321;
            t2.TransactionBudget = "Other1";
            t2.Categories.Add("Cat2");
            t2.Categories.Add("Cat4");
            trans.Transactions.Add(t1);
            trans.Transactions.Add(t2);

            da.DeleteTransaction(trans);
        }
        private void AddAccount()
        {
            Account ac = new Account();
            ac.AccountName = "Savings";
            da.AddAccount(ac);
        }
        private void DeleteAccount()
        {
            Account ac = new Account();
            ac.AccountName = "Savings";
            da.DeleteAccount(ac);

        }
    }
}
