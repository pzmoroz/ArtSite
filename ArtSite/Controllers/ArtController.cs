using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using ArtSite.Model;
using Newtonsoft.Json;

namespace ArtSite.Controllers
{
    public class ArtController : Controller
    {
        public IActionResult Index()
        {
            return View(GetRandomPicture());
        }


        private Picture GetRandomPicture()
        {
//#if DEBUG
//            var path = @"D:\Arts\AllNew\";
            
//#else
//            var path = @"/var/ArtSite/Pictures/";
//#endif

            var path = @"/var/ArtSite/Pictures/";

            var pictureList = GetPicturesInfo(path + "_fileTable.txt");

            //var filesAmount = files.Length;
            var random = new Random((int) DateTime.Now.Ticks);
            var tmp = random.Next();
            var randomIndex = random.Next(pictureList.Count);

            var randomPicture = pictureList[randomIndex];

            var file = path + randomPicture.FileName;

            var picture = new Picture
            {
                

                FileData = System.IO.File.ReadAllBytes(file),
                FileName = randomPicture.FileName,
                FilePath = file,
                Author = randomPicture.Author,
                Name = randomPicture.Picture
            };

            return picture;
        }

        private List<PictureInfo> GetPicturesInfo(string tableFile)
        {
            var text = System.IO.File.ReadAllText(tableFile);

            return JsonConvert.DeserializeObject<List<PictureInfo>>(text);
        }


        private string GetAutor(string fileName)
        {
            return fileName.Substring(0, fileName.IndexOf(" - "));
        }

        private string GetName(string fileName)
        {
            var startIndex = fileName.IndexOf(" - ") + 3;
            return fileName.Substring(startIndex, fileName.Length - startIndex);
        }

        public JsonResult GetRandomImage()
        {
            var picture = GetRandomPicture();
            return Json(picture);
        }
            
    }

    public class PictureInfo
    {
        public string FileName { get; set; }

        public string Picture { get; set; }

        public string Author { get; set; }

    }
}