using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace EPiServer.Integration.Client.Tests.Cruds
{
    public class WarehouseTest : BaseTest
    {
        private readonly string _warehouseOutputPath;

        public WarehouseTest()
        {
            _warehouseOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Warehouse\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Get examples written to directory {0}.\n", _warehouseOutputPath);
            message.AppendLine("Running get all warehouses.....");
            message.AppendLine(GetAllWarehouses());
            message.AppendLine("Running get warehouse.....");
            message.AppendLine(GetWarehouse());
            message.AppendLine("Running post warehouse.....");
            message.AppendLine(PostWarehouse());
            message.AppendLine("Running put warehouse.....");
            message.AppendLine(PutWarehouse());
            message.AppendLine("Running delete warehouse.....");
            message.AppendLine(DeleteWarehouse());
            return message.ToString();
        }

        private string GetAllWarehouses()
        {
            try
            {
                var result = Get("/episerverapi/commerce/warehouses").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/warehouses").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "GetAllXml.xml"), result);
                return "Get all warehouses complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetWarehouse()
        {
            try
            {
                var result = Get("episerverapi/commerce/warehouses/WELLINGTON").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/warehouses/WELLINGTON").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "GetXml.xml"), result);
                return "Get warehouse complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostWarehouse()
        {
            try
            {
                var model = new Warehouse()
                {
                    City = "City",
                    Code = "Warehouse 3",
                    CountryCode = "CountryCode",
                    CountryName = "CountryName",
                    DaytimePhoneNumber = "DaytimePhoneNumber",
                    Email = "Email",
                    EveningPhoneNumber = "EveningPhoneNumber",
                    FaxNumber = "FaxNumber",
                    FirstName = "FirstName",
                    FulfillmentPriorityOrder = 0,
                    IsActive = true,
                    IsDeliveryLocation = true,
                    IsFulfillmentCenter = false,
                    IsPickupLocation = false,
                    IsPrimary = false,
                    LastName = "LastName",
                    Line1 = "Line1",
                    Line2 = "Line2",
                    Name = "Name",
                    Organization = "Organization",
                    PostalCode = "PostalCode",
                    RegionCode = "RegionCode",
                    RegionName = "RegionName",
                    SortOrder = 0,
                    State = "State"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Warehouse), model);
                var result = Post("/episerverapi/commerce/warehouses", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/warehouses", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "PostXml.xml"), result);
                return "Post entry warehouse complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutWarehouse()
        {
            try
            {
                var model = new Warehouse()
                {
                    City = "City",
                    Code = "Warehouse 3",
                    CountryCode = "CountryCode",
                    CountryName = "CountryName",
                    DaytimePhoneNumber = "DaytimePhoneNumber",
                    Email = "Email",
                    EveningPhoneNumber = "EveningPhoneNumber",
                    FaxNumber = "FaxNumber",
                    FirstName = "FirstName",
                    FulfillmentPriorityOrder = 0,
                    IsActive = true,
                    IsDeliveryLocation = true,
                    IsFulfillmentCenter = false,
                    IsPickupLocation = false,
                    IsPrimary = false,
                    LastName = "LastName",
                    Line1 = "Line1",
                    Line2 = "Line2",
                    Name = "Name",
                    Organization = "Organization",
                    PostalCode = "PostalCode",
                    RegionCode = "RegionCode",
                    RegionName = "RegionName",
                    SortOrder = 0,
                    State = "State"
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Warehouse), model);
                var result = Put("episerverapi/commerce/warehouses/Warehouse 3", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/warehouses/Warehouse 3", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "PutXml.xml"), result);
                return "Put entry warehouse complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteWarehouse()
        {
            try
            {
                var result = Delete("episerverapi/commerce/warehouses/Warehouse 3").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/warehouses/WELLINGTONs").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_warehouseOutputPath, "DeleteXml.xml"), result);
                return "Delete entry warehouse complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
