using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class MetaFieldProperty
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<MetaFieldData> Data { get; set; }
    }
}
