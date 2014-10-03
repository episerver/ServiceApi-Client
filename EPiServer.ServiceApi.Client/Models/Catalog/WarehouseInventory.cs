using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class WarehouseInventory
    {
        public string CatalogEntryCode { get; set; }
        public Guid ApplicationId { get; set; }
        public string WarehouseCode { get; set; }
        public ResourceLink WarehouseLink { get; set; }
        public decimal InStockQuantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal ReorderMinQuantity { get; set; }
        public decimal PreorderQuantity { get; set; }
        public decimal BackorderQuantity { get; set; }
        public bool AllowBackorder { get; set; }
        public bool AllowPreorder { get; set; }
        public string InventoryStatus { get; set; }
        public DateTime? PreorderAvailabilityDate { get; set; }
        public DateTime? BackorderAvailabilityDate { get; set; }
    }
}
