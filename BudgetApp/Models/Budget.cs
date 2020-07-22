using System.Collections.Generic;

namespace BudgetApp.Models
{
    public class Budget
    {
        public List<Item> Incomes { get; set; }
        public List<Item> Expenses { get; set; }

    }
}
