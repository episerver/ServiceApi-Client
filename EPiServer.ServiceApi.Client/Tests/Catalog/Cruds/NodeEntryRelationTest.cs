using System;
using System.IO;
using System.Net.Http;
using System.Text;
using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;

namespace EPiServer.Integration.Client.Tests.Catalog.Cruds
{
    public class NodeEntryRelationTest : BaseTest
    {
        private readonly string _nodeEntryRelationOutputPath;

        public NodeEntryRelationTest()
        {
            _nodeEntryRelationOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("NodeEntryRelation\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Node Entry Relation examples written to directory {0}.\n", _nodeEntryRelationOutputPath);
            message.AppendLine("Running get all node entry relations.....");
            message.AppendLine(GetAllNodeEntryRelations());
            message.AppendLine("Running get node entry relation.....");
            message.AppendLine(GetNodeEntryRelation());
            message.AppendLine("Running post node entry relation.....");
            message.AppendLine(PostNodeEntryRelation());
            message.AppendLine("Running put node entry relation.....");
            message.AppendLine(PutNodeEntryRelation());
            message.AppendLine("Running delete node entry relation.....");
            message.AppendLine(DeleteNodeEntryRelation());
            return message.ToString();
        }

        private string GetAllNodeEntryRelations()
        {
            try
            {
                var result = Get("/episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "GetAllXml.xml"), result);
                return "Get all entry node entry relations complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetNodeEntryRelation()
        {
            try
            {
                var result = Get("episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations/Tops-Tunics").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations/Tops-Tunics").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "GetXml.xml"), result);
                return "Get entry node entry relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostNodeEntryRelation()
        {
            try
            {
                var model = new NodeEntryRelation()
                {
                    EntryCode = "Tops-Tunics-LongSleeve",
                    NodeCode = "Tops-Sweaters",
                    SortOrder = 0
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(NodeEntryRelation), model);
                var result = Post("/episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "PostXml.xml"), result);
                return "Post entry node entry relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutNodeEntryRelation()
        {
            try
            {
                var model = new NodeEntryRelation()
                {
                    EntryCode = "Tops-Tunics-LongSleeve",
                    NodeCode = "Tops-Sweaters",
                    SortOrder = 5
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(NodeEntryRelation), model);
                var result = Put("episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations/Tops-Sweaters", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations/Tops-Sweaters", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "PutXml.xml"), result);
                return "Put entry node entry relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteNodeEntryRelation()
        {
            try
            {
                var result = Delete("episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations/Tops-Sweaters").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/entries/Tops-Tunics-LongSleeve/nodeentryrelations/Tops-Sweaterssss").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeEntryRelationOutputPath, "DeleteXml.xml"), result);
                return "Delete entry node entry relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
