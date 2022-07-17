using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.Business.Settings.NotificationSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> AddShoppingCartAsync([FromBody] ShoppingCartSaveRequest saveRequest) =>
            await _shoppingCartService.SaveAsync(saveRequest);

        [HttpPut("update_shoppingcart")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> UpdateShoppingCartAsync([FromBody] ShoppingCartUpdateRequest updateRequest) =>
            await _shoppingCartService.UpdateAsync(updateRequest);

        [HttpDelete("delete_shoppingcart")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> DeleteShoppingCartAsync([FromQuery] int id) =>
            await _shoppingCartService.DeleteAsync(id);

        [HttpGet("find_shoppingcart")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<ShoppingCartResponse> FindSupplierAsync([FromQuery] int id) =>
            await _shoppingCartService.FindByIdAsync(id);

        [HttpPut("add_product")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> AddProductAsync(int shoppingCartId, int productId) =>
            await _shoppingCartService.AddProductAsync(shoppingCartId, productId);

        [HttpPut("remove_product")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> RemoveProductAsync(int shoppingCartId, int productId) =>
            await _shoppingCartService.RemoveProductAsync(shoppingCartId, productId);
    }
}
