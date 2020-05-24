using Flunt.Validations;
using Payment.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.ValuesObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, 
            string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
           .Requires()
           .HasMinLen(Street,3, "Adress.Street", "A rua deve conter pelo menos 3 caracteres")
           );
        }

        public string  Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
