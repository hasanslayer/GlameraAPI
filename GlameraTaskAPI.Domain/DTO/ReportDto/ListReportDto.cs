using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTaskAPI.Domain.DTO.ReportDto
{
    public class ListReportDto
    {
        public string CategoryName { get; set; }
        public string BranchName { get; set; }
        public int BranchTotalQty { get; set; }
        public double BranchTotalAmount { get; set; }
    }
}
