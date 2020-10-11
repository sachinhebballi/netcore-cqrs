using System;

namespace Api.Models.Domain
{
    public partial class Address
    {
        public Address()
        {

        }

        public int AddressId { get; set; }

        public string UnitNumber { get; set; }

        public string StreetNumber { get; set; }

        public string StreetName { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public int Postcode { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
