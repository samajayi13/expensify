using System.Collections.Generic;

namespace Expensify.Models
{
    public class YearlyReportModel
    {
        public List<MonthlyExpense> monthlyExpenses { get; set; }
        public string username { get; private set; }

        public YearlyReportModel(string username)
        {
            monthlyExpenses = new List<MonthlyExpense>();
            this.username = username;
            this.GetYearlyReport();
        }

        public void GetYearlyReport()
        {
            for (int i = 1;  i <= 12; ++i)
            {
                MonthlyExpense monthlyExpense = new MonthlyExpense();
                
                monthlyExpense.GetCurrentData(this.username, i);
                this.monthlyExpenses.Add(monthlyExpense);

            }
        }
    }
}