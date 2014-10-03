using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class Node
    {
        public Node()
        {
            SeoInformation = new List<SeoInfo>();
            Assets = new List<ResourceLink>();
            MetaFields = new List<MetaFieldProperty>();
            Children = new List<ResourceLink>();
            Entries = new List<ResourceLink>();
        }

        public string Code { get; set; }
        public string ParentNodeCode { get; set; }
        public Guid? ApplicationId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string MetaClass { get; set; }
        public string Catalog { get; set; }
        public int SortOrder { get; set; }
        public ResourceLink ParentNode { get; set; }
        public List<MetaFieldProperty> MetaFields { get; set; }
        public List<SeoInfo> SeoInformation { get; set; }
        public List<ResourceLink> Assets { get; set; }
        public List<ResourceLink> Children { get; set; }
        public List<ResourceLink> Entries { get; set; }
    }
}
