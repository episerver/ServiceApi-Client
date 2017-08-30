namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>
    ///     Represents a line item in the system, the actual item that is bought.
    /// </summary>
    public class LineItem
    {
        /// <summary>Gets the identity of the line item.</summary>
        public int LineItemId { get; set; }

        /// <summary>
        /// Gets the code of the variation content the line item represent. This property works as the connection between the line item and the variation content.
        /// </summary>
        public string Code { get; set; }

        /// <summary>Gets or sets the display name.</summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets the price for one item that this line item represent. This property don't take any discounts in consideration.
        /// </summary>
        public decimal PlacedPrice { get; set; }

        /// <summary>
        /// Gets the extended price for the lineitem. Includes order-level discount amount (which is spread over all line items in the shipment) and the line item discount amount.
        /// </summary>
        public decimal ExtendedPrice { get; set; }

        /// <summary>
        /// Gets the line item discounted price. Only calculates the price with the "line item discount amount," that is, the discount for a specific item.
        /// </summary>
        public decimal DiscountedPrice { get; set; }

        /// <summary>
        /// Gets or sets the number of items this line item contains
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>Gets or sets the returned in stock quantity.</summary>
        public decimal ReturnQuantity { get; set; }

        /// <summary>
        /// Gets or sets the inventory tracking status on whether to check inventory.
        /// </summary>
        public string InventoryTrackingStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has allocated inventory for the <see cref="P:EPiServer.Commerce.Order.ILineItem.Quantity" />.
        /// </summary>
        public bool IsInventoryAllocated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the line item is a gift item.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the line item is a gift item; otherwise, <c>false</c>.
        /// </value>
        public bool IsGift { get; set; }
    }
}