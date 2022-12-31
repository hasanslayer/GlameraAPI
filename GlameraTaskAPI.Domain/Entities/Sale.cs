using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTaskAPI.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Qty { get; set; }
        public double Amount { get; set; }

        public Item Item { get; set; }
        public int ItemId { get; set; }

        public Branch Branch { get; set; }
        public int BranchId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
