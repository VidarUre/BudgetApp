using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Db
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options)
            : base(options)
        {
        }

        public DbSet<Budget> Budget { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}