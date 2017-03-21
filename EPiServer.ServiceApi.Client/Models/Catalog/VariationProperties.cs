using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class VariationProperties
    {
        public decimal MinQuantity { get; set; }
        public decimal MaxQuantity { get; set; }
        public double Weight { get; set; }
        public String TaxCategory { get; set; }
    }
}
