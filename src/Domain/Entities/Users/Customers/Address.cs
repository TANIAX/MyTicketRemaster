﻿namespace MyTicketRemaster.Domain.Entities.Users.Customers
{
    public record Address
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Street { get; init; }

        [Required, MinLength(1), MaxLength(100)]
        public string City { get; init; }

        [Required, MinLength(1), MaxLength(100)]
        public string Country { get; init; }

        [Required, MinLength(1), MaxLength(100)]
        public string ZipCode { get; init; }

        private Address()
        {
            Street = City = Country = ZipCode = default!;
        }

        // TODO: Add validation and constraints
        public Address(string street, string city, string country, string zipcode)
            => (Street, City, Country, ZipCode) = (street, city, country, zipcode);

        public override string ToString()
            => $"{Street}, {ZipCode} {City}, {Country}";
    }
}
