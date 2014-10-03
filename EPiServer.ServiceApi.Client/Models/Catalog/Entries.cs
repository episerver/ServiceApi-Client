using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPiServer.Integration.Client.Models.Catalog
{
    [Serializable]
    public class Entries
    {
        public Entries()
        {
            EntryResults = new List<Entry>();
            TotalCount = 0;
            TotalPages = 0;
        }

        public List<Entry> EntryResults { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
