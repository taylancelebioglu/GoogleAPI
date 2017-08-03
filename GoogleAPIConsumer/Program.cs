using System;
using AnalyticsConsumerRole;
using Microsoft.Azure; // Namespace for Azure Configuration Manager
using Microsoft.WindowsAzure.Storage; // Namespace for Storage Client Library
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage
using Microsoft.WindowsAzure.Storage.File; // Namespace for File storage
using System.IO;
using System.Net;
using System.Threading;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using GoogleAnalyticsConsumer.Business;

namespace GoogleAPIConsumer
{
    class Program
    {
        string azureStoregaAccessKey = "3+xWpeQRWx0C3SG8XCutUX4Fwb6dbdY9a3L+M+wNS/t+MOPYOzuDux0QjgHJ3kyS/DnmfF5GfrejFSxZ/+CO6g==";
        string azureStorageConn = "DefaultEndpointsProtocol=https;AccountName=googleanalyticsrole;AccountKey=3+xWpeQRWx0C3SG8XCutUX4Fwb6dbdY9a3L+M+wNS/t+MOPYOzuDux0QjgHJ3kyS/DnmfF5GfrejFSxZ/+CO6g==;EndpointSuffix=core.windows.net";
        static void Main(string[] args)
        {
            Console.WriteLine("Working...");
            // Query
            // https://developers.google.com/analytics/devguides/reporting/core/dimsmets
            //http://analyticswebtest-digitalmarketing.azurewebsites.net/
            //https://www.google.com/analytics/

            WorkerRole role = new WorkerRole();
            role.Run();
            
            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}
