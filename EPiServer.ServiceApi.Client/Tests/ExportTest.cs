using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EPiServer.Integration.Client.Client;
using System.IO;
using EPiServer.Integration.Client.Models;
using Newtonsoft.Json;

namespace EPiServer.Integration.Client.Tests
{
    public class ExportTest : BaseTest
    {
        private readonly string _exportOutputPath;

        public ExportTest()
        {
            _exportOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Export\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendLine(CatalogExportTest());
            message.AppendLine(SiteExportTest());
            return message.ToString();
        }

        private String CatalogExportTest()
        {
            var catalogName = ConfigurationManager.AppSettings["CatalogName"];
            if (String.IsNullOrEmpty(catalogName))
            {
                return "Catalog name is not set in appsettings.  Please set for export test to work.";
            }
            try
            {
                var catalog = Get(String.Format("/episerverapi/commerce/export/catalog/{0}", catalogName), HttpCompletionOption.ResponseHeadersRead).Result;
                if (catalog.StatusCode == HttpStatusCode.OK)
                {
                    using (var fileStream = File.Create(Path.Combine(_exportOutputPath, String.Format("{0}.zip", catalogName))))
                    {
                        using (var httpStream = catalog.Content.ReadAsStreamAsync().Result)
                        {
                            httpStream.CopyTo(fileStream);
                            fileStream.Flush();
                        }
                    }
                    return String.Format("Catalog export file was created at {0}", Path.Combine(_exportOutputPath, String.Format("{0}.zip", catalogName)));
                }
               
                return catalog.Content.ReadAsStringAsync().Result;
               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            

        }

        private String SiteExportTest()
        {
            var siteName = ConfigurationManager.AppSettings["SiteName"];
            if (String.IsNullOrEmpty(siteName))
            {
                return "Catalog name is not set in appsettings.  Please set for export test to work.";
            }
            try
            {
                var site = Get(String.Format("/episerverapi/commerce/export/site/{0}", siteName), HttpCompletionOption.ResponseHeadersRead).Result;
                if (site.StatusCode == HttpStatusCode.OK)
                {
                    using (var fileStream = File.Create(Path.Combine(_exportOutputPath, String.Format("{0}.episerverdata", siteName))))
                    {
                        using (var httpStream = site.Content.ReadAsStreamAsync().Result)
                        {
                            httpStream.CopyTo(fileStream);
                            fileStream.Flush();
                        }
                    }
                    return String.Format("Site export file was created at {0}", Path.Combine(_exportOutputPath, String.Format("{0}.episerverdata", siteName)));
                }
                return site.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            

        }
    }
}
