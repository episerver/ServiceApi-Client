using System;
using System.Collections.Generic;
using EPiServer.Integration.Client.Models.Order;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>
    /// Order group model.
    /// </summary>
    [Serializable]
    public class OrderGroup : IHaveProperties
    {
        /// <summary>
        /// Initializes new instance of the OrderGroup class.
        /// </summary>
        public OrderGroup()
        {
            OrderAddresses = new OrderAddress[0];
            OrderForms = new OrderForm[0];
            OrderNotes = new OrderNote[0];
            Properties = new List<PropertyItem>();
        }

        /// <summary>
        /// Address ID.
        /// </summary>
        public string AddressId { get; set; }

        /// <summary>
        /// Affiliate ID (GUID)
        /// </summary>
        public Guid AffiliateId { get; set; }

        /// <summary>
        /// Billing currency.
        /// </summary>
        public string BillingCurrency { get; set; }

        /// <summary>
        /// Customer ID (GUID).
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Handling total.
        /// </summary>
        public decimal HandlingTotal { get; set; }

        /// <summary>
        /// Instance ID (GUID).
        /// </summary>
        public Guid InstanceId { get; set; }

        /// <summary>
        /// Market ID.
        /// </summary>
        public string MarketId { get; set; }

        /// <summary>
        /// Order name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Array of addresses.
        /// </summary>
        public OrderAddress[] OrderAddresses { get; set; }

        /// <summary>
        /// Array of order forms.
        /// </summary>
        public OrderForm[] OrderForms { get; set; }

        /// <summary>
        /// Order group ID.
        /// </summary>
        public int OrderGroupId { get; set; }

        /// <summary>
        /// Array of order notes.
        /// </summary>
        public OrderNote[] OrderNotes { get; set; }

        /// <summary>
        /// Owner name.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Owner's organization name.
        /// </summary>
        public string OwnerOrg { get; set; }

        /// <summary>
        /// Provider ID.
        /// </summary>
        public string ProviderId { get; set; }

        /// <summary>
        /// Shipping total.
        /// </summary>
        public decimal ShippingTotal { get; set; }

        /// <summary>
        /// Status.
        /// Valid values:
        /// - AwaitingExchange
        /// - Cancelled
        /// - Completed
        /// - InProgress
        /// - OnHold
        /// - PartiallyShipped
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Sub-total.
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Tax total.
        /// </summary>
        public decimal TaxTotal { get; set; }

        /// <summary>
        /// Total.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Modified date.
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Created date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets the list of key value pairs for dealing with custom properties.
        /// </summary>
        public List<PropertyItem> Properties { get; set; }
    }
}