using GlameraTaskAPI.Domain.DTO.FilterDto;
using GlameraTaskAPI.Domain.DTO.ReportDto;
using GlameraTaskAPI.Presistence;
using GlameraTaskAPI.Service.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTaskAPI.Service.Implementation
{
    public class SaleService : ISaleService
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SaleReportDto>> GetSalesReport(SaleFilterDto saleFilterDto)
        {
            var saleReport = await (from sale in _dbContext.Sales
                                    join branch in _dbContext.Branches on sale.BranchId equals branch.Id
                                    join category in _dbContext.Categories on sale.CategoryId equals category.Id
                                    where (branch.Id == saleFilterDto.branchId || saleFilterDto.branchId == 0)
                                        && (category.Id == saleFilterDto.categoryId || saleFilterDto.categoryId == 0)
                                        && (sale.Date == saleFilterDto.date || saleFilterDto.date == DateTime.MinValue)
                                    select new SaleReportDto
                                    {
                                        BranchName = branch.Name,
                                        CategoryName = category.Name,
                                        BranchTotalQty = branch.BranchSales.Select(bs => bs.Qty).Sum(),
                                        BranchTotalAmount = branch.BranchSales.Select(bs => bs.Amount).Sum(),
                                    }).ToListAsync();


            return saleReport;
        }
    }
}
