using BestPractices.ApplicationService.Request.Address;
using BestPractices.ApplicationService.Response.Address;
using BestPractices.Domain.Entities;

namespace Builders
{
    public class AddressBuilder
    {
        private string _city = "curitiba";
        private string _complement = "sobrado 12";
        private string _number = "1555";
        private string _state = "pr";
        private string _street = "rua das ruas";
        private string _zipCode = "76828560";

        public static AddressBuilder NewObject()
        {
            return new AddressBuilder();
        }

        public Address DomainBuild()
        {
            return new Address
            {
                City = _city,
                Complement = _complement,
                Id = 1,
                Number = _number,
                State = _state,
                Street = _street,
                ZipCode = _zipCode
            };
        }

        public AddressSaveRequest SaveRequestBuild()
        {
            return new AddressSaveRequest
            {
                City = _city,
                Complement = _complement,
                Number = _number,
                State = _state,
                Street = _street,
                ZipCode = _zipCode
            };
        }

        public AddressUpdateRequest UpdateRequestBuild()
        {
            return new AddressUpdateRequest
            {
                City = _city,
                Complement = _complement,
                Id = 1,
                Number = _number,
                State = _state,
                Street = _street,
                ZipCode = _zipCode
            };
        }

        public AddressResponse ResponseBuild()
        {
            return new AddressResponse
            {
                City = _city,
                Complement = _complement,
                Id = 1,
                Number = _number,
                State = _state,
                Street = _street,
                ZipCode = _zipCode
            };
        }

        public AddressBuilder WithZipCode(string zipCode)
        {
            _zipCode = zipCode;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder WithStreet(string street)
        {
            _street = street;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            _state = state;
            return this;
        }

        public AddressBuilder WithNumber(string number)
        {
            _number = number;
            return this;
        }

        public AddressBuilder WithComplement(string complement)
        {
            _complement = complement;
            return this;
        }
    }
}
