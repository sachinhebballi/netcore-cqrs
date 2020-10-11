using System;

namespace Api.Models.Domain
{
    public partial class Employee
    {
        public Employee()
        {

        }

        public int EmployeeId { get; set; }

        public int AddressId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Address Address { get; set; }

    }
}
