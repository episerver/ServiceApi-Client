using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class SeoInfo
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public string UriSegment { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string LanguageCode { get; set; }
    }
}
