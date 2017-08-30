using System;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>
    /// Order address.
    /// </summary>
    [Serializable]
    public class OrderAddress
    {
        /// <summary>Gets the order group address id.</summary>
        /// <value>The order group address id.</value>
        public int OrderGroupAddressId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The name of the first.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets last name.</summary>
        /// <value>The name of the last.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the organization.</summary>
        /// <value>The organization.</value>
        public string Organization { get; set; }

        /// <summary>Gets or sets the line1.</summary>
        /// <value>The line1.</value>
        public string Line1 { get; set; }

        /// <summary>Gets or sets the line2.</summary>
        /// <value>The line2.</value>
        public string Line2 { get; set; }

        /// <summary>Gets or sets the city.</summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>Gets or sets the state.</summary>
        /// <value>The state.</value>
        public string State { get; set; }

        /// <summary>Gets or sets the country code.</summary>
        /// <value>The country code.</value>
        public string CountryCode { get; set; }

        /// <summary>Gets or sets the name of the country.</summary>
        /// <value>The name of the country.</value>
        public string CountryName { get; set; }

        /// <summary>Gets or sets the postal code.</summary>
        /// <value>The postal code.</value>
        public string PostalCode { get; set; }

        /// <summary>Gets or sets the region code.</summary>
        /// <value>The region code.</value>
        public string RegionCode { get; set; }

        /// <summary>Gets or sets the name of the region.</summary>
        /// <value>The name of the region.</value>
        public string RegionName { get; set; }

        /// <summary>Gets or sets the daytime phone number.</summary>
        /// <value>The daytime phone number.</value>
        public string DaytimePhoneNumber { get; set; }

        /// <summary>Gets or sets the evening phone number.</summary>
        /// <value>The evening phone number.</value>
        public string EveningPhoneNumber { get; set; }

        /// <summary>Gets or sets the fax number.</summary>
        /// <value>The fax number.</value>
        public string FaxNumber { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }
    }
}