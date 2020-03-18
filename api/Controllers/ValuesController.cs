using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace api.Controllers
{
   public class uploadData
    {
       public string imageData { get; set; }
       public string name { get; set; }
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post(uploadData data)
        {

            SaveImage(data.imageData, data.name);
            return "post";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
           
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        public bool SaveImage(string ImgStr, string ImgName)
        {
            String path = HttpContext.Current.Server.MapPath("~/images"); //Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = ImgName + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr);

            File.WriteAllBytes(imgPath, imageBytes);

            return true;
        }
    }
}
