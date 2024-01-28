using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo2.Dtos;
using ToDo2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo2.Controllers
{
    [Route("api/Todo/{TodoId}/UploadFile")]
    [ApiController]
    public class TodoUploadFileController : ControllerBase
    {
        private readonly TodoContext _todoContext;

        public TodoUploadFileController(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        // GET: api/Todo/{TodoId}/UploadFile
        [HttpGet]
        public ActionResult<IEnumerable<UploadFileDtos>> Get(Guid TodoId)
        {
            if (!_todoContext.TodoLists.Any(a => a.TodoId == TodoId))
            {
                return NotFound("Cannot find the data ;-;");
            }

            var result = from a in _todoContext.UploadFiles
                         where a.TodoId == TodoId
                         select new UploadFileDtos
                         {
                             Name = a.Name,
                             Src = a.Src,
                             TodoId = a.TodoId,
                             UploadFileId = a.UploadFileId
                         };
            if(result == null || result.Count() == 0)
            {
                return NotFound("找不到,no upload file");
            }
            return Ok(result);
        }

        // GET: api/Todo/{TodoId}/UploadFile/{UploadFileId}
        [HttpGet("{UploadFileId}")]
        public ActionResult<UploadFile> Get(Guid TodoId, Guid UploadFileId)
        {
            if (!_todoContext.TodoLists.Any(a => a.TodoId == TodoId)){
                return NotFound("Cannot found ?????");
            }
            var result = from a in _todoContext.UploadFiles
                         where a.TodoId == TodoId
                         && a.UploadFileId == UploadFileId
                         select new UploadFileDtos
                         {
                             Name = a.Name,
                             Src = a.Src,
                             TodoId = a.TodoId,
                             UploadFileId = a.UploadFileId
                         };
            if (result == null || result.Count() == 0)
            {
                return NotFound("找不到,no upload file");
            }
            return Ok(result);

        }

        /*
         * Attempt 1: Check whether parent data exist, then add child data
         * **/
        // POST /api/Todo/{TodoId}/UploadFile
        [HttpPost]
        public string Post(Guid TodoId, [FromBody] UploadFilePostDtos value)
        {
            if (!_todoContext.TodoLists.Any(a => a.TodoId == TodoId))
            {
                return "Cannot found ?????";
            }
            UploadFile insert = new UploadFile 
            {
                Name=value.Name,
                Src = value.Src,
                TodoId = TodoId
            };

            _todoContext.UploadFiles.Add(insert);
            _todoContext.SaveChanges();

            return "Ok";
        }

        // PUT api/<TodoUploadFileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoUploadFileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
