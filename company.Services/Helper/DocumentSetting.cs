using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Services.Helper
{
    public class DocumentSetting
    {
        public static string uploadFile (IFormFile file, string folderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);
            using var FileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(FileStream);
            return fileName;
        }

    }

}
