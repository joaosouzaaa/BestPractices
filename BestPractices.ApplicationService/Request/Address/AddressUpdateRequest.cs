﻿namespace BestPractices.ApplicationService.Request.Address
{
    public class AddressUpdateRequest
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public string? Complement { get; set; }
    }
}
