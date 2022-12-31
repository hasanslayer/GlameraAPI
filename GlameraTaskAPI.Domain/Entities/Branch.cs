using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTaskAPI.Domain.Entities
{
    public class Branch
    {
        public Branch()
        {
            BranchSales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public ICollection<Sale> BranchSales { get; set; }
    }
}
