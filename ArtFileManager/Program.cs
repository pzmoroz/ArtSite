using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToArts = @"D:\Живопись\Живопись картины русских художников 18-20 веков jpeg-600шт";
            var pathToCopy = @"D:\Arts\All\";

            foreach (var directory in Directory.GetDirectories(pathToArts))
            {
                var painter = Path.GetFileName(directory);
   

                foreach (var file in Directory.GetFiles(directory))
                {
                    var painting = Path.GetFileNameWithoutExtension(file);
                    var extension = Path.GetExtension(file);

                    var newFileName = $"{painter} - {painting}";
                    var newFilePath = pathToCopy + newFileName + extension;
                    File.Copy(file, newFilePath);
                }



            }
        }
    }
}
