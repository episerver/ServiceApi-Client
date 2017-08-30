using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;

namespace EPiServer.Integration.Client.Tests.Catalog.Cruds
{
    public class AssociationTest : BaseTest
    {
        private readonly string _associationOutputPath;

        public AssociationTest()
        {
            _associationOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Association\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Assocation examples written to directory {0}.\n", _associationOutputPath);
            message.AppendLine("Running get all entry associations.....");
            message.AppendLine(GetAllEntryAssociations());
            message.AppendLine("Running get entry association.....");
            message.AppendLine(GetEntryAssociations());
            message.AppendLine("Running post entry association.....");
            message.AppendLine(PostEntryAssociation());
            message.AppendLine("Running put entry association.....");
            message.AppendLine(PutEntryAssociation());
            message.AppendLine("Running delete entry association.....");
            message.AppendLine(DeleteEntryAssociation());
            return message.ToString();
        }

        private string GetAllEntryAssociations()
        {
            try
            {
                var result = Get("/episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "GetAllXml.xml"), result);
                return "Get all entry associations complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetEntryAssociations()
        {
            try
            {
                var result = Get("episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations/UpSell").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations/UpSell").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "GetXml.xml"), result);
                return "Get entry association complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostEntryAssociation()
        {
            try
            {
                var model = new Association()
                {
                    CatalogEntryCode = "Movies-Kids-Jumanji-BluRay",
                    Description = "Description Created",
                    Name = "Test",
                    SortOrder = 1,
                    EntryAssociations = new List<EntryAssociation>()
                        {
                            new EntryAssociation()
                            {
                                CatalogEntryCode = "Movies-Kids-IceAge-BluRay",
                                SortOrder = 1,
                                Type = "Default"
                            }
                        }
                };
                
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Association), model);
                var result = Post("/episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "PostXml.xml"), result);
                return "Post entry association complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutEntryAssociation()
        {
            try
            {
                var model = new Association()
                {
                    CatalogEntryCode = "Movies-Kids-Jumanji-BluRay",
                    Description = "Description Created",
                    Name = "UpSell",
                    SortOrder = 1,
                    EntryAssociations = new List<EntryAssociation>()
                    {
                        new EntryAssociation()
                        {
                            CatalogEntryCode = "Movies-Kids-IceAge-BluRay",
                            SortOrder = 1,
                            Type = "Default"
                        }
                    }
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Association), model);
                var result = Put("episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations/UpSell", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations/UpSell", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "PutXml.xml"), result);
                return "Put entry association complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteEntryAssociation()
        {
            try
            {
                var result = Delete("episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations/UpSells").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/entries/Movies-Kids-Jumanji-BluRay/associations/UpSells").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_associationOutputPath, "DeleteXml.xml"), result);
                return "Delete entry association complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
