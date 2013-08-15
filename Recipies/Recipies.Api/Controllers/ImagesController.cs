using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Recipies.Dropbox;

namespace Recipies.Api.Controllers
{
    public class ImagesController : ApiController
    {
        public void UploadImage(string sessionKey)
        {
            HttpContext current = HttpContext.Current;
            for (int i = 0; i < current.Request.Files.Count; i++)
            {
                HttpPostedFile file = current.Request.Files[i];
                Stream stream = file.InputStream;

                string fullFileName = Path.GetTempPath() + '/' + file.FileName;
                using (var fileStream = File.Create(fullFileName))
                {
                    stream.CopyTo(fileStream);
                }  

                // saved successfully
                DropboxUploader uploader = new DropboxUploader();
                uploader.Run(fullFileName);
            }
        }
    }
}
