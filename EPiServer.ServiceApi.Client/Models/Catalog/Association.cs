using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class Association
    {
        public int SortOrder { get; set; }
        public string Name { get; set; }
        public string CatalogEntryCode { get; set; }
        public string Description { get; set; }
        public List<EntryAssociation> EntryAssociations { get; set; }
    }
}
