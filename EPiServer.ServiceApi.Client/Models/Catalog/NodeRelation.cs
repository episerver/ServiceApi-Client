using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class NodeRelation
    {
        public int SortOrder { get; set; }
        public string ParentNodeCode { get; set; }
        public string ChildNodeCode { get; set; }
    }
}
