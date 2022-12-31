using GlameraTaskAPI.Domain.DTO.FilterDto;
using GlameraTaskAPI.Domain.DTO.ReportDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTaskAPI.Service.Contract
{
    public interface ISaleService
    {
        Task<List<SaleReportDto>> GetSalesReport(SaleFilterDto saleFilterDto);
    }
}
