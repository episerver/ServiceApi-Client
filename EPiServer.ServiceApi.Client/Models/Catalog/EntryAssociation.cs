using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class EntryAssociation
    {
        public int SortOrder { get; set; }
        public string Type { get; set; }
        public string CatalogEntryCode { get; set; }
        public ResourceLink CatalogEntry { get; set; }
    }
}
