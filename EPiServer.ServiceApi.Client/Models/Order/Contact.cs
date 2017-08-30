using System;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>
    /// Contact model.
    /// </summary>
    [Serializable]
    public class Contact
    {
        /// <summary>
        /// Contact ID (GUID).
        /// </summary>
        public Guid? PrimaryKeyId { get; set; }

        /// <summary>
        /// Contacts addresses.
        /// </summary>
        public Address[] Addresses { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Registration source.
        /// </summary>
        public string RegistrationSource { get; set; }
    }
}