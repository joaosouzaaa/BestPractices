using BestPractices.Api.ResponseTypesAttributes;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Response.Supplier;
using BestPractices.Business.Settings.PaginationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost("add_supplier")]
        [CommandsResponseTypes]
        public async Task<bool> AddSupplierAsync([FromBody] SupplierSaveRequest saveRequest) =>
            await _supplierService.SaveAsync(saveRequest);

        [HttpPut("update_supplier")]
        [CommandsResponseTypes]
        public async Task<bool> UpdateSupplierAsync([FromBody] SupplierUpdateRequest updateRequest) =>
            await _supplierService.UpdateAsync(updateRequest);

        [HttpDelete("delete_supplier")]
        [CommandsResponseTypes]
        public async Task<bool> DeleteSupplierAsync([FromQuery] int id) =>
            await _supplierService.DeleteAsync(id);

        [HttpGet("find_supplier")]
        [QueryCommandsResponseTypes]
        public async Task<SupplierResponse> FindSupplierAsync([FromQuery] int id) =>
            await _supplierService.FindByIdAsync(id);

        [HttpGet("findall_suppliers")]
        [QueryCommandsResponseTypes]
        public async Task<List<SupplierResponse>> FindAllSuppliersAsync() =>
            await _supplierService.FindAllEntitiesAsync();

        [HttpGet("findall_suppliers_pagination")]
        [QueryCommandsResponseTypes]
        public async Task<PageList<SupplierResponse>> FindAllSuppliersPaginationAsync([FromQuery] PageParams pageParams) =>
            await _supplierService.FindAllEntitiesWithPaginationAsync(pageParams);
    }
}
