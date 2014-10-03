using System.Collections.Generic;
using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace EPiServer.Integration.Client.Tests.Cruds
{
    public class CatalogEntryTest : BaseTest
    {
        private readonly string _entryOutputPath;

        public CatalogEntryTest()
        {
            _entryOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Entry\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Catalog Entry examples written to directory {0}.\n", _entryOutputPath);
            message.AppendLine("Running get all entries.....");
            message.AppendLine(GetAllEntries());
            message.AppendLine("Running get entry.....");
            message.AppendLine(GetEntry());
            message.AppendLine("Running post entry.....");
            message.AppendLine(PostEntry());
            message.AppendLine("Running put entry.....");
            message.AppendLine(PutEntry());
            message.AppendLine("Running delete entry.....");
            message.AppendLine(DeleteEntry());
            return message.ToString();
        }

        private string GetAllEntries()
        {
            try
            {
                var result = Get("/episerverapi/commerce/entries").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/entries").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "GetAllXml.xml"), result);
                return "Get all entries complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetEntry()
        {
            try
            {
                var result = Get("episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "GetXml.xml"), result);
                return "Get entry complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostEntry()
        {
            try
            {
                var model = new Entry()
                {
                    Code = "WhoKnewBaby",
                    Catalog = "Departmental Catalog",
                    EndDate = DateTime.UtcNow.AddDays(100),
                    EntryType = "Product",
                    InventoryStatus = "Enabled",
                    IsActive = true,
                    MetaClass = "Fashion_Product_Class",
                    Name = "Test",
                    StartDate = DateTime.UtcNow,

                    MetaFields = new List<MetaFieldProperty>()
                    {
                        new MetaFieldProperty()
                        {
                            Name = "DisplayName",
                            Type = "ShortString",
                            Data = new List<MetaFieldData>()
                            {
                                new MetaFieldData()
                                {
                                    Language="en",
                                    Value = "DisplayName"
                                }
                            }
                        }
                    },
                    SeoInformation = new List<SeoInfo>()
                    {
                        new SeoInfo()
                        {
                            Description = "description",
                            Keywords="",
                            LanguageCode = "en",
                            Title = "title",
                            Uri = "whoknew",
                            UriSegment = "whoknew"
                        }
                    }
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Entry), model);
                var result = Post("/episerverapi/commerce/entries", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/entries", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "PostXml.xml"), result);
                return "Post entry complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutEntry()
        {
            try
            {
                var model = new Entry()
                {
                    Code = "Dresses-Cocktail-Silk",
                    Catalog = "Departmental Catalog",
                    EndDate = DateTime.UtcNow.AddDays(100),
                    EntryType = "Product",
                    InventoryStatus = "Enabled",
                    IsActive = true,
                    MetaClass = "Fashion_Product_Class",
                    Name = "Test",
                    StartDate = DateTime.UtcNow,

                    MetaFields = new List<MetaFieldProperty>()
                    {
                        new MetaFieldProperty()
                        {
                            Name = "DisplayName",
                            Type = "ShortString",
                            Data = new List<MetaFieldData>()
                            {
                                new MetaFieldData()
                                {
                                    Language="en",
                                    Value = "Dresses-Cocktail-Silk"
                                }
                            }
                        }
                    },
                    SeoInformation = new List<SeoInfo>()
                    {
                        new SeoInfo()
                        {
                            Description = "description",
                            Keywords="",
                            LanguageCode = "en",
                            Title = "title",
                            Uri = "Dresses-Cocktail-Silk",
                            UriSegment = "Dresses-Cocktail-Silk"
                        }
                    }
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Entry), model);
                var result = Put("episerverapi/commerce/entries/Dresses-Cocktail-Silk", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/entries/Dresses-Cocktail-Silk", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "PutXml.xml"), result);
                return "Put entry complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteEntry()
        {
            try
            {
                var result = Delete("episerverapi/commerce/entries/WhoKnewBaby").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/entries/WhoKnewBabyies").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_entryOutputPath, "DeleteXml.xml"), result);
                return "Delete entry complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
