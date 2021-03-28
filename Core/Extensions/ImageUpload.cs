using Core.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Core.Extensions
{
    public static class ImageUpload
    {
       
        public static void Add(IEntity entity , IFormFile formFile)
            {
        //    if (formFile.Length > 0)
        //    {
        //        if (!Directory.Exists(_environment.WebRootPath + @"\Uploads\"))
        //        {
        //            Directory.CreateDirectory(_environment.WebRootPath + @"\Uploads\");
        //        }

        //        string guidKey = Guid.NewGuid().ToString("N");
        //        using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + GuidFileCreate(formFile, guidKey)))
        //        {
        //            /*formdan gelen datayı belleğe yazıp oradan oluşturduğumuz dosyaya
        //             * yazma işlemi yapıyoruz , ve bundan sonra cachede durması performans
        //             * sorunları yaratacağıdan flush ile cache i temizliyoruz.
        //             */

        //            formFile.CopyTo(fileStream);
        //            fileStream.Flush();

        //            carImage.Date = DateTime.Now;
        //            carImage.ImagePath = GuidFileCreate(formFile, guidKey);

        //            var result = _carImageManager.Add(carImage);
                  
                // }
           // }
        }
    }
}
