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

        public SupplierServiceTests()
        {
            _repository = new Mock<ISupplierRepository>();
            _notification = new NotificationHandler();
            _validation = new SupplierValidation();
            _service = new SupplierService(_repository.Object, _validation, _notification);

            AutoMapperHandler.Inicialize();
        }

        [Fact]
        public async Task SaveAsync_ReturnsTrue()
        {
            var supplierSaveRequest = SupplierBuilder.NewObject().SaveRequestBuild();
            _repository.Setup(s => s.SaveAsync(It.IsAny<Supplier>())).Returns(Task.FromResult(true));

            var serviceResult = await _service.SaveAsync(supplierSaveRequest);
            var hasNotification = _notification.HasNotification();

            _repository.Verify(s => s.SaveAsync(It.IsAny<Supplier>()), Times.Once());
            Assert.True(serviceResult);
            Assert.False(hasNotification);
        }
    }
}
