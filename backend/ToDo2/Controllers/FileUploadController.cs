using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ToDo2.Filters;
using ToDo2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        private readonly TodoContext _todoContext;

        public FileUploadController(TodoContext todoContext,IWebHostEnvironment env)
        {
            _env = env;
            _todoContext = todoContext;
        }
        // POST api/<FileUploadController>
        /*
         * Attempt 1
         * Demo upload single file to path \wwwroot
         * **/
        //[HttpPost]
        //public void Post(IFormFile file1)
        //{
        //    string rootRoot = _env.ContentRootPath + @"\wwwroot\";
        //    if(file1.Length > 0)
        //    {
        //        var fileName = file1.FileName;

        //        using (var stream = System.IO.File.Create(rootRoot + fileName))
        //        {
        //            file1.CopyTo(stream);
        //        }
        //    }
        //}

        // POST api/<FileUploadController>
        /*
         * Attempt 2
         * Demo upload multiple file to path \wwwroot
         * **/
        //[HttpPost]
        //public void Post(List<IFormFile> files)
        //{
        //    string rootRoot = _env.ContentRootPath + @"\wwwroot\";
        //    foreach (var file in files)
        //    {
        //        var fileName = file.FileName;

        //        using (var stream = System.IO.File.Create(rootRoot + fileName))
        //        {
        //            file.CopyTo(stream);
        //        }
        //    }  

        //}

        // POST api/<FileUploadController>
        /*
         * Attempt 3
         * Demo upload multiple file to path \wwwroot\UploadFiles\{id}
         * Step 1: Upload 
         * **/
        //[HttpPost("{id}")]
        //public void Post(List<IFormFile> files, Guid id)
        //{
        //    string rootRoot = _env.ContentRootPath + @"\wwwroot\UploadFiles\"+id+"\\";

        //    if (!Directory.Exists(rootRoot))
        //    {
        //        // Check whether path exist, if not create one
        //        Directory.CreateDirectory(rootRoot);
        //    }

        //    foreach (var file in files)
        //    {
        //        var fileName = file.FileName;

        //        using (var stream = System.IO.File.Create(rootRoot + fileName))
        //        {
        //            file.CopyTo(stream);
        //        }

        //        var insert = new UploadFile
        //        {
        //            Name = fileName,
        //            Src = "/UploadFiles/" + id + "/" + fileName,
        //            TodoId = id
        //        };

        //        _todoContext.Add(insert);
        //    }

        //    _todoContext.SaveChanges();
        //}
        // POST api/<FileUploadController>
        /*
         * Attempt 4
         * Demo upload multiple file to path \wwwroot\UploadFiles\{id}
         * Add resource filter, fail if file upload larger than 1MB
         * **/
        [HttpPost("{id}")]
        //[FileLimit]
        [FileLimit(Size = 1)] // size in MB
        public void Post(List<IFormFile> files, Guid id)
        {
            string rootRoot = _env.ContentRootPath + @"\wwwroot\UploadFiles\" + id + "\\";

            if (!Directory.Exists(rootRoot))
            {
                // Check whether path exist, if not create one
                Directory.CreateDirectory(rootRoot);
            }

            foreach (var file in files)
            {
                var fileName = file.FileName;

                using (var stream = System.IO.File.Create(rootRoot + fileName))
                {
                    file.CopyTo(stream);
                }

                var insert = new UploadFile
                {
                    Name = fileName,
                    Src = "/UploadFiles/" + id + "/" + fileName,
                    TodoId = id
                };

                _todoContext.Add(insert);
            }

            _todoContext.SaveChanges();
        }
    }
}
