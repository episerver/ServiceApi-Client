using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace EPiServer.Integration.Client.Tests.Cruds
{
    public class EntryRelationTest : BaseTest
    {
        private readonly string _relationOutputPath;

        public EntryRelationTest()
        {
            _relationOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("EntryRelation\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Entry Relation examples written to directory {0}.\n", _relationOutputPath);
            message.AppendLine("Running get all entry relations.....");
            message.AppendLine(GetAllEntryRelations());
            message.AppendLine("Running get entry relation.....");
            message.AppendLine(GetEntryRelation());
            message.AppendLine("Running post entry relation.....");
            message.AppendLine(PostEntryRelation());
            message.AppendLine("Running put entry relation.....");
            message.AppendLine(PutEntryRelation());
            message.AppendLine("Running delete entry relation.....");
            message.AppendLine(DeleteEntryRelation());
            return message.ToString();
        }

        private string GetAllEntryRelations()
        {
            try
            {
                var result = Get("/episerverapi/commerce/entries/Jackets-Peacoats-Asymmetrical/entryrelations").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/entries/Jackets-Peacoats-Asymmetrical/entryrelations").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "GetAllXml.xml"), result);
                return "Get all entry relations complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetEntryRelation()
        {
            try
            {
                var result = Get("episerverapi/commerce/entries/Jackets-Peacoats-Asymmetrical/entryrelations/Jackets-Peacoats-Asymmetrical-Black-Small/ProductVariation").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/entries/Jackets-Peacoats-Asymmetrical/entryrelations/Jackets-Peacoats-Asymmetrical-Black-Small/ProductVariation").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "GetXml.xml"), result);
                return "Get entry relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostEntryRelation()
        {
            try
            {
                var model = new EntryRelation()
                {
                    ChildEntryCode = "Jackets-Peacoats-Hooded-Tan-Large",
                    GroupName = "default",
                    ParentEntryCode = "Jackets-Peacoats-Asymmetrical",
                    Quantity = 1,
                    RelationType = "ProductVariation",
                    SortOrder = 0
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(EntryRelation), model);
                var result = Post("/episerverapi/commerce/entries/Jackets-Peacoats-Asymmetrical/entryrelations", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/entries/Jackets-Peacoats-Asymmetrical/entryrelations", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "PostXml.xml"), result);
                return "Post entry relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutEntryRelation()
        {
            try
            {
                var model = new EntryRelation()
                {
                    ChildEntryCode = "Jackets-Peacoats-Hooded-Tan-Large",
                    GroupName = "default",
                    ParentEntryCode = "Jackets-Peacoats-Asymmetrical",
                    Quantity = 1,
                    RelationType = "ProductVariation",
                    SortOrder = 0
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(EntryRelation), model);
                var result = Put("episerverapi/commerce/entries/Jackets-Peacoats-Asymmetrical/entryrelations/Jackets-Peacoats-Hooded-Tan-Large/ProductVariation", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/entries/Jackets-Peacoats-Asymmetrical/entryrelations/Jackets-Peacoats-Hooded-Tan-Large/ProductVariation", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "PutXml.xml"), result);
                return "Put entry relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteEntryRelation()
        {
            try
            {
                var result = Delete("episerverapi/commerce/entries/Jackets-Peacoats-Asymmetrical/entryrelations/Jackets-Peacoats-Hooded-Tan-Large/ProductVariation").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/entries/Jackets-Blazers-Wrap/entryrelations/Jackets-Peacoats-Hooded-Tan-Largedd/ProductVariation").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_relationOutputPath, "DeleteXml.xml"), result);
                return "Delete entry relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
