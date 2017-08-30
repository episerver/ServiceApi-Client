using System;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>Represents a note on an order.</summary>
    [Serializable]
    public class OrderNote
    {
        /// <summary> Gets the order note ID. </summary>
        public int? OrderNoteId { get; set; }

        /// <summary>Gets Created date.</summary>
        public DateTime Created { get; set; }

        /// <summary>Gets or sets note customer ID.</summary>
        public Guid CustomerId { get; set; }

        /// <summary>Gets or sets note details.</summary>
        public string Detail { get; set; }

        /// <summary>Gets or sets note title.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets note type.</summary>
        public string Type { get; set; }

        /// <summary>Gets or sets note related line item ID.</summary>
        public int? LineItemId { get; set; }
    }
}