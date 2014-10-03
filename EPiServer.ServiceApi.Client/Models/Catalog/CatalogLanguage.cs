using System;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class CatalogLanguage
    {
        public String LanguageCode { get; set; }
        public String Catalog { get; set; }
        public String UriSegment { get; set; }
    }
}
