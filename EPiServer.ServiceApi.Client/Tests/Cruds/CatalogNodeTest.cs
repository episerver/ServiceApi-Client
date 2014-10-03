using System.Collections.Generic;
using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace EPiServer.Integration.Client.Tests.Cruds
{
    public class CatalogNodeTest : BaseTest
    {
        private readonly string _nodeOutputPath;

        public CatalogNodeTest()
        {
            _nodeOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("CatalogNode\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Catalog Node examples written to directory {0}.\n", _nodeOutputPath);
            message.AppendLine("Running Get all nodes.....");
            message.AppendLine(GetAllNodes());
            message.AppendLine("Running Get node.....");
            message.AppendLine(GetNode());
            message.AppendLine("Running post node.....");
            message.AppendLine(PostNode());
            message.AppendLine("Running put node.....");
            message.AppendLine(PutNode());
            message.AppendLine("Running delete node.....");
            message.AppendLine(DeleteNode());
            return message.ToString();
        }

        private string GetAllNodes()
        {
            try
            {
                var result = Get("/episerverapi/commerce/catalog/Departmental Catalog/nodes").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/catalog/Departmental Catalog/nodes").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "GetAllXml.xml"), result);
                return "Get all nodes complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetNode()
        {
            try
            {
                var result = Get("episerverapi/commerce/nodes/Departments").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/nodes/Departments").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "GetXml.xml"), result);
                return "Get node complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostNode()
        {
            try
            {
                var model = new Node()
                {
                    Code = "Node 2",
                    Catalog = "Departmental Catalog",
                    EndDate = DateTime.UtcNow.AddDays(100),
                    IsActive = true,
                    MetaClass = "CatalogNodeEx",
                    Name = "Test",
                    StartDate = DateTime.UtcNow,
                    ParentNodeCode = "Departments",
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
                            Uri = "node 2",
                            UriSegment = "node 2"
                        }
                    }
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Node), model);
                var result = Post("/episerverapi/commerce/nodes", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/nodes", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "PostXml.xml"), result);
                return "Post node complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutNode()
        {
            try
            {
                var model = new Node()
                {
                    Code = "Node 2",
                    Catalog = "Departmental Catalog",
                    EndDate = DateTime.UtcNow.AddDays(100),
                    IsActive = true,
                    MetaClass = "CatalogNodeEx",
                    Name = "Test",
                    StartDate = DateTime.UtcNow,
                    ParentNodeCode = "Departments",
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
                            Uri = "node 2",
                            UriSegment = "node 2"
                        }
                    }
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Node), model);
                var result = Put("episerverapi/commerce/nodes/Node 2", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/nodes/Node 2", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "PutXml.xml"), result);
                return "Put node complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteNode()
        {
            try
            {
                var result = Delete("episerverapi/commerce/nodes/Node 2").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/nodes/Node 23").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_nodeOutputPath, "DeleteXml.xml"), result);
                return "Delete node complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
