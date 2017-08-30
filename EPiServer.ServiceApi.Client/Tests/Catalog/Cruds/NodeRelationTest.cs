using System;
using System.IO;
using System.Net.Http;
using System.Text;
using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;

namespace EPiServer.Integration.Client.Tests.Catalog.Cruds
{
    public class NodeRelationTest : BaseTest
    {
        private readonly string _nodeRelationOutputPath;

        public NodeRelationTest()
        {
            _nodeRelationOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("NodeRelation\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Node Relation examples written to directory {0}.\n", _nodeRelationOutputPath);
            message.AppendLine("Running post node relation.....");
            message.AppendLine(PostNodeRelation());
            message.AppendLine("Running put node relation.....");
            message.AppendLine(PutNodeRelation());
            message.AppendLine("Running get all node relations.....");
            message.AppendLine(GetAllNodeRelations());
            message.AppendLine("Running get node relation.....");
            message.AppendLine(GetNodeRelation());
            message.AppendLine("Running delete node relation.....");
            message.AppendLine(DeleteNodeRelation());
            return message.ToString();
        }

        private string GetAllNodeRelations()
        {
            try
            {
                var result = Get("/episerverapi/commerce/nodes/Books/noderelations").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/nodes/Books/noderelations").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "GetAllXml.xml"), result);
                return "Get all node relations complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetNodeRelation()
        {
            try
            {
                var result = Get("episerverapi/commerce/nodes/Books/noderelations/Bottoms").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/nodes/Books/noderelations/Bottoms").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "GetXml.xml"), result);
                return "Get node relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostNodeRelation()
        {
            try
            {
                var model = new NodeRelation()
                {
                    ChildNodeCode = "Bottoms",
                    ParentNodeCode = "Books",
                    SortOrder = 0
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(NodeRelation), model);
                var result = Post("/episerverapi/commerce/nodes/Books/noderelations", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/nodes/Books/noderelations", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "PostXml.xml"), result);
                return "Post node relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutNodeRelation()
        {
            try
            {
                var model = new NodeRelation()
                {
                    ChildNodeCode = "Bottoms",
                    ParentNodeCode = "Books",
                    SortOrder = 0
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(NodeRelation), model);
                var result = Put("episerverapi/commerce/nodes/Books/noderelations/Bottoms", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/nodes/Books/noderelations/Bottoms", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "PutXml.xml"), result);
                return "Put node relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteNodeRelation()
        {
            try
            {
                var result = Delete("episerverapi/commerce/nodes/Books/noderelations/Bottoms").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/nodes/Books/noderelations/Bottomsss").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeRelationOutputPath, "DeleteXml.xml"), result);
                return "Delete node relation complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
