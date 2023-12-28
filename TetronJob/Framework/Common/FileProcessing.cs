using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    using System.Drawing;
    using Microsoft.AspNetCore.Http;
    using static System.Net.Mime.MediaTypeNames;

    namespace Application.Core
    {
        public static class FileProcessing
        {
            public static string SaveFile(IFormFile file, string folderName)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(stream);
                return fileName;
            }

            public static void RemoveFile(string fileName, string folderName)
            {
                if (fileName != "default.jpg" && !string.IsNullOrEmpty(fileName))
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, fileName);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            public static bool IsImage(this IFormFile file)
            {

                try
                {
                    var check = System.Drawing.Image.FromStream(file.OpenReadStream());

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            public static string FileUpload(IFormFile? file, string? fileName, string folder)
            {
                if (file == null && string.IsNullOrEmpty(fileName))
                {
                    return "default.jpg";
                }

                if (file == null && !string.IsNullOrEmpty(fileName))
                {
                    return fileName;
                }
                var check = file.IsImage();
                if (check)
                {
                    var path = FileProcessing.SaveFile(file, folder);
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        FileProcessing.RemoveFile(fileName, folder);
                    }
                    return path;
                }
                return "default.jpg";
            }


        }
    }
}
