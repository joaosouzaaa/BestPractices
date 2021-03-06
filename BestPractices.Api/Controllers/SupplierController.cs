using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Response.Supplier;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Business.Settings.PaginationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> AddSupplierAsync([FromBody] SupplierSaveRequest saveRequest) =>
            await _supplierService.SaveAsync(saveRequest);

        [HttpPut("update_supplier")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> UpdateSupplierAsync([FromBody] SupplierUpdateRequest updateRequest) =>
            await _supplierService.UpdateAsync(updateRequest);

        [HttpDelete("delete_supplier")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> DeleteSupplierAsync([FromQuery] int id) =>
            await _supplierService.DeleteAsync(id);

        [HttpGet("find_supplier")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<SupplierResponse> FindSupplierAsync([FromQuery] int id) =>
            await _supplierService.FindByIdAsync(id);

        [HttpGet("findall_suppliers")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<List<SupplierResponse>> FindAllProductsAsync() =>
            await _supplierService.FindAllEntitiesAsync();

        [HttpGet("findall_suppliers_pagination")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<PageList<SupplierResponse>> FindAllProductsPaginationAsync([FromQuery] PageParams pageParams) =>
            await _supplierService.FindAllEntitiesWithPaginationAsync(pageParams);

        [HttpPut("add_product")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> AddProductAsync(int supplierId, int productId) =>
            await _supplierService.AddProductAsync(supplierId, productId);

        [HttpPut("remove_product")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> RemoveProductAsync(int supplierId, int productId) =>
            await _supplierService.RemoveProductAsync(supplierId, productId);
    }
}
