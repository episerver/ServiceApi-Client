using EPiServer.Integration.Client.Models.Order;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>Purchase Order is the actual recorded sale.</summary>
    public class PurchaseOrder : OrderGroup
    {
        /// <summary>
        /// An order number used for tracking the order.
        /// </summary>
        public string OrderNumber { get; set; }
    }
}