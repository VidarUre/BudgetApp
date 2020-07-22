using BudgetApp.Models;
using BudgetApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BudgetApp.Controllers
{
    public class BudgetController : Controller // Hallo
    {
        public IActionResult Index()
        {
            // Hente inntekter og utgifter fra DB

            var incomes = new List<Item>
            {
                new Item
                {
                    Name = "Lønn",
                    Amount = 26000
                },
                new Item
                {
                    Name = "Månedslønn fra mams <3",
                    Amount = 500
                }
            };

            var expenses = new List<Item>
            {
                new Item
                {
                    Name = "Leie",
                    Amount = 11000
                },
                new Item
                {
                    Name = "Mat",
                    Amount = 2500
                }
            };

            var budgetVm = new BudgetViewModel();
            budgetVm.Income = incomes;
            budgetVm.Expenses = expenses;

            var incomeTotal = incomes.Sum(x => x.Amount);
            var expenseTotal = expenses.Sum(x => x.Amount);
            budgetVm.IncomeTotal = incomeTotal;
            budgetVm.ExpenseTotal = expenseTotal;

            budgetVm.Total = incomeTotal - expenseTotal;

            return View(budgetVm);
        }
    }
}
