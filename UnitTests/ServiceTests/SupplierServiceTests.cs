using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Request.Address;
using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Services;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;
using BestPractices.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServiceTests
{
    public class SupplierServiceTests
    {
        Mock<ISupplierRepository> _repository;
        NotificationHandler _notification;
        SupplierValidation _validation;
        SupplierService _service;

        public SupplierSaveRequest SupplierSaveRequest { get; set; }

        public SupplierServiceTests()
        {
            _repository = new Mock<ISupplierRepository>();
            _notification = new NotificationHandler();
            _validation = new SupplierValidation();
            _service = new SupplierService(_repository.Object, _validation, _notification);

            AutoMapperHandler.Inicialize();

            SaveRequestData();
        }

        private void SaveRequestData()
        {
            var companyAddress = new AddressSaveRequest
            {
                City = "curitiba",
                Number = "1555",
                State = "pr",
                Street = "rua das ruas",
                ZipCode = "82820160"
            };

            SupplierSaveRequest = new SupplierSaveRequest
            {
                CNPJ = "12365478965472",
                CompanyName = "nome da companhia",
                CompanyAddress = companyAddress
            };
        }

        [Fact]
        public async Task SaveAsync_Valid()
        {
            var supplier = SupplierSaveRequest.MapTo<SupplierSaveRequest, Supplier>();

            _repository.Setup(s => s.SaveAsync(supplier)).Returns(Task.FromResult(true));

            var serviceResult = await _service.SaveAsync(SupplierSaveRequest);

            _repository.Verify(s => s.SaveAsync(supplier), Times.Once());

            Assert.True(serviceResult);
        }
    }
}
