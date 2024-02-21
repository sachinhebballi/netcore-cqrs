using System;

namespace Api.Models.Domain
{
    public partial class Employee : DomainBase
    {
        public int EmployeeId { get; set; }

        public int AddressId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
        
        public DateTime HireDate { get; set; }

        public virtual Address Address { get; set; }
    }
}
