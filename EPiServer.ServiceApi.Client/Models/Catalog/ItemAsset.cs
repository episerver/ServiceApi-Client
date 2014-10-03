using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class ItemAsset
    {
        public string CatalogNodeCode { get; set; }
        public string CatalogEntryCode { get; set; }
        public string AssetKey { get; set; }
        public string AssetType { get; set; }
        public string GroupName { get; set; }
        public int SortOrder { get; set; }
    }
}
