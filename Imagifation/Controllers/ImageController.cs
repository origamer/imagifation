using Imagifation.Models;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Diagnostics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure;

namespace Imagifation.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        ImagifationContext db = new ImagifationContext();
        imageCloudStorage storage = new imageCloudStorage();

        [HttpGet]
        public ActionResult Create()
        {
            // получаем текущего пользователя
            User user = db.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            if (user != null)
            {
                return View();
            }
            return RedirectToAction("LogOff", "Account");
        }

        // Загрузка нового изображения
        [HttpPost]
        public ActionResult Create(Image image, HttpPostedFileBase error)
        {
            // получаем текущего пользователя
            User user = db.Users.Where(m => m.Login == HttpContext.User.Identity.Name).FirstOrDefault();
            if(user==null)
            {
                return RedirectToAction("LogOff", "Account");
            }

                try
                {
                    if (error.ContentLength > 0)
                    {
                        // Получить ссылку на контейнер.
                        CloudBlobContainer container = storage.GetCloudBlobContainer();
                        // Получение ссылки на blob именем "myblob".
                        CloudBlockBlob blob = container.GetBlockBlobReference(error.FileName);
                        // Загрузка изображения из файла
                        blob.UploadFromStream(error.InputStream);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception exc)
                {
                    throw;
                }
            //Добавляем изображение
                //db.Images.Add(image);
                //db.SaveChanges();
                //return View(image);
        }

        public ActionResult Index()
        {
            // получаем текущего пользователя
            User user = db.Users.Where(m => m.Login == HttpContext.User.Identity.Name).First();

            //var images = db.Images.Where(r => r.UserId == user.Id) //получаем заявки для текущего пользователя
            //                            .Include(r => r.Category)  // добавляем категории
            //                            .Include(r => r.User)         // добавляем данные о пользователях
            //                            .OrderByDescending(); // упорядочиваем по дате по убыванию   
            //return View(images);

            //List<string> blobs = new List<string>();
            //foreach (var item in container.ListBlobs())
            //{
            //    blobs.Add(item.Uri.ToString());
            //}
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("LocalStorageCon"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("gifimages");

            var images = db.BlockData.Where(r => r.UserId == user.Id); //получаем заявки для текущего пользователя
                                                //.Include(r => r.User)         // добавляем данные о пользователях
                                                //.OrderByDescending();
            return View(images);
        }

    }
}
