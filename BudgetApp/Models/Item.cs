
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        [ForeignKey("Budget")]
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
        public string Name { get; set; }
        public int ItemType { get; set; }
        public int Amount { get; set; }
    }
}
