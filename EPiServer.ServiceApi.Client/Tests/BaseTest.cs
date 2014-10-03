using System.Net;
using System.Xml.Serialization;
using EPiServer.Integration.Client.Client;
using EPiServer.Integration.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EPiServer.Integration.Client.Tests
{
    public abstract class BaseTest
    {
        abstract public string Execute();

        private readonly OAuth2Client _oAuth2Client;
        protected readonly string TestDataDirectory;
        protected readonly string OutputDirectory;


        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTest"/> class.
        /// </summary>
        protected BaseTest()
        {
            _oAuth2Client = new OAuth2Client(new Uri(ConfigurationManager.AppSettings["integrationUrl"] + "episerverapi/token"));
            TestDataDirectory = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "TestData");
            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["OutputDirectory"]))
            {
                throw new Exception("OutputDirectory was not found in appsettings.  Please enter a value for the output directory");
            }
            OutputDirectory = ConfigurationManager.AppSettings["OutputDirectory"];
            EnsureOutputDirectory();
        }

        private async Task<HttpClient> GetHttpClient()
        {
            var token = await _oAuth2Client.RequestResourceOwnerPasswordAsync(ConfigurationManager.AppSettings["username"],
                ConfigurationManager.AppSettings["password"]);
            if (token.IsError)
            {
                return null;
            }
            var client = new HttpClient()
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["integrationUrl"])
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            return client;
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> Post(string url, HttpContent content)
        {
            var client = await GetHttpClient();
            return client != null ? client.PostAsync(url, content).Result : null;
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> Put(string url, HttpContent content)
        {
            var client = await GetHttpClient();
            return client != null ? client.PutAsync(url, content).Result : null;
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> Get(string url)
        {
            var client = await GetHttpClient();
            return client != null ? client.GetAsync(url).Result : null;
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="completionOption">The completion option.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> Get(string url, HttpCompletionOption completionOption)
        {
            var client = await GetHttpClient();
            return client != null ? client.GetAsync(url, completionOption).Result : null;
        }

        /// <summary>
        /// Gets the XML.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> GetXml(string url)
        {
            var client = await GetHttpClient();
            if (client == null)
            {
                return null;
            }
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            return client.GetAsync(url).Result;
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> Delete(string url)
        {
            var client = await GetHttpClient();
            return client != null ? client.DeleteAsync(url).Result : null;
        }

        /// <summary>
        /// Deletes the XML.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> DeleteXml(string url)
        {
            var client = await GetHttpClient();
            if (client == null)
            {
                return null;
            }
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            return client.DeleteAsync(url).Result;
        }

        /// <summary>
        /// Gets the job identifier.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        protected Guid GetJobId(string response)
        {
            var returnString = response.Replace("\"", "");
            var taskId = Guid.Empty;
            Guid.TryParse(returnString, out taskId);
            return taskId;
        }

        /// <summary>
        /// Waits for completion.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">The requested task timed out.</exception>
        protected List<JobMessage> WaitForCompletion(Guid taskId)
        {
            const int delayIncrement = 5;
            const int maxDelay = 100;
            var delay = 5;
            bool done;
            var deadline = DateTime.Now + TimeSpan.FromMinutes(30);
            var messages = new List<JobMessage>();
            do
            {
                var response = Get(String.Format("/episerverapi/commerce/task/{0}/log", taskId)).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return new List<JobMessage>();
                }
                var result = response.Content.ReadAsStringAsync().Result;
                messages = JsonConvert.DeserializeObject<List<JobMessage>>(result);
                var lastMessage = messages.Count == 0 ? null : messages[messages.Count - 1];
                done =
                    lastMessage == null ||
                    lastMessage.MessageType == MessageType.Success ||
                    lastMessage.MessageType == MessageType.Error;

                if (!done)
                {
                    Thread.Sleep(delay);
                    delay += delayIncrement;
                    if (delay > maxDelay)
                    {
                        delay = maxDelay;
                    }
                }
                if (DateTime.Now > deadline)
                {
                    throw new Exception("The requested task timed out.");
                }
            }
            while (!done);

            return messages;
        }

        /// <summary>
        /// Serializes the object to XML.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        protected String SerializeObjectToXml(Type type, Object obj)
        {
            var serializer = new XmlSerializer(type);
            var xml = String.Empty;
            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, obj);
                xml = Encoding.Default.GetString(ms.ToArray());
            }
            return xml;
        }

        /// <summary>
        /// Writes the text file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="text">The text.</param>
        protected void WriteTextFile(string fileName, string text)
        {
            using (var sw = new StreamWriter(fileName, false))
            {
                sw.WriteLine(text);
                sw.Close();
            }
        }

        private void EnsureOutputDirectory()
        {
            Directory.CreateDirectory(ConfigurationManager.AppSettings["OutputDirectory"]);
        }
    }
}
