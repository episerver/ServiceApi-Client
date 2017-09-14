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
    public class CustomerTest : BaseTest
    {
        private readonly string _customerOutputPath;

        private readonly Guid _userId = Guid.Parse("099E12F5-684C-4F34-A38B-CEBFC8E41816");
        private readonly Guid _organizationId = Guid.Parse("372FF76E-F8FD-4DF0-9AD8-55AAA3E096B7");

        public CustomerTest()
        {
            _customerOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Customer\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            message.AppendFormat("Customer examples written to directory {0}.\n", _customerOutputPath);
            message.AppendLine("Running post contact.....");
            message.AppendLine(PostContact());
            message.AppendLine("Running get contact.....");
            message.AppendLine(GetContact());
            message.AppendLine("Running post organization.....");
            message.AppendLine(PostOrganization());
            message.AppendLine("Running put organization.....");
            message.AppendLine(PutOrganization());
            message.AppendLine("Running delete organization.....");
            message.AppendLine(DeleteOrganization());
            return message.ToString();
        }

        public string GetContact()
        {
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact

            var result = Get($"/episerverapi/commerce/customers/contact/{contactId}").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "GetJson.txt"), result);
            result = GetXml($"/episerverapi/commerce/customers/contact/{contactId}").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "GetXml.xml"), result);
            return "Get contact completed";
        }

        public string PostContact()
        {
            var addresses = new List<Address>();
            var address = new Address
            {
                ShippingDefault = true,
                PostalCode = "10012",
                City = "New York",
                CountryCode = "US",
                CountryName = "United States",
                RegionName = "New York",
                RegionCode = "NY",
                Email = "frederik@geta.no",
                FirstName = "Frederik",
                LastName = "Vig",
                Line1 = "379 West Broadway",
                Line2 = "Suite 248",
                DaytimePhoneNumber = "(347) 261-7408",
                EveningPhoneNumber = "(347) 261-7408",
                Name = "Shipping address",
                Modified = DateTime.UtcNow
            };
            addresses.Add(address);

            var model = new Contact
            {
                FirstName = "Frederik",
                LastName = "Vig",
                Email = "frederik@geta.no",
                RegistrationSource = "Geta.ServiceApi.Commerce integration tests",
                Addresses = addresses.ToArray()
            };

            var json = JsonConvert.SerializeObject(model);
            var xml = SerializeObjectToXml(typeof(Contact), model);
            var result = Post($"/episerverapi/commerce/customers/contact/{_userId}", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "PostJson.txt"), result);
            result = Post($"/episerverapi/commerce/customers/contact/{_userId}", new StringContent(xml, Encoding.UTF8, "application/xml")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "PostXml.xml"), result);
            return "Post contact completed";
        }

        public string PostOrganization()
        {
            var model = new Organization
            {
                PrimaryKeyId = _organizationId,
                Addresses = new List<Address>()
                {
                    new Address
                    {
                        ShippingDefault = true,
                        PostalCode = "10012",
                        City = "New York",
                        CountryCode = "US",
                        CountryName = "United States",
                        RegionName = "New York",
                        RegionCode = "NY",
                        Email = "frederik@geta.no",
                        FirstName = "Frederik",
                        LastName = "Vig",
                        Line1 = "379 West Broadway",
                        Line2 = "Suite 248",
                        DaytimePhoneNumber = "(347) 261-7408",
                        EveningPhoneNumber = "(347) 261-7408",
                        Name = "Shipping address",
                        Modified = DateTime.UtcNow
                    }
                }
            };

            var json = JsonConvert.SerializeObject(model);
            var xml = SerializeObjectToXml(typeof(Organization), model);
            var result = Post($"/episerverapi/commerce/customers/organization", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "DeleteOrganizationJson.txt"), result);
            result = Post($"/episerverapi/commerce/customers/organization", new StringContent(xml, Encoding.UTF8, "application/xml")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "DeleteOrganizationXml.xml"), result);
            return "Post organization completed";
        }

        public string PutOrganization()
        {
            var model = new Organization
            {
                PrimaryKeyId = _organizationId,
                OrganizationType = "Corporation",
                Addresses = new List<Address>()
                {
                    new Address
                    {
                        ShippingDefault = true,
                        PostalCode = "10012",
                        City = "New York",
                        CountryCode = "US",
                        CountryName = "United States",
                        RegionName = "New York",
                        RegionCode = "NY",
                        Email = "frederik@geta.no",
                        FirstName = "Frederik",
                        LastName = "Vig",
                        Line1 = "379 West Broadway",
                        Line2 = "Suite 248",
                        DaytimePhoneNumber = "(347) 261-7408",
                        EveningPhoneNumber = "(347) 261-7408",
                        Name = "Shipping address",
                        Modified = DateTime.UtcNow
                    }
                }
            };

            var json = JsonConvert.SerializeObject(model);
            var xml = SerializeObjectToXml(typeof(Organization), model);
            var result = Put($"/episerverapi/commerce/customers/organization/{_organizationId}", new StringContent(json, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "DeleteOrganizationJson.txt"), result);
            result = Put($"/episerverapi/commerce/customers/organization/{_organizationId}", new StringContent(xml, Encoding.UTF8, "application/xml")).Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "DeleteOrganizationXml.xml"), result);
            return "Post organization completed";
        }

        public string DeleteOrganization()
        {
            var result = Delete($"/episerverapi/commerce/customers/organization/{_organizationId}").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "DeleteOrganizationJson.txt"), result);
            result = DeleteXml($"/episerverapi/commerce/customers/organization/{_organizationId}").Result.Content.ReadAsStringAsync().Result;
            WriteTextFile(Path.Combine(_customerOutputPath, "DeleteOrganizationXml.xml"), result);
            return "Delete organization completed";
        }
    }
}


