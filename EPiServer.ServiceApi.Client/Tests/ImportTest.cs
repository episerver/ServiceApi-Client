using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EPiServer.Integration.Client.Client;
using System.IO;
using EPiServer.Integration.Client.Models;
using Newtonsoft.Json;

namespace EPiServer.Integration.Client.Tests
{
    public class ImportTest : BaseTest
    {
        private readonly string _importOutputPath;

        public ImportTest()
        {
            _importOutputPath = Directory.CreateDirectory(Path.Combine(OutputDirectory, String.Format("Import\\{0}", DateTime.Now.ToString("yyyy_MM_dd_HHmmss")))).FullName;
        }

        public override string Execute()
        {
            var message = new StringBuilder();
            var taskId = Guid.Empty;
            foreach (var msg in CatalogImportTest(out taskId))
            {
                message.AppendLine(msg.Message);
                if (msg.MessageType == MessageType.Error)
                {
                    message.AppendLine(msg.ExceptionStackTrace);
                }
            }
            if (taskId != Guid.Empty)
            {
                WriteResults(taskId, "Catalog");
            }

            taskId = Guid.Empty;
            foreach (var msg in CatalogImportUpdateTest(out taskId))
            {
                message.AppendLine(msg.Message);
                if (msg.MessageType == MessageType.Error)
                {
                    message.AppendLine(msg.ExceptionStackTrace);
                }
            }
            if (taskId != Guid.Empty)
            {
                WriteResults(taskId, "CatalogUpdate");
            }

            taskId = Guid.Empty;
            foreach (var msg in MediaImportTest(out taskId))
            {
                message.AppendLine(msg.Message);
                if (msg.MessageType == MessageType.Error)
                {
                    message.AppendLine(msg.ExceptionStackTrace);
                }
            }
            if (taskId != Guid.Empty)
            {
                WriteResults(taskId, "Media");
            }
            return message.ToString();
        }

        private IEnumerable<JobMessage> CatalogImportTest(out Guid taskId)
        {
            var content = new MultipartFormDataContent();
            var filestream = new FileStream(Path.Combine(TestDataDirectory, "Catalog.zip"), FileMode.Open);
            content.Add(new StreamContent(filestream), "file", "Catalog.zip");
            return PostImport("/episerverapi/commerce/import/catalog", content, out taskId);
        }

        private IEnumerable<JobMessage> CatalogImportUpdateTest(out Guid taskId)
        {
            var content = new MultipartFormDataContent();
            var filestream = new FileStream(Path.Combine(TestDataDirectory, "UpdatedCatalog.zip"), FileMode.Open);
            content.Add(new StreamContent(filestream), "file", "UpdatedCatalog.zip");
            return PostImport("/episerverapi/commerce/import/catalog", content, out taskId);
        }

        private IEnumerable<JobMessage> MediaImportTest(out Guid taskId)
        {
            var content = new MultipartFormDataContent();
            var filestream = new FileStream(Path.Combine(TestDataDirectory, "MediaImport.zip"), FileMode.Open);
            content.Add(new StreamContent(filestream), "file", "MediaImport.zip");
            return PostImport("/episerverapi/commerce/import/assets", content, out taskId);
        }

        private IEnumerable<JobMessage> PostImport(string url, MultipartFormDataContent content, out Guid taskId)
        {
            taskId = Guid.Empty;
            var response = Post(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var returnString = response.Content.ReadAsStringAsync().Result;
                taskId = GetJobId(returnString);
                if (taskId != Guid.Empty)
                {
                    return WaitForCompletion(taskId);
                }
                return new List<JobMessage>()
                {
                    new JobMessage()
                    {
                        Exception = null,
                        ExceptionMessage = "Error parsing returned job guid",
                        ExceptionStackTrace = "",
                        Message = "Task Failed",
                        MessageType = MessageType.Error,
                        StageCount = 1,
                        StageIndex = 1,
                        StageProgress = 100,
                        StageTotalProgress = 100,
                        StageName = "",
                        TimestampUtc = DateTime.UtcNow
                    }
                };
            }
            return new List<JobMessage>()
            {
                new JobMessage()
                {
                    Exception = null,
                    ExceptionMessage = response.ReasonPhrase,
                    ExceptionStackTrace = response.Content.ReadAsStringAsync().Result,
                    Message = "Task Failed",
                    MessageType = MessageType.Error,
                    StageCount = 1,
                    StageIndex = 1,
                    StageProgress = 100,
                    StageTotalProgress = 100,
                    StageName = "",
                    TimestampUtc = DateTime.UtcNow
                }
            };
        }

        private void WriteResults(Guid taskId, string importType)
        {
            var response = Get(String.Format("/episerverapi/commerce/task/{0}/log", taskId)).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_importOutputPath, String.Format("{0}_JsonLog.txt", importType)), result);
            }

            response = GetXml(String.Format("/episerverapi/commerce/task/{0}/log", taskId)).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_importOutputPath, String.Format("{0}_XmlLog.xml", importType)), result);
            }

            response = Get(String.Format("/episerverapi/commerce/task/{0}/status", taskId)).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_importOutputPath, String.Format("{0}_JsonStatus.txt", importType)), result);
            }

            response = GetXml(String.Format("/episerverapi/commerce/task/{0}/status", taskId)).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                WriteTextFile(Path.Combine(_importOutputPath, String.Format("{0}_XmlStatus.xml", importType)), result);
            }
        }
    }
}
