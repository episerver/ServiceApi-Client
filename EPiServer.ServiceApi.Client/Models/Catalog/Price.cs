using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class Price
    {
        public Price()
        {
            PriceValueId = null;
            PriceCode = "";
        }

        public long? PriceValueId { get; set; }
        public string CatalogEntryCode { get; set; }
        public Guid ApplicationId { get; set; }
        public string MarketId { get; set; }
        public string PriceTypeId { get; set; }
        public string PriceCode { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidUntil { get; set; }
        public decimal MinQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string CurrencyCode { get; set; }
    }
}
