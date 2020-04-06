using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practice6april.Models;

namespace Practice6april.Controllers
{
    public class ProfilePicController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ProfilePicController> _logger;

        public ProfilePicController(ILogger<ProfilePicController> logger,
            IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string UploadFile(ProfilePic picupload)
        {
            string ext = System.IO.Path.GetExtension(picupload.FormFile.FileName);
        




            if (picupload.FormFile != null &&( ext==".jpeg" || ext==".jpg" || ext == ".gif" || ext == ".png"))
            {
                string filepath = $"{_env.WebRootPath}/images/{ picupload.FormFile.FileName}";


                var stream = System.IO.File.Create(filepath);
                picupload.FormFile.CopyTo(stream);
            }
            else
            {
                return "Only Images of type .jpg,.gif,.png or .jpeg is accepted";
            }
            return "PROFILE PIC UPLOAD SUCCESSFUL";

        }
    }
}