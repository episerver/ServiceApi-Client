using System;
using System.Collections.Generic;
using EPiServer.Integration.Client.Models.Order;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>Contains the order information.</summary>
    [Serializable]
    public class OrderForm : IHaveProperties
    {
        /// <summary>
        /// Initializes new instance of the OrderForm class.
        /// </summary>
        public OrderForm()
        {
            Shipments = new Shipment[0];
            LineItems = new LineItem[0];
            Discounts = new Discount[0];
            Properties = new List<PropertyItem>();
        }

        /// <summary>Gets the shipments.</summary>
        /// <value>The shipments.</value>
        public Shipment[] Shipments { get; set; }

        /// <summary>Gets the line items.</summary>
        /// <value>The line items.</value>
        public LineItem[] LineItems { get; set; }

        /// <summary>Gets the discounts.</summary>
        /// <value>The discounts.</value>
        public Discount[] Discounts { get; set; }

        /// <summary>Gets or sets the rma comment.</summary>
        /// <value>The rma comment.</value>
        public string ReturnComment { get; set; }

        /// <summary>
        /// Gets or sets the Return Type. For example can be "Refund", "Exchange" etc.
        /// </summary>
        /// <value>The type of the Rma request.</value>
        public string ReturnType { get; set; }

        /// <summary>
        /// Gets or sets the RMA auth code. Using for procedure RMA authentifications.
        /// </summary>
        /// <value>The rma auth code.</value>
        public string ReturnAuthCode { get; set; }

        /// <summary>Gets the order form id.</summary>
        /// <value>The order form id.</value>
        public int OrderFormId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the billing address id. The id is the name of the address in OrderAddress collection.
        /// </summary>
        /// <value>The billing address id.</value>
        public string BillingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the shipping total, does not includes discounts that have been applied to each shipment.
        /// </summary>
        /// <value>The shipping total.</value>
        public decimal ShippingTotal { get; set; }

        /// <summary>Gets or sets the handling total.</summary>
        /// <value>The handling total.</value>
        public decimal HandlingTotal { get; set; }

        /// <summary>Gets or sets the tax total.</summary>
        /// <value>The tax total.</value>
        public decimal TaxTotal { get; set; }

        /// <summary>
        /// Gets or sets the discount amount. This amount includes shipping discounts as well.
        /// </summary>
        /// <value>The discount amount.</value>
        public decimal DiscountAmount { get; set; }

        /// <summary>Gets or sets the sub total.</summary>
        /// <value>The sub total.</value>
        public decimal SubTotal { get; set; }

        /// <summary>Gets or sets the total.</summary>
        /// <value>The total.</value>
        public decimal Total { get; set; }

        /// <summary>Gets or sets the status.</summary>
        /// <value>The status.</value>
        public string Status { get; set; }

        /// <summary>Gets or sets the RMA number.</summary>
        /// <value>The RMA number.</value>
        public string RmaNumber { get; set; }

        /// <summary>Gets or sets the authorized payment total.</summary>
        /// <value>The authorized payment total.</value>
        public decimal AuthorizedPaymentTotal { get; set; }

        /// <summary>Gets or sets the captured payment total.</summary>
        /// <value>The captured payment total.</value>
        public decimal CapturedPaymentTotal { get; set; }

        /// <summary>
        /// Gets the list of key value pairs for dealing with custom properties.
        /// </summary>
        public List<PropertyItem> Properties { get; set; }
    }
}