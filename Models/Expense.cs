using System.Runtime.CompilerServices;

namespace Expensify
{
    public class Expense
    {
        public string Name { get; set; }
        public int Month { get; set; }
        public int BudgetAmount { get; set; }
        public int Amount { get; set; }
        public int Difference { get; set; }

        public Expense(string name, int budgetAmount, int amount ,int difference)
        {
            Name = name;
            BudgetAmount = budgetAmount;
            Amount = amount;
            Difference = difference;
        }
        public Expense(string name, int budgetAmount, int amount ,int difference,int month)
            :this(name,budgetAmount,amount,difference)
        {
            Month = month;
        }


    }
}