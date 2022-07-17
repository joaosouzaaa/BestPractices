using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.Services
{
    public class ProductService : BaseService<Product> //IProductService
    {
        public ProductService(IValidate<Product> validate, INotificationHandler notification) : base(validate, notification)
        {
        }
    }
}
