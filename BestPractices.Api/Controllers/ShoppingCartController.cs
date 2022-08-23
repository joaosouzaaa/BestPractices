using BestPractices.Api.ResponseTypesAttributes;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.Business.Settings.NotificationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost("add_shoppingcart")]
        [CommandsResponseTypes]
        public async Task<bool> AddShoppingCartAsync([FromBody] ShoppingCartSaveRequest saveRequest) =>
            await _shoppingCartService.SaveAsync(saveRequest);

        [HttpPut("update_shoppingcart")]
        [CommandsResponseTypes]
        public async Task<bool> UpdateShoppingCartAsync([FromBody] ShoppingCartUpdateRequest updateRequest) =>
            await _shoppingCartService.UpdateAsync(updateRequest);

        [HttpDelete("delete_shoppingcart")]
        [CommandsResponseTypes]
        public async Task<bool> DeleteShoppingCartAsync([FromQuery] int id) =>
            await _shoppingCartService.DeleteAsync(id);

        [HttpGet("find_shoppingcart")]
        [QueryCommandsResponseTypes]
        public async Task<ShoppingCartResponse> FindShoppingCartAsync([FromQuery] int id) =>
            await _shoppingCartService.FindByIdAsync(id);

        [HttpPut("add_product")]
        [CommandsResponseTypes]
        public async Task<bool> AddProductAsync(int shoppingCartId, int productId) =>
            await _shoppingCartService.AddProductAsync(shoppingCartId, productId);

        [HttpPut("remove_product")]
        [CommandsResponseTypes]
        public async Task<bool> RemoveProductAsync(int shoppingCartId, int productId) =>
            await _shoppingCartService.RemoveProductAsync(shoppingCartId, productId);
    }
}
