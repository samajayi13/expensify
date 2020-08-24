using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace Expensify.Models
{
    public class MonthlyExpense
    {
        public Dictionary<string,List<Expense>> Expenses  { get; set; }

        public Expense FinalExpense { get; set; }

        private string username;
        private int month ;

        public MonthlyExpense()
        {
            Expenses = new Dictionary<string, List<Expense>>();
        }

        private void CalculateFinalExpense()
        {
            FinalExpense = new Expense("Total Expense", 0, 0, 0);
            foreach(var key in Expenses.Keys)
            {
                foreach(var expense in Expenses[key])
                {
                    FinalExpense.Amount += expense.Amount;
                    FinalExpense.BudgetAmount += expense.BudgetAmount;
                    FinalExpense.Difference += expense.Difference;
                    
                }
            }

        }

        public void UpdateData(object[] actualAmount, object[] budgetAmount, object[] category,int month,string username)
        {
            DbModel1 database = new DbModel1();

            for (int i = 0; i <= actualAmount.Length-1; i++)
            {
                int budgetAmountInt = int.Parse(budgetAmount[i].ToString());
                int actualAmountInt = int.Parse(actualAmount[i].ToString());
                Expense expense = new Expense(
                        category[i].ToString(), 
                        budgetAmountInt,
                        actualAmountInt,
                        budgetAmountInt - actualAmountInt
                    );
                var singleItem =  database.Expenses.Single(x => x.name == expense.Name && x.month == month && x.username == username);
                singleItem.actual_amount = expense.Amount;
                singleItem.budget = expense.BudgetAmount;
            }

            database.SaveChanges();
        }

        public void GetCurrentData(string passdedUsername, int passedMonth)
        {
            DbModel1 database = new DbModel1();
            month = passedMonth;
            username = passdedUsername;
            var rows = database.Expenses
                .Where(u => u.username == passdedUsername).ToList()
                .Where(m => m.month == passedMonth).ToList();

            List<Expense> Savings = new List<Expense>();
            List<Expense> PersonalCare = new List<Expense>();
            List<Expense> Miscellaneous = new List<Expense>();

            foreach (var r in rows)
            {
                Expense expense =  new Expense(r.name, r.budget, r.actual_amount,  r.budget - r.actual_amount);

                if (r.category == "SAVINGS")
                {
                    Savings.Add(expense);
                }else if (r.category == "PERSONAL CARE")
                {
                    PersonalCare.Add(expense);
                }else if(r.category == "MISCELLANEOUS")
                {
                    Miscellaneous.Add(expense);
                }
            }

            Expenses.Add("PERSONAL CARE", PersonalCare);

            Expenses.Add("SAVINGS", Savings);

            Expenses.Add("MISCELLANEOUS", Miscellaneous);

            CalculateFinalExpense();

        }
    }
}