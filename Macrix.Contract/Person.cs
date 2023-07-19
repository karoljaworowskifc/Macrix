using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace Macrix.Contract
{
    public class Person
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string StreetName { get; set; }
        public required string HouseNumber { get; set; }
        public string? Apartment { get; set; }
        public required string PostalCode { get; set; }
        public required string Town { get; set; }
        public required string PhoneNumber { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                age = (DateOfBirth.Date > today.AddYears(-age)) ? age - 1 : age;
                return age;
            }
        }

        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Person(Guid id)
        {
            Id = id;
        }
    }
}