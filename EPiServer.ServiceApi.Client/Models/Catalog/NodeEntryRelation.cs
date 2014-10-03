using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class NodeEntryRelation
    {
        public int SortOrder { get; set; }
        public string NodeCode { get; set; }
        public string EntryCode { get; set; }
    }
}
