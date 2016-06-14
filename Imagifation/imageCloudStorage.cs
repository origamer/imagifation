using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Imagifation
{
    public class imageCloudStorage
    {
        public CloudBlobContainer GetCloudBlobContainer()
        {
            // Получения учетной записи хранения от строки подключения.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                RoleEnvironment.GetConfigurationSettingValue("LocalStorageCon"));

            // Создание blob клиента.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Получить ссылку на контейнер.
            CloudBlobContainer container = blobClient.GetContainerReference("gifimages");

            // Открытие контейнера для открытого доступа только для просмотра
            if (container.CreateIfNotExists())
            {
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }
            return container;
        }
    }
}