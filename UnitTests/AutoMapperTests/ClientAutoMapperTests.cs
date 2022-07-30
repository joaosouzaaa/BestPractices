using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Request.Client;
using BestPractices.ApplicationService.Response.Client;
using BestPractices.Domain.Entities;
using UnitTests.AutoMapperTests.BaseAutoMapper;

namespace UnitTests.AutoMapperTests
{
    public class ClientAutoMapperTests : PageListBuild<Client, ClientResponse>
    {
        public Client Client = ClientBuilder.NewObject().DomainBuild();

        [Fact]
        public void Client_To_ClientSaveRequest()
        {
            var clientSaveRequest = Client.MapTo<Client, ClientSaveRequest>();

            Assert.Equal(clientSaveRequest.Name, Client.Name);
            Assert.Equal(clientSaveRequest.LastName, Client.LastName);
            Assert.Equal(clientSaveRequest.BirthDate, Client.BirthDate);
            Assert.Equal(clientSaveRequest.DocumentNumber, Client.DocumentNumber);
        }

        [Fact]
        public void Client_To_ClientUpdateRequest()
        {
            var clientUpdateRequest = Client.MapTo<Client, ClientUpdateRequest>();

            Assert.Equal(clientUpdateRequest.Id, Client.Id);
            Assert.Equal(clientUpdateRequest.Name, Client.Name);
            Assert.Equal(clientUpdateRequest.LastName, Client.LastName);
            Assert.Equal(clientUpdateRequest.BirthDate, Client.BirthDate);
            Assert.Equal(clientUpdateRequest.DocumentNumber, Client.DocumentNumber);
        }

        [Fact]
        public void Client_To_ClientResponse()
        {
            var clientResponse = Client.MapTo<Client, ClientResponse>();

            Assert.Equal(clientResponse.Id, Client.Id);
            Assert.Equal(clientResponse.Name, Client.Name);
            Assert.Equal(clientResponse.LastName, Client.LastName);
            Assert.Equal(clientResponse.BirthDate, Client.BirthDate);
            Assert.Equal(clientResponse.DocumentNumber, Client.DocumentNumber);
        }
    }
}
