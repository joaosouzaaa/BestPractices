using BestPractices.ApplicationService.Request.Enums;
using BestPractices.ApplicationService.Request.Product;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using UnitTests.Builders.Helpers;

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
        private ECategoryRequest _categoryRequest = ECategoryRequest.Eletronics;

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

        public ProductSaveRequest SaveRequestBuild()
        {
            return new ProductSaveRequest
            {
                Brand = _brand,
                Category = _categoryRequest,
                Description = _description,
                Image = Utils.BuildIFormFile(),
                Price = _price,
                ProductName = _productName,
                ShoppingCartId = 1,
                SupplierId = 1,
                TransportationPrice = _transportationPrice
            };
        }

        public ProductUpdateRequest UpdateRequestBuild()
        {
            return new ProductUpdateRequest
            {
                Brand = _brand,
                Category = _categoryRequest,
                Description = _description,
                Id = 1,
                Image = Utils.BuildIFormFile(),
                Price = _price,
                ProductName = _productName,
                TransportationPrice = _transportationPrice
            };
        }

        public ProductResponse ResponseBuild()
        {
            return new ProductResponse
            {
                Brand = _brand,
                Category = _category,
                Description = _description,
                FileImageResponse = FileImageBuilder.NewObject().ResponseBuild(),
                Id = 1,
                Price = _price,
                ProductName = _productName,
                SupplierResponse = SupplierBuilder.NewObject().ResponseBuild(),
                TransportationPrice = _transportationPrice
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
