using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System.IO;

namespace GoogleAnalyticsConsumer.Business
{
    public abstract class AzureStorageHelper
    {
        public static byte[] GetCertificateFile()
        {
            MemoryStream stream;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            
            CloudFileShare share = fileClient.GetShareReference("googleanalyticscertificate");

            // Ensure that the share exists.

            if (share.Exists())
            {
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();

                var directories = rootDir.ListFilesAndDirectories();

                CloudFile file = rootDir.GetFileReference("DMAnalyticsTest-c681eda07c72.p12");

                if (file.Exists())
                {
                    stream = new MemoryStream();
                    file.DownloadToStream(stream);
                    return stream.ToArray();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
