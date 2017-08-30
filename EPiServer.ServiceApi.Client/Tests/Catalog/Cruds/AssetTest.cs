using System;
using System.IO;
using System.Net.Http;
using System.Text;
using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;

namespace EPiServer.Integration.Client.Tests.Catalog.Cruds
{
    public class AssetTest : BaseTest
    {
        private readonly string _assetOutputPath;

        public AssetTest()
        {
            _assetOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Asset\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("ItemAsset examples written to directory {0}.\n", _assetOutputPath);

            //Entry examples
            message.AppendLine("Running get all entry assets.....");
            message.AppendLine(GetAllEntryAssets());
            message.AppendLine("Running get entry asset.....");
            message.AppendLine(GetEntryAssets());
            message.AppendLine("Running post entry asset.....");
            message.AppendLine(PostEntryAsset());
            message.AppendLine("Running put entry asset.....");
            message.AppendLine(PutEntryAsset());
            message.AppendLine("Running delete entry asset.....");
            message.AppendLine(DeleteEntryAsset());

            //Node examples
            message.AppendLine("Running get all node assets.....");
            message.AppendLine(GetAllNodeAssets());
            message.AppendLine("Running get node asset.....");
            message.AppendLine(GetNodeAssets());
            message.AppendLine("Running post node asset.....");
            message.AppendLine(PostNodeAsset());
            message.AppendLine("Running put node asset.....");
            message.AppendLine(PutNodeAsset());
            message.AppendLine("Running delete node asset.....");
            message.AppendLine(DeleteNodeAsset());

            return message.ToString();
        }

        private string GetAllEntryAssets()
        {
            try
            {
                var result = Get("/episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "GetAllEntryJson.txt"), result);
                result = GetXml("/episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "GetAllEntryXml.xml"), result);
                return "Get all entry assets complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetEntryAssets()
        {
            try
            {
                var result = Get("episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets/fd761c1d-5692-48b6-b90a-1ddf4c7c5eb9/episerver.core.icontentimage").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "GetEntryJson.txt"), result);
                result = GetXml("episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets/fd761c1d-5692-48b6-b90a-1ddf4c7c5eb9/episerver.core.icontentimage").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "GetEntryXml.xml"), result);
                return "Get entry asset complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostEntryAsset()
        {
            try
            {
                var model = new ItemAsset()
                {
                    CatalogEntryCode = "Jackets-Blazers-Wrap",
                    AssetKey = "fd761c1d-5692-48b6-b90a-1ddf4c7c5eb9",
                    AssetType = "episerver.core.icontentimage",
                    SortOrder = 45,
                    GroupName = "large"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof (ItemAsset), model);
                var result = Post("/episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "PostEntryJson.txt"), result);
                result = Post("/episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "PostEntryXml.xml"), result);
                return "Post entry asset complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutEntryAsset()
        {
            try
            {
                var model = new ItemAsset()
                {
                    CatalogEntryCode = "Jackets-Blazers-Wrap",
                    AssetKey = "fd761c1d-5692-48b6-b90a-1ddf4c7c5eb9",
                    AssetType = "episerver.core.icontentimage",
                    SortOrder = 45,
                    GroupName = "large"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(ItemAsset), model);
                var result = Put("episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets/fd761c1d-5692-48b6-b90a-1ddf4c7c5eb9/episerver.core.icontentimage", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "PutEntryJson.txt"), result);
                result = Put("episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets/fd761c1d-5692-48b6-b90a-1ddf4c7c5eb9/episerver.core.icontentimage", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "PutEntryXml.xml"), result);
                return "Put entry asset complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteEntryAsset()
        {
            try
            {
                var result = Delete("episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets/fd761c1d-5692-48b6-b90a-1ddf4c7c5eb9/episerver.core.icontentimages").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "DeleteEntryJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/entries/Jackets-Blazers-Wrap/assets/fd761c1d-5692-48b6-b90a-1ddf4c7c5eb9/episerver.core.icontentimages").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "DeleteEntryXml.xml"), result);
                return "Delete entry asset complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string GetAllNodeAssets()
        {
            try
            {
                var result = Get("/episerverapi/commerce/nodes/Fashion/assets").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "GetAllNodeJson.txt"), result);
                result = GetXml("/episerverapi/commerce/nodes/Fashion/assets").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "GetAllNodeXml.xml"), result);
                return "Get all node assets complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string GetNodeAssets()
        {
            try
            {
                var result = Get("episerverapi/commerce/nodes/Fashion/assets/ed6fc3d7-091f-4e84-b1f6-49b56e7b5146/episerver.core.icontentimage").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "GetNodeJson.txt"), result);
                result = GetXml("episerverapi/commerce/nodes/Fashion/assets/ed6fc3d7-091f-4e84-b1f6-49b56e7b5146/episerver.core.icontentimage").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "GetNodeXml.xml"), result);
                return "Get node asset complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostNodeAsset()
        {
            try
            {
                var model = new ItemAsset()
                {
                    CatalogNodeCode = "Fashion",
                    AssetKey = "ed6fc3d7-091f-4e84-b1f6-49b56e7b5146",
                    AssetType = "episerver.core.icontentimage",
                    SortOrder = 45,
                    GroupName = "large"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(ItemAsset), model);
                var result = Post("/episerverapi/commerce/nodes/Fashion/assets", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "PostNodeJson.txt"), result);
                result = Post("/episerverapi/commerce/nodes/Fashion/assets", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "PostNodeXml.xml"), result);
                return "Post node asset complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutNodeAsset()
        {
            try
            {
                var model = new ItemAsset()
                {
                    CatalogNodeCode = "Fashion",
                    AssetKey = "ed6fc3d7-091f-4e84-b1f6-49b56e7b5146",
                    AssetType = "episerver.core.icontentimage",
                    SortOrder = 45,
                    GroupName = "large"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(ItemAsset), model);
                var result = Put("episerverapi/commerce/nodes/Fashion/assets/ed6fc3d7-091f-4e84-b1f6-49b56e7b5146/episerver.core.icontentimage", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "PutNodeJson.txt"), result);
                result = Put("episerverapi/commerce/nodes/Fashion/assets/ed6fc3d7-091f-4e84-b1f6-49b56e7b5146/episerver.core.icontentimage", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "PutNodeXml.xml"), result);
                return "Put node asset complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteNodeAsset()
        {
            try
            {
                var result = Delete("episerverapi/commerce/entries/Fashion/assets/ed6fc3d7-091f-4e84-b1f6-49b56e7b5146/episerver.core.icontentimages").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "DeleteNodeJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/entries/Fashion/assets/ed6fc3d7-091f-4e84-b1f6-49b56e7b5146/episerver.core.icontentimages").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_assetOutputPath, "DeleteNodeXml.xml"), result);
                return "Delete node asset complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
