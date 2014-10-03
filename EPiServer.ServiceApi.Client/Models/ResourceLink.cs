using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace EPiServer.Integration.Client.Models
{
    [Serializable]
    public class ResourceLink
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Href { get; set; }
    }	
}
