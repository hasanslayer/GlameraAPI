using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTaskAPI.Domain.DTO.FilterDto
{
    public class SaleFilterDto
    {
        public int branchId { get; set; } = 0;
        public int categoryId { get; set; } = 0;
        public DateTime date { get; set; } = DateTime.MinValue;
    }
}
