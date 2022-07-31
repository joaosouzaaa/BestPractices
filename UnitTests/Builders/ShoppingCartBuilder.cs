using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.Domain.Entities;

namespace UnitTests.Builders
{
    public class ShoppingCartBuilder
    {
        private decimal _totalAmount = 32.9m;
        private bool _finished = false;
        private int _totalItens = 2;
        private string _userId = Guid.NewGuid().ToString();

        public static ShoppingCartBuilder NewObject()
        {
            return new ShoppingCartBuilder();
        }

        public ShoppingCart DomainBuild()
        {
            var productList = new List<Product>();
            productList.Add(ProductBuilder.NewObject().DomainBuild());
            return new ShoppingCart
            {
                TotalAmount = _totalAmount,
                Finished = _finished,
                Id = 1,
                Products = productList,
                TotalItens = _totalItens,
                UserId = _userId
            };
        }

        public ShoppingCartSaveRequest SaveRequestBuild()
        {
            var productsIdsList = new List<int>()
            {
                1,
                2
            };

            return new ShoppingCartSaveRequest
            {
                ProductsIds = productsIdsList,
                UserId = _userId
            };
        }

        public ShoppingCartUpdateRequest UpdateRequestBuild()
        {
            return new ShoppingCartUpdateRequest
            {
                Id = 1,
                TotalAmount = _totalAmount,
                TotalItens = _totalItens
            };
        }

        public ShoppingCartResponse ResponseBuild()
        {
            var productsResponseList = new List<ProductResponse>
            {
                ProductBuilder.NewObject().ResponseBuild()
            };

            var userResponseClient = UserBuilder.NewObject().ResponseClientBuild();
            return new ShoppingCartResponse
            {
                TotalAmount = _totalAmount,
                Finished = _finished,
                Id = 1,
                ProductsResponse = productsResponseList,
                TotalItens = _totalItens,
                UserResponseClient = userResponseClient
            };
        }

        public ShoppingCartBuilder WithTotalItens(int totalItens)
        {
            _totalItens = totalItens;
            return this;
        }

        public ShoppingCartBuilder WithTotalAmount(decimal totalAmount)
        {
            _totalAmount = totalAmount;
            return this;
        }
    }
}
