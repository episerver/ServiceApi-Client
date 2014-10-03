using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class Entry
    {
        public Entry()
        {
            SeoInformation = new List<SeoInfo>();
            Assets = new List<ResourceLink>();
            Associations = new List<ResourceLink>();
            MetaFields = new List<MetaFieldProperty>();
            WarehouseInventories = new List<ResourceLink>();
            Prices = new List<ResourceLink>();
            ChildCatalogEntries = new List<ResourceLink>();
            Nodes = new List<ResourceLink>();
            ParentCatalogEntry = new ResourceLink();
            Variation = null;
        }

        public string Code { get; set; }
        public Guid? ApplicationId { get; set; }
        public string Name { get; set; }
        public ResourceLink ParentCatalogEntry { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string MetaClass { get; set; }
        public string Catalog { get; set; }
        public List<MetaFieldProperty> MetaFields { get; set; }
        public List<SeoInfo> SeoInformation { get; set; }
        public List<ResourceLink> Prices { get; set; }
        public string EntryType { get; set; }
        public List<ResourceLink> ChildCatalogEntries { get; set; }
        public string InventoryStatus { get; set; }
        public List<ResourceLink> WarehouseInventories { get; set; }
        public List<ResourceLink> Associations { get; set; }
        public List<ResourceLink> Assets { get; set; }
        public List<ResourceLink> Nodes { get; set; }
        public VariationProperties Variation { get; set; }
    }
}
