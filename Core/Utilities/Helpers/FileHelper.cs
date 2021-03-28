using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public  class FileHelper
    {
        public static string rootFolder = Environment.CurrentDirectory + @"\wwwroot";
        public static string Add(IFormFile formFile)
        {
            var guid = GuidFileCreate(formFile);
            if (formFile.Length > 0)
            {
                directoryNullCheck();
                using (FileStream fileStream = File.Create(rootFolder + guid))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            return guid;
        }

        public static IResult Delete(string imagePath)
        {
            try
            {
                File.Delete(rootFolder + imagePath);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
        }

        public static string Update(string deletePath ,IFormFile formFile)
        {
            var guid = GuidFileCreate(formFile);
            var deleteResult = Delete(deletePath);
            if (deleteResult.Success)
            {
                using (FileStream fileStream = File.Create(rootFolder + guid))
                {
                    formFile.CopyTo(fileStream);
                }
                return guid;
            }
            return deletePath;
        }

        public static string GuidFileCreate(IFormFile formFile)
        {
            string guidKey = Guid.NewGuid().ToString("N");
            var fileType = "." + formFile.ContentType.Split('/')[1];
            return @"\Uploads\" + guidKey + fileType;
        }

        public static void directoryNullCheck()
        {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\wwwroot\Uploads\"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\wwwroot\Uploads\");
            }
        }
    }
}
