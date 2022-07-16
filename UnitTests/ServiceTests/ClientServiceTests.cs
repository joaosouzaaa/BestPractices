using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Request.Client;
using BestPractices.ApplicationService.Services;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Business.Settings.ValidationSettings;
using BestPractices.Domain.Entities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServiceTests
{
    public class ClientServiceTests
    {
        ClientService _service { get; set; }
        Mock<IClientRepository> _repository;
        Validate<Client> _validation;
        NotificationHandler _notification;

        public ClientServiceTests()
        {
            _repository = new Mock<IClientRepository>();
            _validation = new Validate<Client>();
            _notification = new NotificationHandler();
            _service = new ClientService(_repository.Object, _validation, _notification);

            AutoMapperHandler.Inicialize();
        }

        [Fact]
        public async Task Save()
        {

            var clientSaveRequest = new ClientSaveRequest
            {
                Name = "jorge",
                LastName = "pontes",
                BirthDate = new DateTime(1999, 01, 02),
                DocumentNumber = "07587869999"
            };

            var client = clientSaveRequest.MapTo<ClientSaveRequest, Client>();

            _repository.Setup(c => c.SaveAsync(client)).ReturnsAsync(true);

            var saveResult = await _service.SaveAsync(clientSaveRequest);

            Assert.True(saveResult);
            //_repository.Verify(a => a.Save(client), Times.Once);
        }
    }
}
