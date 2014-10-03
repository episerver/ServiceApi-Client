using EPiServer.Integration.Client.Models.Catalog;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace EPiServer.Integration.Client.Tests.Cruds
{
    public class PriceTest : BaseTest
    {
        private readonly string _priceOutputPath;

        public PriceTest()
        {
            _priceOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Price\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Get examples written to directory {0}.\n", _priceOutputPath);
            message.AppendLine("Running get all entry prices.....");
            message.AppendLine(GetAllEntryPrices());
            message.AppendLine("Running get entry price.....");
            message.AppendLine(GetEntryPrice());
            message.AppendLine("Running post entry price.....");
            message.AppendLine(PostEntryPrice());
            message.AppendLine("Running put entry price.....");
            message.AppendLine(PutEntryPrice());
            message.AppendLine("Running delete entry price.....");
            message.AppendLine(DeleteEntryPrice());
            return message.ToString();
        }

        private string GetAllEntryPrices()
        {
            try
            {
                var result = Get("/episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "GetAllJson.txt"), result);
                result = GetXml("/episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "GetAllXml.xml"), result);
                return "Get all entry prices complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string GetEntryPrice()
        {
            try
            {
                var result = Get("episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices/250").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "GetJson.txt"), result);
                result = GetXml("episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices/250").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "GetXml.xml"), result);
                return "Get entry price complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PostEntryPrice()
        {
            try
            {
                var model = new Price()
                {
                    CatalogEntryCode = "Jackets-Peacoats-Hooded-Tan-Small",
                    CurrencyCode = "USD",
                    MarketId = "DEFAULT",
                    MinQuantity = 0,
                    PriceCode = "mark",
                    PriceTypeId = "PriceGroup",
                    UnitPrice = 30,
                    ValidFrom = DateTime.UtcNow,
                    ValidUntil = DateTime.UtcNow.AddDays(100)
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Price), model);
                var result = Post("/episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "PostJson.txt"), result);
                result = Post("/episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "PostXml.xml"), result);
                return "Post entry price complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string PutEntryPrice()
        {
            try
            {
                var model = new Price()
                {
                    CatalogEntryCode = "Jackets-Peacoats-Hooded-Tan-Small",
                    CurrencyCode = "USD",
                    MarketId = "DEFAULT",
                    MinQuantity = 0,
                    PriceCode = "",
                    PriceTypeId = "AllCustomers",
                    PriceValueId = 250,
                    UnitPrice = 30,
                    ValidFrom = DateTime.UtcNow,
                    ValidUntil = DateTime.UtcNow.AddDays(100)
                };
                var json = JsonConvert.SerializeObject(model);
                var xml = SerializeObjectToXml(typeof(Price), model);
                var result = Put("episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices/250", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "PutJson.txt"), result);
                result = Put("episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices/250", new StringContent(xml, Encoding.UTF8, "text/xml")).Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "PutXml.xml"), result);
                return "Put entry price complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private string DeleteEntryPrice()
        {
            try
            {
                var result = Delete("episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices/99999999999").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "DeleteJson.txt"), result);
                result = DeleteXml("episerverapi/commerce/entries/Jackets-Peacoats-Hooded-Tan-Small/prices/99999999999").Result.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_priceOutputPath, "DeleteXml.xml"), result);
                return "Delete entry price complete.....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
