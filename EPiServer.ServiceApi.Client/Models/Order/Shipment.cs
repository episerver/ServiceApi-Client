using System;
using System.Collections.Generic;
using EPiServer.Integration.Client.Models.Order;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>
    /// Shipment contains information about the particular shipment. Line Items will reference the shipment object they belong to.
    /// </summary>
    [Serializable]
    public class Shipment : IHaveProperties
    {
        /// <summary>
        /// Initializes new instance of the Shipment class.
        /// </summary>
        public Shipment()
        {
            Discounts = new Discount[0];
            LineItems = new LineItem[0];
            Properties = new List<PropertyItem>();
        }

        /// <summary>Gets the discounts.</summary>
        /// <value>The discounts.</value>
        public Discount[] Discounts { get; set; }

        /// <summary>Gets the shipment id.</summary>
        /// <value>The shipment id.</value>
        public int ShipmentId { get; set; }

        /// <summary>Gets or sets the shipping method id.</summary>
        /// <value>The shipping method id.</value>
        public Guid ShippingMethodId { get; set; }

        /// <summary>Gets or sets the name of the shipping method.</summary>
        /// <value>The name of the shipping method.</value>
        public string ShippingMethodName { get; set; }

        /// <summary>Gets or sets the shipment tax.</summary>
        /// <value>The shipment tax.</value>
        public decimal ShippingTax { get; set; }

        /// <summary>Gets or sets the shipping address name.</summary>
        /// <value>The shipping address id.</value>
        public string ShippingAddressId { get; set; }

        /// <summary>Gets or sets the shipment tracking number.</summary>
        /// <value>The shipment tracking number.</value>
        public string ShipmentTrackingNumber { get; set; }

        /// <summary>Gets or sets the shipping discount amount.</summary>
        /// <value>The shipping discount amount.</value>
        public decimal ShippingDiscountAmount { get; set; }

        /// <summary>Gets or sets the shipping sub total.</summary>
        /// <value>The shipping sub total.</value>
        public decimal ShippingSubTotal { get; set; }

        /// <summary>
        /// Gets the total shipping cost, including shipping discounts (if any) and shipping tax.
        /// </summary>
        /// <value>The shipping total.</value>
        public decimal ShippingTotal { get; set; }

        /// <summary>Gets or sets the status.</summary>
        /// <value>The status.</value>
        public string Status { get; set; }

        /// <summary>Gets or sets the previous status</summary>
        /// <value>The state of the prev.</value>
        public string PrevStatus { get; set; }

        /// <summary>Gets the pick list id.</summary>
        /// <value>The pick list id.</value>
        public int? PickListId { get; set; }

        /// <summary>Gets or sets the sub total.</summary>
        /// <value>The sub total.</value>
        public decimal SubTotal { get; set; }

        /// <summary>Gets or sets the warehouse code</summary>
        /// <value>The warehouse code.</value>
        public string WarehouseCode { get; set; }

        /// <summary>Gets the collection of line items</summary>
        /// <value>The line items.</value>
        public LineItem[] LineItems { get; set; }

        /// <summary>
        /// Gets the list of key value pairs for dealing with custom properties.
        /// </summary>
        public List<PropertyItem> Properties { get; set; }
    }
}