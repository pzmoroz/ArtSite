using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArtSite2.Model;
using Microsoft.AspNetCore.Mvc;

namespace ArtSite2.Controllers
{
    public class ArtController : Controller
    {
        public IActionResult Index()
        {
            return View(GetRandomPicture());
        }

        private Picture GetRandomPicture()
        {
            var pathToArts = Directory.GetDirectories(@"D:\Живопись\Живопись картины русских художников 18-20 веков jpeg-600шт");
            var pictureFolder = GetRandomFolder(pathToArts);
            var files = Directory.GetFiles(pictureFolder);
            var pictureFile = GetRandomFile(files);

            var picture = new Picture
            {
                FileData = System.IO.File.ReadAllBytes(pictureFile),
                FileName = Path.GetFileName(pictureFile)
            };

            return picture;
        }

        private string GetRandomFile(string[] files)
        {
            var filesAmount = files.Length;

            var fileIndex = (new Random((int)DateTime.Now.Ticks)).Next(filesAmount);

            if (Path.GetExtension(files[fileIndex]) == ".txt")
            {
                return GetRandomFile(files);
            }

            return files[fileIndex];
        }

        private string GetRandomFolder(string[] folders)
        {
            var foldersAmount = folders.Length;

            var folderIndex = (new Random((int)DateTime.Now.Ticks)).Next(foldersAmount);

            return folders[folderIndex];
        }
    }
}