using BestPractices.Api.ResponseTypesAttributes;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        [CommandsResponseTypes]
        public async Task<bool> AddProductAsync([FromForm] ProductSaveRequest saveRequest) =>
            await _productService.SaveAsync(saveRequest);

        [HttpPut("update_product")]
        [CommandsResponseTypes]
        public async Task<bool> UpdateProductAsync([FromForm] ProductUpdateRequest updateRequest) =>
            await _productService.UpdateAsync(updateRequest);

        [HttpDelete("delete_product")]
        [CommandsResponseTypes]
        public async Task<bool> DeleteProductAsync([FromQuery] int id) =>
            await _productService.DeleteAsync(id);

        [HttpGet("find_product")]
        [QueryCommandsResponseTypes]
        public async Task<ProductResponse> FindProductAsync([FromQuery] int id) =>
            await _productService.FindByIdAsync(id);

        [HttpGet("findall_products")]
        [QueryCommandsResponseTypes]
        public async Task<List<ProductResponse>> FindAllProductsAsync() =>
            await _productService.FindAllEntitiesAsync();

        [HttpGet("findall_products_pagination")]
        [QueryCommandsResponseTypes]
        public async Task<PageList<ProductResponse>> FindAllProductsPaginationAsync([FromQuery] PageParams pageParams) =>
            await _productService.FindAllEntitiesWithPaginationAsync(pageParams);
    }
}
