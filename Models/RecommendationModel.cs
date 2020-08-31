using Expensify.Models;
using System.Linq;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Proxies;

namespace Expensify.Controllers
{
    internal class RecommendationModel
    {
        private readonly string username;
        private int budgetFigure;
        private readonly MonthlyExpense monthlyExpense;
        private readonly int month;
        private float ratio;
        public int SavingsRecommendation { get; set; }
        public int PersonalRecommendation { get; set; }
        public int MiscellaneousRecommendation { get; set; }
        private int SavingsTotal { get; set; }
        private int PersonalTotal { get; set; }
        private int MiscellaneousTotal { get; set; }

        public RecommendationModel(string username, int budgetFigure,MonthlyExpense monthlyExpense,int month)
        {
            this.username = username;
            this.budgetFigure = budgetFigure;
            this.monthlyExpense = monthlyExpense;
            this.month = month;
            this.ratio = GetRatioDifference();
            this.GetCategoryTotals();
            this.DivideByRatio();
        }

        private float GetRatioDifference()
        {
            return ((float)(budgetFigure / Convert.ToDecimal(this.monthlyExpense.FinalExpense.BudgetAmount)));
        }

        private void GetCategoryTotals()
        {
            DbModel1 database = new DbModel1();
            var rows = database.Expenses
            .Where(u => u.username == this.username).ToList()
            .Where(m => m.month == this.month).ToList();
            
            foreach (var r in rows)
            {

                if (r.category == "SAVINGS")
                {
                    this.SavingsTotal += r.actual_amount;
                }
                else if (r.category == "PERSONAL CARE")
                {
                    this.PersonalTotal += r.actual_amount;
                }
                else if (r.category == "MISCELLANEOUS")
                {
                    this.MiscellaneousTotal += r.actual_amount;
                }
            }
        }

        private void DivideByRatio()
        {
            this.MiscellaneousRecommendation = Convert.ToInt32(this.MiscellaneousTotal / this.ratio);
            this.PersonalRecommendation = Convert.ToInt32(this.PersonalTotal / this.ratio);
            this.SavingsRecommendation = Convert.ToInt32(SavingsTotal / this.ratio);

        }
    }

}