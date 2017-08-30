using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;

namespace EPiServer.Integration.Client.Tests.Catalog.Cruds
{
    public class CatalogTest : BaseTest
    {
        private readonly string _catalogOutputPath;

        public CatalogTest()
        {
            _catalogOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Catalog\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Catalog examples written to directory {0}.\n", _catalogOutputPath);
            message.AppendLine("Running get all catalogs.....");
            message.AppendLine(GetAllCatalogs());
            message.AppendLine("Running get catalog.....");
            message.AppendLine(GetCatalog());
            message.AppendLine("Running post catalog.....");
            message.AppendLine(PostCatalog());
            message.AppendLine("Running put catalog.....");
            message.AppendLine(PutCatalog());
            message.AppendLine("Running delete catalog.....");
            message.AppendLine(DeleteCatalog());
            return message.ToString();
        }

        private string GetAllCatalogs()
        {
            try
            {
                var result = Get("/episerverapi/commerce/catalogs").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/catalogs").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "GetAllXml.xml"), result);
                return "Get all catalogs complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetCatalog()
        {
            try
            {
                var result = Get("episerverapi/commerce/catalogs/Departmental Catalog").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/catalogs/Departmental Catalog").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "GetXml.xml"), result);
                return "Get catalog complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostCatalog()
        {
            try
            {
                var model = new Models.Catalog.Catalog()
                {
                    DefaultCurrency = "usd",
                    DefaultLanguage = "en",
                    EndDate = DateTime.UtcNow.AddYears(1),
                    IsActive = true,
                    IsPrimary = true,
                    Languages = new List<CatalogLanguage>()
                    {
                        new CatalogLanguage()
                        {
                            Catalog = "Test Post",
                            LanguageCode = "en",
                            UriSegment = "Test Post"
                        }
                    },
                    Name = "Test Post",
                    StartDate = DateTime.UtcNow,
                    WeightBase = "lbs"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Models.Catalog.Catalog), model);
                var result = Post("/episerverapi/commerce/catalogs", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/catalogs", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "PostXml.xml"), result);
                return "Post catalog complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutCatalog()
        {
            try
            {
                var model = new Models.Catalog.Catalog()
                {
                    DefaultCurrency = "usd",
                    DefaultLanguage = "en",
                    EndDate = DateTime.UtcNow.AddYears(1),
                    IsActive = true,
                    IsPrimary = true,
                    Languages = new List<CatalogLanguage>()
                    {
                        new CatalogLanguage()
                        {
                            Catalog = "Test Post",
                            LanguageCode = "en",
                            UriSegment = "Test Post"
                        }
                    },
                    Name = "Test Post",
                    StartDate = DateTime.UtcNow,
                    WeightBase = "lbs"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Models.Catalog.Catalog), model);
                var result = Put("episerverapi/commerce/catalogs/Test Post", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/catalogs/Test Post", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "PutXml.xml"), result);
                return "Put catalog complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteCatalog()
        {
            try
            {
                var result = Delete("episerverapi/commerce/catalogs/Test Post").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/catalogs/Test Posts").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_catalogOutputPath, "DeleteXml.xml"), result);
                return "Delete catalog complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
