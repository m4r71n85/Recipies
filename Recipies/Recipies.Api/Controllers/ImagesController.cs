using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

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

                using (var fileStream = File.Create("~/App_Data/" + file.FileName))
                {
                    stream.CopyTo(fileStream);
                }  
            }
        }
    }
}
