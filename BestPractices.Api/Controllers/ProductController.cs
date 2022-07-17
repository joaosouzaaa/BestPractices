using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.Product;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Business.Settings.PaginationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add_product")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> AddProductAsync([FromForm] ProductSaveRequest saveRequest) =>
            await _productService.SaveAsync(saveRequest);

        [HttpPut("update_product")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> UpdateProductAsync([FromForm] ProductUpdateRequest updateRequest) =>
            await _productService.UpdateAsync(updateRequest);

        [HttpDelete("delete_product")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> DeleteProductAsync([FromQuery] int id) =>
            await _productService.DeleteAsync(id);

        [HttpGet("find_product")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<ProductResponse> FindProductAsync([FromQuery] int id) =>
            await _productService.FindByIdAsync(id);

        [HttpGet("findall_products")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<List<ProductResponse>> FindAllProductsAsync() =>
            await _productService.FindAllEntitiesAsync();

        [HttpGet("findall_products_pagination")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<PageList<ProductResponse>> FindAllProductsPaginationAsync([FromQuery] PageParams pageParams) =>
            await _productService.FindAllEntitiesWithPaginationAsync(pageParams);
    }
}
