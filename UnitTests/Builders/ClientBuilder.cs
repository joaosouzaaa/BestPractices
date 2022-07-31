using BestPractices.ApplicationService.Request.Client;
using BestPractices.ApplicationService.Response.Client;
using BestPractices.Domain.Entities;

namespace UnitTests.Builders
{
    public class ClientBuilder
    {
        private DateTime _birthDate = new DateTime(1999, 01, 02);
        private string _documentNumber = "91217183000";
        private string _name = "joao";
        private string _lastName = "antonio";

        public static ClientBuilder NewObject()
        {
            return new ClientBuilder();
        }

        public Client DomainBuild()
        {
            return new Client
            {
                BirthDate = _birthDate,
                DocumentNumber = _documentNumber,
                Name = _name,
                Id = 1,
                LastName = _lastName,
            };
        }

        public ClientUpdateRequest UpdateRequestBuild()
        {
            return new ClientUpdateRequest
            {
                BirthDate = _birthDate,
                DocumentNumber = _documentNumber,
                Id = 1,
                LastName = _lastName,
                Name = _name
            };
        }

        public ClientResponse ResponseBuild()
        {
            return new ClientResponse
            {
                BirthDate = _birthDate,
                DocumentNumber = _documentNumber,
                Id = 1,
                LastName = _lastName,
                Name = _name
            };
        }

        public ClientBuilder WithBirthDate(DateTime birthDate)
        {
            _birthDate = birthDate;
            return this;
        }

        public ClientBuilder WithDocumentNumber(string documentNumber)
        {
            _documentNumber = documentNumber;
            return this;
        }

        public ClientBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ClientBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }
    }
}
