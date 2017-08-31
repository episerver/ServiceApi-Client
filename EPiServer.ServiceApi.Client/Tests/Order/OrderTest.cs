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
    public class OrderTest : BaseTest
    {
        private readonly string _orderOutputPath;

        private readonly Guid _userId = Guid.Parse("099E12F5-684C-4F34-A38B-CEBFC8E41816");

        public OrderTest()
        {
            _orderOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Order\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Customer examples written to directory {0}.\n", _orderOutputPath);
            message.AppendLine("Running post order.....");
            message.AppendLine(PostOrder());
            message.AppendLine("Running get order.....");
            message.AppendLine(GetOrder());
            message.AppendLine("Running put order.....");
            message.AppendLine(PutOrder());
            message.AppendLine("Running get orders.....");
            message.AppendLine(GetOrders());
            message.AppendLine("Running delete order.....");
            message.AppendLine(DeleteOrder());
            return message.ToString();
        }

        private string PutOrder()
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
            var result = Put("/episerverapi/commerce/order/1", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "PutJson.txt"), result);
            result = Put("/episerverapi/commerce/order/1", new StringContent(xml, Encoding.UTF8, "application/xml")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "PutXml.xml"), result);
            return "Put order completed.";
        }

        private string DeleteOrder()
        {
            var result = Delete("/episerverapi/commerce/order/1").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "DeleteJson.txt"), result);
            result = DeleteXml("/episerverapi/commerce/order/1").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "DeleteXml.xml"), result);
            return "Delete order completed.";
        }

        private string GetOrder()
        {
            var result = Get("/episerverapi/commerce/order/1").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "GetJson.txt"), result);
            result = GetXml("/episerverapi/commerce/order/1").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "GetXml.xml"), result);
            return "Get order completed.";
        }

        private string GetOrders()
        {
            var result = Get("/episerverapi/commerce/order/1/10/search").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "SearchJson.txt"), result);
            result = GetXml("/episerverapi/commerce/order/1/10/search").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "SearchXml.xml"), result);
            return "Get orders completed.";
        }

        private string PostOrder()
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
            var result = Post($"/episerverapi/commerce/order", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "PostJson.txt"), result);
            result = Post($"/episerverapi/commerce/order", new StringContent(xml, Encoding.UTF8, "application/xml")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_orderOutputPath, "PostXml.xml"), result);
            return "Post order completed.";
        }
    }
}
