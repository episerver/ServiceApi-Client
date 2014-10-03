using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class Catalog
    {
        public Guid ApplicationId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsPrimary { get; set; }
        public String Owner { get; set; }
        public int SortOrder { get; set; }
        public String Name { get; set; }
        public String DefaultCurrency { get; set; }
        public String DefaultLanguage { get; set; }
        public String WeightBase { get; set; }
        public List<CatalogLanguage> Languages { get; set; }
        public List<ResourceLink> Nodes { get; set; }
        public List<ResourceLink> Entries { get; set; }
    }
}
