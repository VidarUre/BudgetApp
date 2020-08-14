using BudgetApp.Db;
using BudgetApp.Models;
using BudgetApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{

    [Authorize]
    public class BudgetController : Controller // Hallo
    {

        private readonly BudgetContext _context;

        public BudgetController(BudgetContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var budget = await _context.Budget.Where(x => x.Id == 1).SingleOrDefaultAsync();

            var items = _context.Item.Where(x => x.BudgetId == budget.Id);
            var incomes = items.Where(x => x.ItemType == 2).ToList();
            var expenses = items.Where(x => x.ItemType == 1).ToList();

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

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id, Name, Amount, ItemType")] Item item)
        {
            var budget = await _context.Budget.Where(x => x.Id == 1).SingleOrDefaultAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    item.BudgetId = budget.Id;
                    _context.Item.Add(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Item.Where(x => x.Id == id).SingleOrDefaultAsync();

            try
            {
                _context.Remove(itemToDelete);
                await _context.SaveChangesAsync();

            } catch (DbException e)
            {
                throw;
            }
        }
    }
}
