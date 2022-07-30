using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Request.Address;
using BestPractices.ApplicationService.Response.Address;
using BestPractices.Domain.Entities;
using ExpectedObjects;

namespace UnitTests.AutoMapperTests
{
    public class AddressAutoMapperTests
    {
        public Address Address = AddressBuilder.NewObject().DomainBuild();

        public AddressAutoMapperTests()
        {
            AutoMapperHandler.Inicialize();
        }

        [Fact]
        public void Address_To_AddressSaveRequest() =>
            Address.MapTo<Address, AddressSaveRequest>().ToExpectedObject().ShouldMatch(Address);

        [Fact]
        public void Address_To_AddressUpdateRequest() =>
            Address.MapTo<Address, AddressUpdateRequest>().ToExpectedObject().ShouldMatch(Address);

        [Fact]
        public void Address_To_AddressResponse() =>
            Address.MapTo<Address, AddressResponse>().ToExpectedObject().ShouldMatch(Address);
    }
}
