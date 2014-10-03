using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class MetaFieldData
    {
        public string Language { get; set; }
        public string Value { get; set; }
    }
}
