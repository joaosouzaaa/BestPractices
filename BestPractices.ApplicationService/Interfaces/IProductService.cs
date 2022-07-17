using BestPractices.ApplicationService.Interfaces.BaseService;
using BestPractices.ApplicationService.Request.Product;
using BestPractices.ApplicationService.Response.Product;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IProductService : IBaseQueryService<ProductSaveRequest, ProductUpdateRequest, ProductResponse>
    {
    }
}
