using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Integration.Client.Models.Order;
using Newtonsoft.Json;

namespace EPiServer.Integration.Client.Tests.Order
{
    public class CartTest : BaseTest
    {
        private readonly string _cartOutputPath;

        private readonly Guid _userId = Guid.NewGuid();

        public CartTest()
        {
            _cartOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Cart\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Customer examples written to directory {0}.\n", _cartOutputPath);
            message.AppendLine("Running post cart.....");
            message.AppendLine(PostCart());
            message.AppendLine("Running get cart.....");
            message.AppendLine(GetCart());
            message.AppendLine("Running put cart.....");
            message.AppendLine(PutCart());
            message.AppendLine("Running get carts.....");
            message.AppendLine(GetCarts());
            message.AppendLine("Running delete cart.....");
            message.AppendLine(DeleteOrder());
            return message.ToString();
        }

        private string PutCart()
        {
            var model = new OrderGroup
            {
                CustomerId = _userId,
                Name = "Default",
                OrderForms = new[]
    {
                    new OrderForm
                    {
                        Name = "Default",
                        Total = 500,
                        Shipments = new []
                        {
                            new Shipment
                            {
                                ShipmentTrackingNumber = "Track-123",
                                ShippingMethodName = "FedEx",
                                Status = $"Shipped on {DateTime.UtcNow}",

                                LineItems = new []
                                {
                                    new LineItem
                                    {
                                        Code = "XYZ",
                                        DisplayName = "XYZ Shirt",
                                        Quantity = 1,
                                        PlacedPrice = 150
                                    }
                                },
                                Properties = new List<PropertyItem> // Requires properties created in commerce DB through API or CM
                                {
                                    new PropertyItem { Key = "Carrier", Value = "FedEx" },
                                    new PropertyItem { Key = "CarrierTrackingUrl", Value = "http://fedex.com/track/{0}" }
                                }
                            }
                        }
                    }
                },
                OrderAddresses = new[]
{
                    new OrderAddress
                    {
                        FirstName = "Antony",
                        LastName = "Hopkins"
                    }
                },
                OrderNotes = new[]
{
                    new OrderNote
                    {
                        Title = "The note",
                        Detail = "There are some notes."
                    },
                    new OrderNote
                    {
                        Title = "The new note",
                        Detail = "There are some notes."
                    }
                }
            };
            var json = JsonConvert.SerializeObject(model);
            var xml = SerializeObjectToXml(typeof(OrderGroup), model);
            var result = Put($"/episerverapi/commerce/cart/1", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "PutJson.txt"), result);
            result = Put($"/episerverapi/commerce/cart/1", new StringContent(xml, Encoding.UTF8, "application/xml")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "PutXml.xml"), result);
            return "Put cart completed.";
        }

        private string DeleteOrder()
        {
            var result = Delete($"/episerverapi/commerce/cart/1").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "DeleteJson.txt"), result);
            result = DeleteXml($"/episerverapi/commerce/cart/1").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "DeleteXml.xml"), result);
            return "Delete cart completed.";
        }

        private string GetCart()
        {
            var result = Get($"/episerverapi/commerce/cart/1").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "GetJson.txt"), result);
            result = GetXml($"/episerverapi/commerce/cart/1").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "GetXml.xml"), result);
            return "Get cart completed.";
        }

        private string GetCarts()
        {
            var result = Get($"/episerverapi/commerce/cart/search/1/10").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "SearchJson.txt"), result);
            result = GetXml($"/episerverapi/commerce/cart/search/1/10").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "SearchXml.xml"), result);
            return "Get orders completed.";
        }

        private string PostCart()
        {
            var model = new OrderGroup
            {
                CustomerId = _userId,
                Name = "Default",
                OrderForms = new[]
                {
                    new OrderForm
                    {
                        Name = "Default",
                        Total = 500,
                        Shipments = new []
                        {
                            new Shipment
                            {
                                ShipmentTrackingNumber = "Track-123",
                                ShippingMethodName = "FedEx",
                                Status = $"Shipped on {DateTime.UtcNow}",

                                LineItems = new []
                                {
                                    new LineItem
                                    {
                                        Code = "XYZ",
                                        DisplayName = "XYZ Shirt",
                                        Quantity = 1,
                                        PlacedPrice = 150
                                    }
                                },
                                Properties = new List<PropertyItem> // Requires properties created in commerce DB through API or CM
                                {
                                    new PropertyItem { Key = "Carrier", Value = "FedEx" },
                                    new PropertyItem { Key = "CarrierTrackingUrl", Value = "http://fedex.com/track/{0}" }
                                }
                            }
                        }
                    }
                },
                OrderAddresses = new[]
    {
                    new OrderAddress
                    {
                        FirstName = "Antony",
                        LastName = "Hopkins"
                    }
                },
                OrderNotes = new[]
    {
                    new OrderNote
                    {
                        Title = "The note",
                        Detail = "There are some notes."
                    }
                }
            };

            var json = JsonConvert.SerializeObject(model);
            var xml = SerializeObjectToXml(typeof(OrderGroup), model);
            var result = Post($"/episerverapi/commerce/cart", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "PostJson.txt"), result);
            result = Post($"/episerverapi/commerce/cart", new StringContent(xml, Encoding.UTF8, "application/xml")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_cartOutputPath, "PostXml.xml"), result);
            return "Post cart completed.";
        }
    }
}
