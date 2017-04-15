using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ArtFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToArts = @"D:\Живопись\Живопись картины русских художников 18-20 веков jpeg-600шт";
            var pathToCopy = @"D:\Arts\AllNew\";

            var fileTable = new List<PictureInfo>();

            foreach (var directory in Directory.GetDirectories(pathToArts))
            {
                var painter = Path.GetFileName(directory);
   

                foreach (var file in Directory.GetFiles(directory))
                {
                    var painting = Path.GetFileNameWithoutExtension(file);
                    var extension = Path.GetExtension(file);

                    if (extension != ".txt")
                    {
                        var newFileName = $"{painter} - {painting}";


                        var newPicture = new PictureInfo
                        {
                            Picture = painting,
                            Author = painter,
                            FileName = Guid.NewGuid() + extension
                        };

                        var newFilePath = pathToCopy + newPicture.FileName;

                        fileTable.Add(newPicture);

                        File.Copy(file, newFilePath);
                    }

                    
                }
            }

            var js = JsonConvert.SerializeObject(fileTable);


            File.WriteAllText(@"D:\Arts\AllNew\_fileTable.txt", js);
        }

        

    }

    public class PictureInfo
    {
        public string FileName { get; set; }

        public string Picture { get; set; }

        public string Author { get; set; }

    }
}
