using BudgetApp.Db;
using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Repositories
{
    public class BudgetRepository
    {
        private BudgetContext _context { get; set; }
        private int dummyId { get; set; }

        public BudgetRepository(BudgetContext context)/* : base(context)*/
        {
            _context = context;
            dummyId = 1;
        }

        public Budget GetBudget()
        {
            return _context.Budget.Where(x => x.Id == dummyId).SingleOrDefault();
        }
    }
}
