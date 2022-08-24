using BestPractices.ApplicationService.Interfaces.BaseService;
using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Response.Supplier;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface ISupplierService : IBaseQueryService<SupplierSaveRequest, SupplierUpdateRequest, SupplierResponse>
    {
    }
}
