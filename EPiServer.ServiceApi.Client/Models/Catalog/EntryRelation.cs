using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class EntryRelation
    {
        public int SortOrder { get; set; }
        public decimal Quantity { get; set; }
        public string RelationType { get; set; }
        public string GroupName { get; set; }
        public string ParentEntryCode { get; set; }
        public string ChildEntryCode { get; set; }
    }
}
