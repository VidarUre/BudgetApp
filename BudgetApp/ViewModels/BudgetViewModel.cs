using BudgetApp.Models;
using System.Collections.Generic;

namespace BudgetApp.ViewModels
{
    public class BudgetViewModel
    {
        public List<Item> Income { get; set; }
        public List<Item> Expenses { get; set; }
        public int IncomeTotal { get; set; }
        public int ExpenseTotal { get; set; }
        public int Total { get; set; }
    }
}
