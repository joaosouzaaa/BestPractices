﻿namespace BestPractices.ApplicationService.DTO_s.Request.Client
{
    public class ClientSaveRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
    }
}
