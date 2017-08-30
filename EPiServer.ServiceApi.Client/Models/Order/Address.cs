using System;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>
    /// Address model.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Address ID (GUID).
        /// </summary>
        public Guid? AddressId { get; set; }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? Modified { get; set; }

        /// <summary>
        /// Address name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Postal code (Zip code).
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Address line 1.
        /// </summary>
        public string Line1 { get; set; }

        /// <summary>
        /// Address line 2.
        /// </summary>
        public string Line2 { get; set; }

        /// <summary>
        /// Region name.
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// Region code.
        /// </summary>
        public string RegionCode { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Check if this is default shipping address.
        /// </summary>
        public bool ShippingDefault { get; set; }

        /// <summary>
        /// Check if this is default billing address.
        /// </summary>
        public bool BillingDefault { get; set; }

        /// <summary>
        /// Daytime phone number.
        /// </summary>
        public string DaytimePhoneNumber { get; set; }

        /// <summary>
        /// Evening phone number.
        /// </summary>
        public string EveningPhoneNumber { get; set; }

        /// <summary>
        /// Organization name.
        /// </summary>
        public string Organization { get; set; }
    }
}