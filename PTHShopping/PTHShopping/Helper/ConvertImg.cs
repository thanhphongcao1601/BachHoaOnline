using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PTHShopping.Helper
{
    public class ConvertImg
    {
        private readonly IHostingEnvironment _environment;
        public string saveImg(IFormFile file)
        {
            var newFileName = string.Empty;
            var fileName = string.Empty;
            string PathDB = string.Empty;
            if (file.Length > 0)
            {
                // lay FileName
                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                //tao ten tep chong trung
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                // lay duoi file
                var FileExtension = Path.GetExtension(fileName);
                // FileName + FileExtension
                newFileName = myUniqueFileName + FileExtension;
                // tao path de dua file vo root
                fileName = Path.Combine(_environment.WebRootPath, "ProductImages") + $@"\{newFileName}";
                // path de luu DB
                PathDB = "ProductImages/" + newFileName;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return PathDB;
        }
    }
    
}
