using System;
using System.IO;
using System.Net.Http;
using System.Text;
using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;

namespace EPiServer.Integration.Client.Tests.Catalog.Cruds
{
    public class WarehouseInventoryTest : BaseTest
    {
        private readonly string _warehouseInventoryOutputPath;

        public WarehouseInventoryTest()
        {
            _warehouseInventoryOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("WarehouseInventory\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Get examples written to directory {0}.\n", _warehouseInventoryOutputPath);
            message.AppendLine("Running get all entry warehouse inventories.....");
            message.AppendLine(GetAllEntryWarehouseInventories());
            message.AppendLine("Running get entry warehouse inventory.....");
            message.AppendLine(GetEntryWarehouseInventory());
            message.AppendLine("Running post entry warehouse inventory.....");
            message.AppendLine(PostEntryWarehouseInventory());
            message.AppendLine("Running put entry warehouse inventory.....");
            message.AppendLine(PutEntryWarehouseInventory());
            message.AppendLine("Running delete entry warehouse inventory.....");
            message.AppendLine(DeleteEntryWarehouseInventory());
            return message.ToString();
        }

        private string GetAllEntryWarehouseInventories()
        {
            try
            {
                var result = Get("/episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "GetAllXml.xml"), result);
                return "Get all entry warehouse inventories complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetEntryWarehouseInventory()
        {
            try
            {
                var result = Get("episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories/WELLINGTON").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories/WELLINGTON").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "GetXml.xml"), result);
                return "Get entry warehouse inventory complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostEntryWarehouseInventory()
        {
            try
            {
                var model = new WarehouseInventory()
                {
                    AllowBackorder = true,
                    AllowPreorder = true,
                    BackorderAvailabilityDate = DateTime.UtcNow,
                    BackorderQuantity = 2,
                    CatalogEntryCode = "Accessories-Electronics-200WattsAMFMCDReciever-sku",
                    InStockQuantity = 23,
                    InventoryStatus = "Enabled",
                    PreorderAvailabilityDate = DateTime.UtcNow,
                    PreorderQuantity = 3,
                    ReorderMinQuantity = 1,
                    ReservedQuantity = 1,
                    WarehouseCode = "WELLINGTON"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(WarehouseInventory), model);
                var result = Post("/episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "PostXml.xml"), result);
                return "Post entry warehouse inventory complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutEntryWarehouseInventory()
        {
            try
            {
                var model = new WarehouseInventory()
                {
                    AllowBackorder = true,
                    AllowPreorder = true,
                    BackorderAvailabilityDate = DateTime.UtcNow,
                    BackorderQuantity = 2,
                    CatalogEntryCode = "Accessories-Electronics-200WattsAMFMCDReciever-sku",
                    InStockQuantity = 23,
                    InventoryStatus = "Enabled",
                    PreorderAvailabilityDate = DateTime.UtcNow,
                    PreorderQuantity = 3,
                    ReorderMinQuantity = 1,
                    ReservedQuantity = 1,
                    WarehouseCode = "WELLINGTON"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(WarehouseInventory), model);
                var result = Put("episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories/WELLINGTON", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories/WELLINGTON", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "PutXml.xml"), result);
                return "Put entry warehouse inventory complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteEntryWarehouseInventory()
        {
            try
            {
                var result = Delete("episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories/WELLINGTONs").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/entries/Accessories-Electronics-200WattsAMFMCDReciever-sku/inventories/WELLINGTONs").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseInventoryOutputPath, "DeleteXml.xml"), result);
                return "Delete entry warehouse inventory complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
