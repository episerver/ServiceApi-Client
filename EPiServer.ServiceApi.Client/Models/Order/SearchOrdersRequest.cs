using System;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>
    /// Order search parameter model.
    /// </summary>
    public class SearchOrdersRequest
    {
        /// <summary>
        /// Order shipment status to filter.
        /// Valid values:
        /// - AwaitingInventory
        /// - Cancelled
        /// - InventoryAssigned
        /// - OnHold
        /// - Packing
        /// - Released
        /// - Shipped
        /// </summary>
        public string OrderShipmentStatus { get; set; }

        /// <summary>
        /// Shipping method ID (GUID) to filter.
        /// </summary>
        public Guid? ShippingMethodId { get; set; }

        /// <summary>
        /// Modified from date to filter.
        /// </summary>
        public DateTime? ModifiedFrom { get; set; }

        /// <summary>
        /// Array of statuses to filter.
        /// Valid values:
        /// - AwaitingExchange
        /// - Cancelled
        /// - Completed
        /// - InProgress
        /// - OnHold
        /// - PartiallyShipped
        /// </summary>
        public string[] Status { get; set; }
    }
}