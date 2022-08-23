using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.Domain.Entities;
using Bogus;

namespace Builders
{
    public class ShoppingCartBuilder
    {
        private decimal _totalAmount = 32.9m;
        private bool _finished = false;
        private int _totalItens = 2;
        private string _userId = Guid.NewGuid().ToString();
        private int _id = new Faker().Random.Int(1, 1000);
        private List<int> _productsIdsList = new List<int>()
        {
                
            1,
            2
        };    

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
                Id = _id,
                Products = productList,
                TotalItens = _totalItens,
                UserId = _userId
            };
        }

        public ShoppingCartSaveRequest SaveRequestBuild()
        {

            return new ShoppingCartSaveRequest
            {
                ProductsIds = _productsIdsList,
                UserId = _userId
            };
        }

        public ShoppingCartUpdateRequest UpdateRequestBuild()
        {
            return new ShoppingCartUpdateRequest
            {
                Id = _id,
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
                Id = _id,
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

        public ShoppingCartBuilder WithProductsIdsList(List<int> productIdList)
        {
            _productsIdsList = productIdList;
            return this;
        }

        public ShoppingCartBuilder WithUserId(string userId)
        {
            _userId = userId;
            return this;
        }
    }
}
