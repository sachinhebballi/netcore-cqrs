using Api.Models.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace netcore_cqrs.api.Examples
{
    /// <summary>
    /// Swagger document example for employee model
    /// </summary>
    public class EmployeeExample : IExamplesProvider<Employee>
    {
        /// <summary>
        /// Example object for employee
        /// </summary>
        /// <returns></returns>
        public Employee GetExamples()
        {
            return new Employee
            {
                EmployeeId = 1,
                FirstName = "Sachin",
                LastName = "Hebballi",
                Age = 30,
                Address = new Address
                {
                    AddressId = 1,
                    UnitNumber = "1",
                    StreetNumber = "10",
                    StreetName = "Collins Street",
                    Suburb = "Melbourne",
                    City = "Melbourne",
                    Postcode = 3000
                }
            };
        }
    }

    /// <summary>
    /// Swagger document example for employee model
    /// </summary>
    public class EmployeesExample : IExamplesProvider<IEnumerable<Employee>>
    {
        /// <summary>
        /// Example object for employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetExamples()
        {
            return new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Sachin",
                    LastName = "Hebballi",
                    Age = 30,
                    Address = new Address
                    {
                        AddressId = 1,
                        UnitNumber = "1",
                        StreetNumber = "10",
                        StreetName = "Collins Street",
                        Suburb = "Melbourne",
                        City = "Melbourne",
                        Postcode = 3000
                    }
                }
            };
        }
    }
}
