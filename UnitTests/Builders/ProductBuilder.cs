using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;

namespace UnitTests.Builders
{
    public class ProductBuilder
    {
        private string _brand = "brand here";
        private ECategory _category = ECategory.Eletronics;
        private string _description = "description here";
        private decimal _price = 10.12m;
        private string _productName = "product name here";
        private decimal _transportationPrice = 15.5m;

        public static ProductBuilder NewObject()
        {
            return new ProductBuilder();
        }

        public Product DomainBuild()
        {
            var fileImage = FileImageBuilder.NewObject().DomainBuild();
            return new Product
            {
                Brand = _brand,
                Category = _category,
                Description = _description,
                FileImageId = 1,
                Id = 1,
                Price = _price,
                ProductName = _productName,
                ShoppingCartId = 1,
                SupplierId = 1,
                TransportationPrice = _transportationPrice,
                FileImage = fileImage
            };
        }

        public ProductBuilder WithBrand(string brand)
        {
            _brand = brand;
            return this;
        }

        public ProductBuilder WithProductName(string productName)
        {
            _productName = productName;
            return this;
        }

        public ProductBuilder WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public ProductBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ProductBuilder WithTransportationPrice(decimal transportationPrice)
        {
            _transportationPrice = transportationPrice;
            return this;
        }
    }
}
