﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Helpers
{
    public static class FileManager
    {
        public static string Upload(this IFormFile file, string envPath, string folderName)
        {
            string filname = file.FileName;
            if (filname.Length > 64)
            {
                filname = filname.Substring(filname.Length - 64);
            }
            filname = Guid.NewGuid().ToString() + filname;
            string path = envPath + folderName + filname;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filname;
        }
        public static void DeleteFile(this string imgUrl, string envPath, string folderName)
        {
            string path = envPath + folderName + imgUrl;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
