using BestPractices.Domain.Entities;

namespace UnitTests.Builders
{
    public class ShoppingCartBuilder
    {
        private decimal _totalAmount = 32.9m;
        private bool _finished = false;
        private int _totalItens = 2;

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
                UserId = Guid.NewGuid().ToString()
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
