using GlameraTaskAPI.Domain.DTO.FilterDto;
using GlameraTaskAPI.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace GlameraTaskAPI.Controllers
{
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpGet]
        [Route("GetSalesReport")]
        public async Task<IActionResult> GetSalesReport([FromQuery]SaleFilterDto saleFilterDto)
        {
            var saleReport = await _saleService.GetSalesReport(saleFilterDto);
            return Ok(saleReport);
        }
    }
}
