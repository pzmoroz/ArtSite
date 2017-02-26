using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using ArtSite.Model;

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
            var files = Directory.GetFiles(@"D:\Arts\All");

            var filesAmount = files.Length;
            var filesIndex = (new Random((int)DateTime.Now.Ticks)).Next(filesAmount);
            var pictureFile = files[filesIndex];

            var picture = new Picture
            {
                FileData = System.IO.File.ReadAllBytes(pictureFile),
                FileName = Path.GetFileName(pictureFile)
            };

            return picture;
        }
            
    }
}